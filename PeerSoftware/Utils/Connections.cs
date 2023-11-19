using PeerSoftware.Storage;
using PTT_Parser;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace PeerSoftware.Utils
{
    public class Connections
    {  
       
        private NetworkUtils _networkUtils = new NetworkUtils();

        public void SendPTTMessage(TcpClient client, byte command, string payload)
        {
            var pttBlock = new PTTBlock(command, payload.Length, payload);
            string pttMessage = PTT.ParseToString(pttBlock);

            byte[] messageBytes = Encoding.ASCII.GetBytes(pttMessage);

            client.GetStream().Write(messageBytes, 0, messageBytes.Length);
            client.GetStream().Flush();
        }

        public void AnnounceNewPeer(string trackerIpField, int trackerPortField)
        {

            using (TcpClient client = new TcpClient())
            {
                if (IPAddress.TryParse(trackerIpField, out IPAddress ipAddress))
                {
                    try
                    {
                        client.Connect(trackerIpField, trackerPortField);
                        NetworkStream stream = client.GetStream();

                        string localIpPort = $"{_networkUtils.GetLocalIPAddress()}:{_networkUtils.GetLocalPort()}";
                        SendPTTMessage(client, 0x00, localIpPort);

                        MessageBox.Show($"Connected to {trackerIpField}");

                        CloseConnection(client);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error connecting to {trackerIpField}: {ex.Message}");
                    }

                }
                else
                {
                    MessageBox.Show("Invalid IP address or port. Please enter a valid IP address and port.");
                }
            }
        }

        public void SendAndRecieveData(object blockin, Form1 form1, ITorrentStorage torrentStorage)
        {
            string trackerIpField;
            int trackerPortField;

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    PTTBlock block = (PTTBlock)blockin;

                    (trackerIpField, trackerPortField) = _networkUtils.SplitIpAndPort(form1);
                    client.Connect(trackerIpField, trackerPortField);

                    byte[] data = Encoding.ASCII.GetBytes(block.ToString());
                    client.GetStream().Write(data, 0, data.Length);

                    while (!client.GetStream().DataAvailable) ;
                    while (client.GetStream().DataAvailable)
                    {
                        PTTBlock receive = PTT.ParseToBlock(client.GetStream());
                        string payload = receive.GetPayload();

                        torrentStorage.GetAllTorrentFiles().AddRange(JsonSerializer.Deserialize<List<TorrentFile>>(payload));
                    }

                    CloseConnection(client);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error sending data: " + ex.Message);
            }
        }

        public List<string> SendAndRecieveData06(object blockin, Form1 form1)
        {
            string trackerIpField;
            int trackerPortField;
            string receivedLivePeers = "";

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    PTTBlock block = (PTTBlock)blockin;

                    (trackerIpField, trackerPortField) = _networkUtils.SplitIpAndPort(form1);
                    client.Connect(trackerIpField, trackerPortField);

                    byte[] data = Encoding.ASCII.GetBytes(block.ToString());
                    client.GetStream().Write(data, 0, data.Length);

                    while (!client.GetStream().DataAvailable) ;
                    while (client.GetStream().DataAvailable)
                    {
                        PTTBlock receive = PTT.ParseToBlock(client.GetStream());
                        string payload = receive.GetPayload();
                        receivedLivePeers = payload;
                        //receivedLivePeers.Add(payload);
                    }

                    CloseConnection(client);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error sending data: " + ex.Message);
            }

            return JsonSerializer.Deserialize<List<string>>(receivedLivePeers);
        }
        public void CloseConnection(TcpClient client)
        {
            client.GetStream().Close();
            client.Close();
        }
    }
}
