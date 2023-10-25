using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeerSoftware.UDP
{
    public class UDPSender
    {
        private UdpClient _udpClient;
        private IPEndPoint _serverEndPoint;
        private bool _disposed = false;

        public void Start(string trackerIpPlusPort)
        {
            (IPAddress serverIp, int serverPort) = IpAdressSplitter(trackerIpPlusPort);

            _udpClient = new UdpClient();
            _serverEndPoint = new IPEndPoint(serverIp, 56789);

            Thread senderThread = new Thread(SendKeepAlivePackets);

            senderThread.Start();
        }

        public void Stop()
        {
            if (_udpClient != null)
            {
                _udpClient.Close();
                _disposed = true;
            }
        }

        private void SendKeepAlivePackets()
        {
            try
            {
                while (true)
                {
                    if (_disposed)
                    {
                        break;
                    }

                    if (_udpClient != null)
                    {
                        byte[] data = Encoding.ASCII.GetBytes("Keep-Alive");
                        _udpClient.Send(data, data.Length, _serverEndPoint);
                    }

                    Thread.Sleep(5000); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        (IPAddress serverIp, int trackerPort) IpAdressSplitter (string trackerIpPlusPort)
        {
            IPAddress serverIp;
            int serverPort;

            string[] parts = trackerIpPlusPort.Split(":");

            IPAddress.TryParse(parts[0], out serverIp);
            int.TryParse(parts[1], out serverPort);

            return (serverIp, serverPort);
        }
    }
}
