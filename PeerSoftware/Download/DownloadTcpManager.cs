using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PTP_Parser;
using System.IO;

namespace PeerSoftware.Download
{
    public class DownloadTcpManager
    {
        private List<PTPBlock> _pTPBlocks = new List<PTPBlock>();
        private List<TcpClient> _clients = new List<TcpClient>();
        private int _serverPort = 12346;
        private int _numberOfBlocks;

        public void ConnectAndManageConnections(Dictionary<string, string> peersAndBlocks, TorrentFile torrentFile)
        {
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
                    // Console.WriteLine($"Connected to server at {serverIp}:{_serverPort}");
                    // You can now send and receive data on 'client' synchronously.
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to connect to {serverIp}:{_serverPort}: {ex.Message}");
                }
            }
            string[] idBlocks = peersAndBlocks.Last().Value.Split('-', 2);
            //int.TryParse(idBlocks[0], out int firstBlock);
            int.TryParse(idBlocks[1], out int lastBlock);
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

        public void ReceiveData()
        {
            while (_pTPBlocks.Count < _numberOfBlocks)
            {
                foreach (var client in _clients)
                {
                    if (client.Connected && client.GetStream().DataAvailable)
                    {
                        PTPBlock receivedBlock = PTPParser.ParseToBlock(client.GetStream());
                        _pTPBlocks.Add(receivedBlock);
                    }
                    else if (client.Connected && _pTPBlocks.Count == _numberOfBlocks - 1)
                    {
                        return;
                    }
                }
            }
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
    }
}
