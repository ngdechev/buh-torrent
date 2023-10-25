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
        private UdpClient _udpServer;

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

        public void Start(int serverPort, int udpPort)
        {
            _listener = new(IPAddress.Any, serverPort);
            _udpServer = new UdpClient(udpPort);

            _listener.Start();

            Console.WriteLine($"Tracker server started!");

            while (_isRunning)
            {
                if (_listener.Pending())
                {
                    TcpClient clientSocket = _listener.AcceptTcpClient();

                    Console.WriteLine("Peer opened the app!");

                    _peerHandler = new(clientSocket, _torrentManagementController, _peerManagementController,_dictionary);


                    Thread peerThread = new Thread(_peerHandler.HandlePeer);

                    peerThread.Start();
                }

                HandleUdpPackets();

                Thread.Sleep(10);
            }

            if (_listener != null)
            {
                _listener?.Stop();
                _udpServer.Close();
            }
        }

        private void HandleUdpPackets()
        {
            try
            {
                IPEndPoint udpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] udpData = _udpServer.Receive(ref udpEndPoint);

                Console.WriteLine("keep alive accepted");

                //TODO: add logic with date
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling UDP packets: " + ex.Message);
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}