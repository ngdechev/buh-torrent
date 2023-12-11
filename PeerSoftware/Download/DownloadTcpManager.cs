using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PTP_Parser;
using System.IO;
using System.Timers;
using MaterialSkin.Controls;
using System.Text.Json;
using PTT_Parser;

namespace PeerSoftware.Download
{
    public class DownloadTcpManager
    {
        private List<PTPBlock> _pTPBlocks = new List<PTPBlock>();
        private List<TcpClient> _clients = new List<TcpClient>();
        private int _serverPort = 12346;
        private int _numberOfBlocks;
        private MaterialProgressBar _progressBar;
        private TorrentFile _torrentFile;
        public bool isRunnig;
        private ManualResetEvent _flagEvent = new ManualResetEvent(false);

        public void ConnectAndManageConnections(Dictionary<string, string> peersAndBlocks, TorrentFile torrentFile, MaterialProgressBar progressBar)
        {
            isRunnig = true;
            _progressBar = progressBar;
            _torrentFile = torrentFile;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (sender, e) =>  UpdateProgressBar();
            timer.Start();

            string[] idBlocks = peersAndBlocks.Last().Value.Split('-', 2);
            //int.TryParse(idBlocks[0], out int firstBlock);
            int.TryParse(idBlocks[1], out int lastBlock);

            foreach (var serverIp in peersAndBlocks)
            {
                TcpClient client = new TcpClient();
                _clients.Add(client);

                try
                {
                    string[] peerIpAndPort = serverIp.Key.Split(":");
                    client.Connect(peerIpAndPort[0], _serverPort);
                    byte[] data = PTPParser.StartPackage($"{torrentFile.info.checksum}/{serverIp.Value}");
                    client.GetStream().Write(data);
                    _progressBar.Maximum = lastBlock;
                    // Console.WriteLine($"Connected to server at {serverIp}:{_serverPort}");
                    // You can now send and receive data on 'client' synchronously.
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to connect to {serverIp}:{_serverPort}: {ex.Message}");
                }
            }
            
            //
            _numberOfBlocks = lastBlock;
        }

        

        public void SendDataOnce(string data)
        {
            foreach (var client in _clients)
            {
                if (client.Connected)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    stream.Write(buffer, 0, buffer.Length);
                    //Console.WriteLine($"Data sent to {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
                }
            }
        }

        public bool ReceiveData()
        {
            while (_pTPBlocks.Count < _numberOfBlocks)
            {
                foreach (var client in _clients)
                {
                    if (!isRunnig)
                    {
                        SaveToTemp();
                        DisconnectAll();
                        return false;
                    }
                    if (client.Connected && client.GetStream().DataAvailable)
                    {
                        PTPBlock receivedBlock = PTPParser.ParseToBlock(client.GetStream());
                        _pTPBlocks.Add(receivedBlock);
                    }
                    else if (client.Connected && _pTPBlocks.Count == _numberOfBlocks)
                    {
                        return true;
                    }
                    
                }
                Thread.Sleep(50);
            }
            return true;
        }

        public void DisconnectAll()
        {
            foreach (var client in _clients)
            {
                client.Close();
            }
        }

        public List<PTPBlock> GetPTPBlocks() 
        {
            return _pTPBlocks;
        }

        public void SetPTPBlocks(List<PTPBlock> pTPBlocks)
        {
            _pTPBlocks = pTPBlocks;
        }

        public void SaveToTemp()
        {
            List<TempPTPBlock> tempPTPBlocks = new List<TempPTPBlock>();
            foreach (PTPBlock block in _pTPBlocks)
            {
                tempPTPBlocks.Add(new TempPTPBlock(block.GetId(), block.GetSize(), block.GetDataByte()));
            }
            string path = "temp\\"+_torrentFile.info.torrentName + ".json";
            using (StreamWriter tempFile = new StreamWriter(path))
            {
                if (File.Exists(path))
                {
                    string json = JsonSerializer.Serialize(tempPTPBlocks);
                    tempFile.Write(json);
                    tempFile.Flush();
                    //outputFile.Close();
                }
            }
            

        }

        public void SetDownloadingFlag(bool value)
        {
            isRunnig = value;
            if (isRunnig)
            {
                _flagEvent.Set(); // Signal the event if downloading
            }
        }

        public void UpdateProgressBar()
        {
            if (_progressBar.InvokeRequired)
            {
                _progressBar.BeginInvoke(new Action(() =>
                {
                    Form1.SetProgressBarValue(_progressBar, _pTPBlocks.Count );
                }));
            }
            else
            {
                Form1.SetProgressBarValue(_progressBar, _pTPBlocks.Count );
            }
        }

    }
}
