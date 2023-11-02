using PeerSoftware.Services;
using PTP_Parser;

namespace PeerSoftware.Download
{
    public class Downloader
    {
        private int _index;
        public Downloader()
        {
            _index = 0;
        }

        void Download(TorrentFile torrentFile, List<string> peers)
        {
            ThreadManager threadManager = new ThreadManager();

            threadManager.CreateThread(() =>
            {
                DownloadTcpManager connectionManager = new DownloadTcpManager();
                SharedFileServices sharedFileServices = new SharedFileServices();
                Dictionary<string, string> peersAndBlocks = sharedFileServices.CalculateParticions(
                    peers,
                    (int)torrentFile.info.length);


                // Connect to multiple servers synchronously
                connectionManager.ConnectAndManageConnections(peersAndBlocks, torrentFile);

                // Receive data from all connected servers
                connectionManager.ReceiveData();

                Reassemble(torrentFile, connectionManager.GetPTPBlocks());

                // Disconnect from all servers
                connectionManager.DisconnectAll();
            });

            threadManager.StartThread(_index);

            _index++;
        }

        void Reassemble(TorrentFile torrentFile, List<PTPBlock> ptpBlocks)
        {
            string fileExtension = Path.GetExtension(torrentFile.info.fileName);

            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.TrimStart('.');
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, "Download", torrentFile.info.torrentName + "." + fileExtension);
            if (File.Exists(path))
            {
                StreamWriter outputFile = new StreamWriter(path);
                foreach (PTPBlock block in ptpBlocks)
                {
                    outputFile.WriteLine(block.GetData());
                }
                outputFile.Flush();
                outputFile.Close();
            }
            else
            {
                Console.WriteLine("File is not created.");
            }
            
            
        }

    }
}