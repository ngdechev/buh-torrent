using PeerSoftware.Storage;
using PeerSoftware.Utils;
using PTP_Parser;
using PTT_Parser;
using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Net.Sockets;
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
                    file.info.fileName.ToLower().Contains(searchTerm) ||
                    file.info.description.ToLower().Contains(searchTerm))
                .ToList();
            resultMaxPage = (int)Math.Ceiling(searchResults.Count / 5.0);
            searchOnFlag = true;

            return searchResults;
        }

        public void LoadData(ITorrentStorage torrentStorage, Form1 form1, ref int allPageMax)
        {
            torrentStorage.GetAllTorrentFiles().Clear();

            try
            {
                PTTBlock block = new PTTBlock(0x04, 0, null);

                int maxPage = allPageMax; 

                Connections connections = new Connections(torrentStorage);
                Thread thread = new Thread(() => connections.SendAndRecieveData(block, form1, ref maxPage));

                thread.Start();

                allPageMax = maxPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void StartDownload(Connections connections, Form1 form1, TorrentStorage torrentStorage, NetworkUtils networkUtils)
        {
            List<string> receivedLivePeers = new List<string>();
            TorrentFile torrentFile = torrentStorage.GetDownloadingTorrents().First();
            TorrentFile newTorrent = new TorrentFile();

            PTTBlock block = new PTTBlock(0x06, 0, torrentFile.info.checksum);
            receivedLivePeers = connections.SendAndRecieveData06(block, form1);
            
            Dictionary<string, string> peersAndBlocks = new Dictionary<string, string>();
            //..peersAndBlocks = CalculateParticions(receivedLivePeers);

            foreach (string peer in peersAndBlocks.Keys)
            {
                string parts = peersAndBlocks[peer];

                PTPParser.StartPackage($"{torrentFile.info.checksum}/{parts}");

                string fileExtension = Path.GetExtension(torrentFile.info.fileName);

                if (!string.IsNullOrEmpty(fileExtension))
                {
                    fileExtension = fileExtension.TrimStart('.');
                }

                string currentDirectory = Directory.GetCurrentDirectory();
                string path = Path.Combine(currentDirectory, "Download", newTorrent.info.torrentName + "." + fileExtension);

                StreamWriter outputFile = new StreamWriter(Path.Combine(path, $"{torrentFile.info.fileName}.{fileExtension}"));

                using (TcpClient client = new TcpClient(networkUtils.GetLocalIPAddress(), networkUtils.GetLocalPort()))
                {
                    if (File.Exists(path))
                    {
                        PTPBlock receivedBlock = PTPParser.ParseToBlock(client.GetStream());

                        outputFile.WriteLine(receivedBlock.GetData());
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
