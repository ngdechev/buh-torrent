using PTT_Parser;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using TorrentTracker.Controllers;

namespace TorrentTracker.Server
{
    public class PeerHandler
    {
        private TcpClient _peerSocket;
        private NetworkStream _stream;
        private TrackerServer _server;
        public DictionaryController _dictionaryController;
        private ITorrentManagementController _torrentManagementController;
        private IPeerManagementController _peerManagementController;

        private bool _isRunning = false;

        public PeerHandler(TcpClient peerSocket, TrackerServer server, ITorrentManagementController torrentManagementController, IPeerManagementController peerManagementController, DictionaryController dictionaryController)
        {
            _peerSocket = peerSocket;
            _server = server;
            _torrentManagementController = torrentManagementController;
            _peerManagementController = peerManagementController;
            _dictionaryController = dictionaryController;
        }

        public void HandlePeer()
        {
            PTTBlock _block;
           // _dictionaryController.ReadDictionaryFromFile();
            _stream = _peerSocket.GetStream();

            //_isRunning = true;


            //while (_isRunning)
            //{
            _block = PTT.ParseToBlock(_stream); //_peerToTracker.ParseToBlock(_stream);

            string command = _block.GetCommand();
            string payload = _block.GetPayload();

            if (command == "0x00")
            {
                string[] payloadArray = payload.Split(":", 2);
                string ip = payloadArray[0];
                string Forport = payloadArray[1];
                string[] p=Forport.Split("\\");
                int port = int.Parse(p[0]);
                _peerManagementController.CreatePeer(ip,port);

            }
            else if (command == "0x01")
            {
                _peerManagementController.DestroyPeer(payload);
            }
            else if (command == "0x02")
            {
                string[] payloadArray = payload.Split(";", 2);
                string ip = payloadArray[0];
                string torrentFile = payloadArray[1];
                _torrentManagementController.CreateTorrent(ip, torrentFile);

            }
            else if (command == "0x03")
            {
                string[] payloadArray = payload.Split(";", 2);
                string ip = payloadArray[0];
                string checksum = payloadArray[1];

                _torrentManagementController.DeleteTorrent(checksum);
            }
            else if (command == "0x04")
            {

                List<TorrentFile> allTorrents = _torrentManagementController.GetAllTorrents();

                PTTBlock PTTBlock = new("0x05", JsonSerializer.Serialize<List<TorrentFile>>(allTorrents));

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
            else if (command == "0x06")
            {

                _peerManagementController.ListPeersWithTorrentFile(payload);

            }
            else if (command == "0x08")
            {
                _torrentManagementController.SearchTorrent(payload);
                _isRunning = false;
            }
            // }
            _dictionaryController.WriteDictionaryToFile();
        }

        /*public void Disconnect()
        {
            _isRunning = false;
        }*/
    }
}
