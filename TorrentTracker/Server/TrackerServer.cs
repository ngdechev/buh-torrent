using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
                    _dictionary.ReadDictionaryFromFile();

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
                string peerIpPlusPort = Encoding.ASCII.GetString(udpData);

                string[] parts = peerIpPlusPort.Split(":");

                int peerPort;
                int.TryParse(parts[1], out peerPort);

                DateTime dateTime = DateTime.Now;
                Console.WriteLine(dateTime.ToString("MM/dd/yyyy HH:mm:ss") + " IP: "+parts[0]);

                // Don't work due to Dictionary Problem

                foreach (Peer peer in _dictionary.GetDictionary().Keys)
                {
                    if (peer.IPAddress == parts[0]/* && peer.Port == peerPort*/)
                    {
                        peer.Date = dateTime;
                        break;
                    }

                }

                _dictionary.ReadDictionaryFromFile();
                _dictionary.WriteDictionaryToFile();

                //map
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