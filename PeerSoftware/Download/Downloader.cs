﻿using MaterialSkin.Controls;
using Microsoft.Toolkit.Uwp.Notifications;
using PeerSoftware.Services;
using PeerSoftware.Utils;
using PTP_Parser;
using PTT_Parser;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;


namespace PeerSoftware.Download
{
    public class Downloader
    {
        private ThreadManager _threadManager;
        private List<Thread> _threads = new List<Thread>();
        private List<DownloadTcpManager> _downloadTcpManagers = new List<DownloadTcpManager>();
        private CustomMessageBoxOK _customMessageBoxOK;

        public Downloader()
        {
            _threadManager = new ThreadManager();
            _customMessageBoxOK = new CustomMessageBoxOK();
        }

        public void Download(TorrentFile torrentFile, List<string> peers, MaterialProgressBar progressBar, NetworkUtils networkUtils, Form1 form, int index)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            List<string> peersList = peers;

            if (peersList.Count == 0)
            {
                _customMessageBoxOK.SetMessageText("There are no available peers who has the file.");
                _customMessageBoxOK.ShowDialog();
                return;
            }

            _threads.Insert( index,
                _threadManager.CreateThread(() =>
                {
                    DownloadTcpManager connectionManager = new DownloadTcpManager();
                    try
                    {
                        AddDownloadTCPManeger(index, connectionManager);

                        SharedFileServices sharedFileServices = new SharedFileServices();
                        Dictionary<string, string> peersAndBlocks = sharedFileServices.CalculateParticions(peersList, (int)torrentFile.info.length, form.GetNPeersUploading());

                        // Connect to multiple servers synchronously
                        connectionManager.ConnectAndManageConnections(peersAndBlocks, torrentFile, progressBar);

                        // Receive data from all connected servers
                        if (connectionManager.ReceiveData())
                        {
                            //connectionManager.DisconnectAll();

                            
                            Reassemble(torrentFile, connectionManager.GetPTPBlocks(), form.GetSharedFileDownloadFolder());
                            Finally(connectionManager, form, torrentFile, networkUtils, index);

                            new ToastContentBuilder()
                                .AddText($"{torrentFile.info.torrentName} has been downloaded!")
                                .Show();

                            _threadManager.StopThread(index, ref _threads);
                        }

                        connectionManager.DisconnectAll();
                        



                        // Disconnect from all servers
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Download failed: {ex.Message}");
                        // Handle or log the exception as needed
                    }


                })
            );
            int maxParallelDownloads = form.GetNParallelDownloads();

            _threadManager.StartThread(index, maxParallelDownloads, _threads);

            
        }

