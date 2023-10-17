using PTT_Parser;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

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
            _dictionaryController = dictionaryController;
        }

        public void HandlePeer()
        {
            PTTBlock _block;
           // _dictionaryController.ReadDictionaryFromFile();
            _stream = _peerSocket.GetStream();


            _block = PTT.ParseToBlock(_stream);

            byte command = _block.GetCommand();
            int size = _block.GetSize();
            string payload = _block.GetPayload();

            if (command == 48) //0
            {
                //_peerManagementController.CreatePeer(payload);
            } 
            else if (command == 49) //1
            {
                _peerManagementController.DestroyPeer(payload);
            }
            else if (command == 50) //2
            {
                string[] payloadArray = payload.Split(";", 2);

                string ip = payloadArray[0];
                string torrentFile = payloadArray[1];

                _torrentManagementController.CreateTorrent(ip, torrentFile);
            }
            else if (command == 51) //3
            {
                string[] payloadArray = payload.Split(";", 2);

                string ip = payloadArray[0];
                string checksum = payloadArray[1];

                _torrentManagementController.DeleteTorrent(ip, checksum);
            }
            else if (command == 52) //4
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

            else if (command == 54) //6
            {
                _peerManagementController.ListPeers();
            }
            else if (command == 56) //8
            {
                _torrentManagementController.SearchTorrent(payload);
            }
        }

    }
}
