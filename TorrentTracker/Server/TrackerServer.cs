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
            try
            {
                _listener = new(IPAddress.Any, serverPort);
                _udpServer = new UdpClient(udpPort);

                _listener.Start();

                Console.WriteLine($"Tracker server started!");
                _dictionary.ReadDictionaryFromFile();

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
            catch (Exception ex)
            {
                Console.WriteLine("|===| Error: " + ex.Message + "|===|");
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

                foreach (Peer peer in _dictionary.GetDictionary().Keys)
                {
                    if (peer.IPAddress == parts[0])
                    {
                        peer.Date = dateTime;
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("|===| Error handling UDP packets: " + ex.Message + "|===|");
            }
        }

        public void Stop()
        {
            _dictionary.WriteDictionaryToFile();
            _isRunning = false;
        }
    }
}