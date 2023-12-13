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
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            _networkUtils = networkUtils;
            _customMessageBoxOK = new CustomMessageBoxOK();
        }

        public void SendPTTMessage(TcpClient client, byte command, string payload)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

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
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

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
                            .AddText($"You are connected to {trackerIpField}.")
                            .Show();

                        Logger.i($"You are connected to {trackerIpField}.");

                        CloseConnection(client);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond. [::ffff:172.20.60.22]:12345")
                        {
                            _customMessageBoxOK.SetTitle("The server is closed");
                            _customMessageBoxOK.SetMessageText($"Error connecting to {trackerIpField}!");
                            _customMessageBoxOK.ShowDialog();

                            Logger.e($"Error connecting to {trackerIpField} - The server is closed!");
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
                    _customMessageBoxOK.SetMessageText("Invalid IP address or port. Please enter a valid IP address and port.");
                    _customMessageBoxOK.ShowDialog();
                }
            }
        }

        public void DestroyPeer(string trackerIpField, int trackerPortField) 
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(trackerIpField, trackerPortField);
                    NetworkStream stream = client.GetStream();

                    string localIpPort = $"{_networkUtils.GetLocalIPAddress()}:{_networkUtils.GetLocalPort()}";
                    SendPTTMessage(client, 0x01, localIpPort);

                    Logger.i($"Disconnected from {trackerIpField}");

                    CloseConnection(client);
                    _isConnected = false;
                    new ToastContentBuilder()
                            .AddText($"Disconected from the server {trackerIpField}!")
                            .Show();
                }
                catch (Exception ex)
                {
                    Logger.e(ex.Message);

                    _customMessageBoxOK.SetMessageText($"Error connecting to {trackerIpField}: {ex.Message}");
                    _customMessageBoxOK.ShowDialog();
                }
            }
        }

        public void SendAndRecieveData(object blockin, Form1 form1, ITorrentStorage torrentStorage)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

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
                Logger.e(ex.Message);

                //_customMessageBoxOK.SetMessageText("Error sending data: " + ex.Message);
                //_customMessageBoxOK.ShowDialog();
            }
        }

        public List<string> SendAndRecieveData06(object blockin, Form1 form1)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

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
                Logger.e(ex.Message);

                _customMessageBoxOK.SetMessageText("Error sending data: " + ex.Message);
                _customMessageBoxOK.ShowDialog();
            }

            return JsonSerializer.Deserialize<List<string>>(receivedLivePeers);
        }
        public void CloseConnection(TcpClient client)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            client.GetStream().Close();
            client.Close();
        }
    }
}
