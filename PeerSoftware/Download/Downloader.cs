using MaterialSkin.Controls;
﻿using Microsoft.Toolkit.Uwp.Notifications;
using PeerSoftware.Services;
using PeerSoftware.Utils;
using PTP_Parser;
using PTT_Parser;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


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

        public void Download(TorrentFile torrentFile, List<string> peers, MaterialProgressBar progressBar, NetworkUtils networkUtils, Form1 form)
        {
            ThreadManager threadManager = new ThreadManager();
            List<string> peersList = peers;//JsonSerializer.Deserialize<List<string>>(peers);

            if (peersList.Count == 0)
            {
                MessageBox.Show("There are no available peers who has the file.");
                return;
            }

            _threadManager.CreateThread(() =>
            {
                DownloadTcpManager connectionManager = new DownloadTcpManager();
                try
                {
                   
                    SharedFileServices sharedFileServices = new SharedFileServices();
                    Dictionary<string, string> peersAndBlocks = sharedFileServices.CalculateParticions(peersList, (int)torrentFile.info.length, form.GetNPeersUploading());

                    // Connect to multiple servers synchronously
                    connectionManager.ConnectAndManageConnections(peersAndBlocks, torrentFile, progressBar);

                    // Receive data from all connected servers
                    connectionManager.ReceiveData();
                    connectionManager.DisconnectAll();
                    Reassemble(torrentFile, connectionManager.GetPTPBlocks(), form.GetSharedFileDownloadFolder());

                    // Disconnect from all servers
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Download failed: {ex.Message}");
                    // Handle or log the exception as needed
                }
                finally
                {
                    // Ensure progress bar is updated even if an exception occurs
                    connectionManager.UpdateProgressBar();

                    new CommonUtils().ReceateTorrentFileForDownloadedFile(form.GetTorrentStorage(), torrentFile.info.checksum, form);

                    (string ip, int port) = networkUtils.SplitIpAndPort(form);

                    using (TcpClient client = new TcpClient())
                    {
                        client.Connect(ip, port);

                        string? myip = networkUtils.GetLocalIPAddress() + ":" + networkUtils.GetLocalPort();

                        string ipPlusJson = myip + ";" + JsonSerializer.Serialize(torrentFile);
                        PTTBlock block = new(0x02, ipPlusJson.Length, ipPlusJson);

                        byte[] data = Encoding.UTF8.GetBytes(block.ToString());
                        client.GetStream().Write(data, 0, data.Length);

                        // Handle any response from the server if needed
                        // ...
                        //TorrentReader.WriteJSON("MyTorrent", torrentFile);

                        new ToastContentBuilder()
                            .AddText($"{torrentFile.info.torrentName} has been downloaded!")
                            .Show();
                    }
                }

            });

            _threadManager.StartThread(_index);

            _index++;
        }

        public void Reassemble(TorrentFile torrentFile, List<PTPBlock> ptpBlocks, string sharedFileDownloadFolder)
        {
            string fileExtension = Path.GetExtension(torrentFile.info.fileName);

            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.TrimStart('.');
            }

            string path = Path.Combine(sharedFileDownloadFolder, torrentFile.info.torrentName + "." + fileExtension);
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