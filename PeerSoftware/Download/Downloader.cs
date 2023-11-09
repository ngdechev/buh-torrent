using PeerSoftware.Services;
using PTP_Parser;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace PeerSoftware.Download
{
    public class Downloader
    {
        private int _index;
        public Downloader()
        {
            _index = 0;
        }

        public void Download(TorrentFile torrentFile, string peers)
        {
            ThreadManager threadManager = new ThreadManager();
            List<string>peersList= JsonSerializer.Deserialize<List<string>>(peers);

            if (peersList.Count == 0)
            {
                MessageBox.Show("There are no available peers who has the file.");
                return;
            }

            threadManager.CreateThread(() =>
            {
                DownloadTcpManager connectionManager = new DownloadTcpManager();
                SharedFileServices sharedFileServices = new SharedFileServices();
                Dictionary<string, string> peersAndBlocks = sharedFileServices.CalculateParticions(
                    peersList,
                    (int)torrentFile.info.length);


                // Connect to multiple servers synchronously
                connectionManager.ConnectAndManageConnections(peersAndBlocks, torrentFile);

                // Receive data from all connected servers
                connectionManager.ReceiveData();
                connectionManager.DisconnectAll();
                Reassemble(torrentFile, connectionManager.GetPTPBlocks());
            });

            threadManager.StartThread(_index);

            _index++;
        }

        public void Reassemble(TorrentFile torrentFile, List<PTPBlock> ptpBlocks)
        {
            string fileExtension = Path.GetExtension(torrentFile.info.fileName);

            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.TrimStart('.');
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, "Download", torrentFile.info.torrentName + "." + fileExtension);
            StreamWriter outputFile = new StreamWriter(path);
            if (File.Exists(path))
            {
                
                foreach (PTPBlock block in ptpBlocks)
                {
                    outputFile.Write(block.GetData());
                }
                outputFile.Flush();
                //outputFile.Close();
            }
            else
            {
                Console.WriteLine("File is not created.");
            }

            outputFile.Close();
        }

    }
}