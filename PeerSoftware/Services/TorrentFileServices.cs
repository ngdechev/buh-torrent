using PeerSoftware.Storage;
using PeerSoftware.Utils;
using PTP_Parser;
using PTT_Parser;
using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace PeerSoftware.Services
{
    public class TorrentFileServices
    {
        public List<TorrentFile> SearchTorrentFiles(string searchTerm, ref int resultMaxPage, ref bool searchOnFlag, List<TorrentFile> allTorrentFiles)
        {
            // Convert the search term to lowercase for case-insensitive search
            searchTerm = searchTerm.ToLower();

            // Use LINQ to filter torrentFiles based on the search term in filename or description
            List<TorrentFile> searchResults = allTorrentFiles
                .Where(file =>
                    file.info.torrentName.ToLower().Contains(searchTerm) ||
                    file.info.description.ToLower().Contains(searchTerm))
                .ToList();
            resultMaxPage = (int)Math.Ceiling(searchResults.Count / 5.0);
            searchOnFlag = true;

            return searchResults;
        }

        public void LoadData(ITorrentStorage torrentStorage, Form1 form1 )
        {
            torrentStorage.GetAllTorrentFiles().Clear();

            try
            {
                PTTBlock block = new PTTBlock(0x04, 0, null);
 

                Connections connections = new Connections();
                Thread thread = new Thread(() => connections.SendAndRecieveData(block, form1, torrentStorage));

                thread.Start();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void StartDownload(Connections connections, Form1 form1, ITorrentStorage torrentStorage, SharedFileServices sharedFileServices , NetworkUtils networkUtils)
        {
            List<string> receivedLivePeers = new List<string>();
            TorrentFile torrentFile = torrentStorage.GetDownloadTorrentFiles().First();
            TorrentFile newTorrent = new TorrentFile();

            PTTBlock block = new PTTBlock(0x06, torrentFile.info.checksum.Length , torrentFile.info.checksum);
            //receivedLivePeers = connections.SendAndRecieveData06(block, form1).ToList();
            
            Dictionary<string, string> peersAndBlocks = sharedFileServices.CalculateParticions(receivedLivePeers, (int)torrentFile.info.length);

            foreach (string peer in peersAndBlocks.Keys)
            {
                string parts = peersAndBlocks[peer];

                byte[] data = PTPParser.StartPackage($"{torrentFile.info.checksum}/{parts}");

                string fileExtension = Path.GetExtension(torrentFile.info.fileName);

                if (!string.IsNullOrEmpty(fileExtension))
                {
                    fileExtension = fileExtension.TrimStart('.');
                }

                string currentDirectory = Directory.GetCurrentDirectory();
                string path = Path.Combine(currentDirectory, "Download", torrentFile.info.torrentName + "." + fileExtension);

                StreamWriter outputFile = new StreamWriter(path);

                string[] peerIpAndPort;
                string peerIp = null;
                int peerPort = 0;

                foreach (var part in peersAndBlocks)
                {
                    peerIpAndPort = part.Key.Split(":");
                    peerIp = peerIpAndPort[0];
                    peerPort= int.Parse(peerIpAndPort[1]);
                }

                using (TcpClient client = new TcpClient(peerIp,12346))
                {
                    client.GetStream().Write(data, 0, data.Length);

                    while (!client.GetStream().DataAvailable) ;
                    while (client.GetStream().DataAvailable)
                    {
                        if (File.Exists(path))
                        {
                            PTPBlock receivedBlock = PTPParser.ParseToBlock(client.GetStream());

                            MessageBox.Show(receivedBlock.GetData());

                            outputFile.WriteLine(receivedBlock.GetData());
                            outputFile.Flush();
                            outputFile.Dispose();
                        }
                        else
                        {
                            Console.WriteLine("File is not created.");
                        }
                    }
                }
            }
        }
    }
}
