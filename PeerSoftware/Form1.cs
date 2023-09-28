using Microsoft.VisualBasic.Devices;
using System.Net.Sockets;

namespace PeerSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public PTTBlock ReceivePTTMessage()
        {
            return PTT.ParseToBlock(_stream);
        }

        public void CloseConnection()
        {
            _stream.Close();
            _client.Close();

            _currentIpAddress = _trackerIpField;
            _isConnected = false;
        }

        public (string, int) SplitIpAndPort()
        {
            if (_trackerIpField == null)
            {
                return (string.Empty, 0);
            }

            string[] parts = _trackerIpField.Split(':');

            string ipAddressString = null;
            int port = 0;

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

        // For Unit Tests
        public void SetTrackerIp(string ip)
        {
            trackerIP.Text = ip;
        }

        private void search_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            tableLayoutPanel2.GetRow
        }

    }
}