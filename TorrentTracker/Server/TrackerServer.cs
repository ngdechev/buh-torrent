using System.Net;
using System.Net.Sockets;
using TorrentTracker.Controllers;
using TorrentTracker.Server;

namespace TorrentTracker
{
    public class TrackerServer
    {
        public bool _isRunning { get; set; }

        private TcpListener? _listener;
        private PeerHandler _peerHandler;
        private DictionaryController _dictionary;
        private ITorrentManagementController _torrentManagementController;
        private IPeerManagementController _peerManagementController;

        public TrackerServer()
        {
            _dictionary = new DictionaryController();
            _torrentManagementController = new TorrentManagementController(_dictionary);
            _peerManagementController = new PeerManagementController(_dictionary);
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

                    Console.WriteLine("Peer opened the app!");

                    _peerHandler = new(clientSocket, _torrentManagementController, _peerManagementController);

                    Thread peerThread = new Thread(_peerHandler.HandlePeer);

                    peerThread.Start();
                }

                Thread.Sleep(10);
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
    }
}