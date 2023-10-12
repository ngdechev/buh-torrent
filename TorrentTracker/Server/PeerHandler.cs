using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using PTT_Parser;
using TorrentTracker.Controllers;
using PeerSoftware;

namespace TorrentTracker.Server
{
    public class PeerHandler
    {
        private TcpClient _peerSocket;
        private NetworkStream _stream;
        private ITorrentManagementController _torrentManagementController;
        private IPeerManagementController _peerManagementController;
        
        public PeerHandler(TcpClient peerSocket, ITorrentManagementController torrentManagementController, IPeerManagementController peerManagementController)
        {
            _peerSocket = peerSocket; 
            _torrentManagementController = torrentManagementController;
            _peerManagementController = peerManagementController;
        }

        public void HandlePeer()
        {
            PTTBlock _block;
            
            _stream = _peerSocket.GetStream();

            _block = PTT.ParseToBlock(_stream);

            byte command = _block.GetCommand();
            int size = _block.GetSize();
            string payload = _block.GetPayload();

            if (command == 0x00)
            {
                _peerManagementController.CreatePeer(payload);
            } 
            else if (command == 0x01)
            {
                _peerManagementController.DestroyPeer(payload);
            }
            else if (command == 0x02)
            {
                string[] payloadArray = payload.Split(";", 2);

                string ip = payloadArray[0];
                string torrentFile = payloadArray[1];

                _torrentManagementController.CreateTorrent(ip, torrentFile);
            }
            else if (command == 0x03)
            {
                string[] payloadArray = payload.Split(";", 2);

                string ip = payloadArray[0];
                string checksum = payloadArray[1];

                _torrentManagementController.DeleteTorrent(ip, checksum);
            }
            else if (command == 0x04)
            {
                List<TorrentFile> allTorrents = _torrentManagementController.ListTorrents();

                string json = JsonSerializer.Serialize(allTorrents);

                PTTBlock PTTBlock = new(0x05, json.Length, json);

                byte[] bytes = Encoding.ASCII.GetBytes(PTTBlock.ToString());
                Console.WriteLine("before send");
                try
                {
                    _stream.Write(bytes, 0, bytes.Length);
                    _stream.Flush(); // Force the data to be sent
                    Console.WriteLine("Data sent successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending data: " + ex.Message);
                }
            }
            else if (command == 0x06)
            {
                _peerManagementController.ListPeers();
            }
            else if (command == 0x08)
            {
                _torrentManagementController.SearchTorrent(payload);
            }
        }
    }
}
