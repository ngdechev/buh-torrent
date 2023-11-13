﻿using PeerSoftware.Services;
using PTP_Parser;

namespace PeerSoftware.Download
{
    public class Downloader
    {
        private int _index;
        private ThreadManager _threadManager;
        public Downloader()
        {
            _index = 0;
            _threadManager = new ThreadManager();
        }

        public void Download(TorrentFile torrentFile, List<string> peers, ProgressBar progressBar)
        {

            _threadManager.CreateThread(() =>
            {
                DownloadTcpManager connectionManager = new DownloadTcpManager();
                SharedFileServices sharedFileServices = new SharedFileServices();
                Dictionary<string, string> peersAndBlocks = sharedFileServices.CalculateParticions(
                    peers,
                    (int)torrentFile.info.length);


                // Connect to multiple servers synchronously
                connectionManager.ConnectAndManageConnections(peersAndBlocks, torrentFile, progressBar);

                // Receive data from all connected servers
                connectionManager.ReceiveData();
                connectionManager.DisconnectAll();
                Reassemble(torrentFile, connectionManager.GetPTPBlocks());

                // Disconnect from all servers

            });

            _threadManager.StartThread(_index);

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