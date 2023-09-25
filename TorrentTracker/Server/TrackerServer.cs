using System.Net;
using System.Net.Sockets;
using TorrentTracker.Server;

namespace TorrentTracker
{
    public class TrackerServer
    {
        public readonly object _peersLock;
        public bool _isRunning { get; set; }

        private TcpListener? _listener;
        private PeerHandler _peerHandler;
        private List<PeerHandler> _connectedPeers;

        public TrackerServer()
        {
            _connectedPeers = new List<PeerHandler>();
            _peersLock = new object();

            _isRunning = true;
        }

        public void Start(int serverPort)
        {
            _listener = new(IPAddress.Any, serverPort);
            _listener.Start();

            Console.WriteLine($"Tracker server started!");

            while (_isRunning)
            {
                if (_listener.Pending())
                {
                    TcpClient clientSocket = _listener.AcceptTcpClient();

                    Console.WriteLine("Peer connected!");

                    _peerHandler = new(clientSocket, this);

                    lock (_peersLock)
                    {
                        _connectedPeers.Add(_peerHandler);
                    }

                    Thread peerThread = new Thread(_peerHandler.HandlePeer);

                    peerThread.Start();
                }

                Thread.Sleep(10);
            }

            lock (_peersLock)
            {
                if (_connectedPeers.Count == 0)
                {
                    _connectedPeers.Clear();
                }                   
                else
                {
                    foreach (PeerHandler peer in _connectedPeers)
                    {
                        peer.SendMessage("Server stopped! All the clients are disconnected!");
                        peer.Disconnect();
                    }
                }
            }

            if (_listener != null)
            {
                _listener?.Stop();
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public void RemovePeer(PeerHandler peer)
        {
            lock (_peersLock)
            {
                _connectedPeers.Remove(peer);
            }
        }
    }

}