using System.Net.Sockets;
using System.Net;


namespace PeerSoftware.Utils
{
    public class NetworkUtils
    {
        public (string, int) SplitIpAndPort(Form1 form1)
        {
            if (form1.GetIpFieldText() == null)
            {
                return (string.Empty, 0);
            }

            string[] parts = form1.GetIpFieldText().Split(':');

            string ipAddressString = "192.168.99.100";
            int port = 12345;

            if (parts.Length == 2)
            {
                ipAddressString = parts[0];

                if (int.TryParse(parts[1], out int parsedPort))
                {
                    port = parsedPort;
                }
                else
                {
                    port = 12345;
                }
            }

            return (ipAddressString, port);
        }

        public string GetLocalIPAddress()
        {
            string localIpAddress = string.Empty;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddresses = host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            foreach (var ipAddress in ipAddresses)
            {
                localIpAddress = ipAddress.ToString();
                break;
            }

            return localIpAddress;
        }

        public int GetLocalPort()
        {
            int localPort = -1;

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, 0));
                localPort = ((IPEndPoint)socket.LocalEndPoint).Port;
            }

            return localPort;
        }
    }
}