        public void Resume(TorrentFile torrentFile, List<string> peers, MaterialProgressBar progressBar, NetworkUtils networkUtils, Form1 form, int index)
        {
            List<string> peersList = peers;

            if (peersList.Count == 0)
            {
                _customMessageBoxOK.SetMessageText("There are no available peers who has the file.");
                _customMessageBoxOK.ShowDialog();
                return;
            }

            _threads[index] = _threadManager.CreateThread(() =>
            {
                Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

                DownloadTcpManager connectionManager = new DownloadTcpManager();
                try
                {
                    _downloadTcpManagers[index] = connectionManager;

                    SharedFileServices sharedFileServices = new SharedFileServices();

                    string path = "temp\\" + torrentFile.info.torrentName + ".json";
                    List<PTPBlock> pTPBlocks = new List<PTPBlock>();
                    List<TempPTPBlock> tempPTPBlocks = new List<TempPTPBlock>();

                    string jsonString = File.ReadAllText(path);

                    tempPTPBlocks = JsonSerializer.Deserialize<List<TempPTPBlock>>(jsonString);

                    foreach (TempPTPBlock block in tempPTPBlocks)
                    {
                        pTPBlocks.Add(new PTPBlock(block.Id, block.Size, block.Data));
                    }

                    List<int> ints = new List<int>();

                    foreach (PTPBlock block in pTPBlocks)
                    {
                        ints.Add(block.GetId());
                    }
                    connectionManager.SetPTPBlocks(pTPBlocks);
                    Dictionary<string, string> peersAndBlocks = sharedFileServices.ReCalculateParticions(peers, (int)torrentFile.info.length, ints, form.GetNPeersUploading());

                    // Connect to multiple servers synchronously
                    connectionManager.ConnectAndManageConnections(peersAndBlocks, torrentFile, progressBar);

                    // Receive data from all connected servers


                    if (connectionManager.ReceiveData())
                    {
                        //connectionManager.DisconnectAll();
                        Reassemble(torrentFile, connectionManager.GetPTPBlocks(), form.GetSharedFileDownloadFolder());
                        Finally(connectionManager, form, torrentFile, networkUtils,index);

                        new ToastContentBuilder()
                            .AddText($"{torrentFile.info.torrentName} has been downloaded!")
                            .Show();

                        _threadManager.StopThread(index, ref _threads);

                    }

                    connectionManager.DisconnectAll();
                    
                    



                    // Disconnect from all servers
                }
                catch (Exception ex)
                {
                    Logger.e($"Download failed: {ex.Message}");
                }

               
            });

            int maxParallelDownloads = form.GetNParallelDownloads();

            _threadManager.StartThread(index, maxParallelDownloads, _threads);

            
        }

        public void Finally(DownloadTcpManager connectionManager, Form1 form, TorrentFile torrentFile, NetworkUtils networkUtils, int index)
        { 
            // Ensure progress bar is updated even if an exception occurs
            connectionManager.UpdateProgressBar();
            RemoveDownloadTCPManeger(index);

            new CommonUtils().ReceateTorrentFileForDownloadedFile(form.GetTorrentStorage(), torrentFile.info.checksum, form);
            form.GetTorrentStorage().GetDownloadTorrentFiles().Remove(torrentFile);

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
            }
        }

        public void Reassemble(TorrentFile torrentFile, List<PTPBlock> ptpBlocks, string sharedFileDownloadFolder)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            string fileExtension = Path.GetExtension(torrentFile.info.fileName);

            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.TrimStart('.');
            }

            string path = Path.Combine(sharedFileDownloadFolder, torrentFile.info.torrentName + "." + fileExtension);
            StreamWriter outputFile = new StreamWriter(path);
            if (File.Exists(path))
            {
                ptpBlocks = ptpBlocks.OrderBy(block => block.GetId()).ToList();
                foreach (PTPBlock block in ptpBlocks)
                {
                    outputFile.Write(block.GetData());
                }
                outputFile.Flush();
                //outputFile.Close();
            }
            else
            {
                Logger.e("File is not created.");
            }

            outputFile.Close();
        }

        public void Pause(int index)
        {
            GerDownloadTCPManeger(index).isRunnig = false;
        }

        public List<PTPBlock> ReadBlocks(string path)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            List<PTPBlock> pTPBlocks = new List<PTPBlock>();
            List<TempPTPBlock> tempPTPBlocks = new List<TempPTPBlock>();

            string jsonString = File.ReadAllText(path);

            tempPTPBlocks = JsonSerializer.Deserialize<List<TempPTPBlock>>(jsonString);

            foreach (TempPTPBlock block in tempPTPBlocks)
            {
                pTPBlocks.Add(new PTPBlock(block.Id, block.Size, block.Data));
            }

            return pTPBlocks;
        }

        private void AddDownloadTCPManeger(int index, DownloadTcpManager downloadTcpManager)
        {
            _downloadTcpManagers.Insert(index, downloadTcpManager);
        }

        private void RemoveDownloadTCPManeger(int index)
        {
            _downloadTcpManagers.RemoveAt(index);
        }

        private DownloadTcpManager GerDownloadTCPManeger(int index)
        {
            return _downloadTcpManagers.ElementAt(index);
        }
    }
}