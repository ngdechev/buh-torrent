using System.Net.Sockets;

namespace TorrentTracker.Server
{
    public class PeerHandler
    {
        private TcpClient _peerSocket;
        private NetworkStream _stream;
        private TrackerServer _server;

        public PeerHandler(TcpClient peerSocket, TrackerServer server)
        {
            _peerSocket = peerSocket ?? throw new ArgumentNullException(nameof(peerSocket));
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public void HandlePeer()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
