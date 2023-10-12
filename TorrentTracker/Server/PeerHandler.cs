using System.Net.Sockets;
using PTT_Parser;
using TorrentTracker.Controllers;

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
                string[] payloadArray = payload.Split(";",2);

                string ip = payloadArray[0];
                string torrentFile = payloadArray[1];

                _torrentManagementController.CreateTorrent(ip, torrentFile);
            }
            else if (command == 0x03)
            {
                string[] payloadArray = payload.Split(" ");

                string ip = payloadArray[0];
                string checksum = payloadArray[1];

                _torrentManagementController.DeleteTorrent(ip, checksum);
            }
            else if (command == 0x04)
            {
                _torrentManagementController.ListTorrents();
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
