using Microsoft.Toolkit.Uwp.Notifications;
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
        private NetworkUtils _networkUtils;
        private CustomMessageBoxOK _customMessageBoxOK;
        private bool _isConnected = false;

        public Connections(NetworkUtils networkUtils)
        {
            _networkUtils = networkUtils;
            _customMessageBoxOK = new CustomMessageBoxOK();
        }

        public void SendPTTMessage(TcpClient client, byte command, string payload)
        {
            var pttBlock = new PTTBlock(command, payload.Length, payload);
            string pttMessage = PTT.ParseToString(pttBlock);

            byte[] messageBytes = Encoding.ASCII.GetBytes(pttMessage);

            client.GetStream().Write(messageBytes, 0, messageBytes.Length);
            client.GetStream().Flush();
        }
        public bool IsConnected()
        {
            return _isConnected;
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
                        _isConnected = true;
                        NetworkStream stream = client.GetStream();

                        string localIpPort = $"{_networkUtils.GetLocalIPAddress()}:{_networkUtils.GetLocalPort()}";
                        SendPTTMessage(client, 0x00, localIpPort);

                        new ToastContentBuilder()
                            .AddText($"You are connected to server IP: {trackerIpField}")
                            .Show();
                        CloseConnection(client);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond. [::ffff:172.20.60.22]:12345")
                        {
                            _customMessageBoxOK.SetTitle("The server is closed");
                            _customMessageBoxOK.SetMessageText($"Error connecting to {trackerIpField}");
                            _customMessageBoxOK.ShowDialog();
                        }
                        else 
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                }
                else
                {
                    //Notification
                    MessageBox.Show("Invalid IP address or port. Please enter a valid IP address and port.");
                }
            }
        }

        public void DestroyPeer(string trackerIpField, int trackerPortField) 
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(trackerIpField, trackerPortField);
                    NetworkStream stream = client.GetStream();

                    string localIpPort = $"{_networkUtils.GetLocalIPAddress()}:{_networkUtils.GetLocalPort()}";
                    SendPTTMessage(client, 0x01, localIpPort);

                    _customMessageBoxOK.SetTitle($"Disconnected from {trackerIpField}");
                    _customMessageBoxOK.SetMessageText("You are not a peer anymore.");
                    _customMessageBoxOK.ShowDialog();

                    CloseConnection(client);
                    _isConnected = false;
                    new ToastContentBuilder()
                            .AddText($"You Disconect to server IP: {trackerIpField}")
                            .Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error connecting to {trackerIpField}: {ex.Message}");
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
