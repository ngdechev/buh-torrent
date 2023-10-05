﻿using PTT_Parser;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PeerSoftware
{
    public partial class FormNewTorrent : Form
    {
        Form1 _mainForm;
        TorrentFile _newTorrent;
        public FormNewTorrent(Form1 mainForm)
        {
            InitializeComponent();
            _newTorrent = new TorrentFile();
            _mainForm = mainForm;
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Pick File to share";
                openFileDialog.Filter = "All Files (*.*)|*.*"; // Filter for all file types
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file's path
                    string file = openFileDialog.FileName;

                    // Use System.IO.FileInfo to get the file size
                    FileInfo fileInfo = new FileInfo(file);

                    // Display the file size
                    long fileSizeInBytes = fileInfo.Length;
                    string fileName = fileInfo.Name;
                    string filePath = fileInfo.FullName;

                    // Create a new TorrentFile instance and initialize its info property
                    TorrentFile newTorrentFile = new TorrentFile
                    {
                        info = new Info
                        {
                            torrentName = Path.GetFileNameWithoutExtension(fileName),
                            fileName = filePath,
                            length = fileSizeInBytes
                        }
                    };

                    // Calculate the checksum (you may need to adjust this part as needed)
                    SHA256 checksum = SHA256.Create();
                    checksum.ComputeHash(Encoding.ASCII.GetBytes(file));
                    newTorrentFile.info.checksum = BitConverter.ToString(checksum.Hash).Replace("-", "").ToLower();

                    // Set the description
                    //description.Text = newTorrentFile.info.checksum;

                    // Update any other parts of your UI or data structures as needed
                    torrentName.Text = newTorrentFile.info.torrentName;

                    // Now, you can use newTorrentFile as needed
                    _newTorrent = newTorrentFile;
                }
            }
        }
        
        private async void upload_Click(object sender, EventArgs e)
        {
            // Disable UI controls that should not be used while sending data
            upload.Enabled = false;

            _newTorrent.info.torrentName = torrentName.Text;
            _newTorrent.info.description = description.Text;
            _newTorrent.announce = _mainForm.TextForAnnoncer();
            // Disable other controls as needed

            try
            {
                // Perform your TCP operations asynchronously
                await SendDataAsync();

                // Enable the UI controls after sending is done
                upload.Enabled = true;
                // Enable other controls as needed
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the TCP operation
                MessageBox.Show("An error occurred: " + ex.Message);

                // Make sure to re-enable the UI controls in case of an error
                upload.Enabled = true;
                // Enable other controls as needed
            }

        }
        public (string, int) SplitIpAndPort()
        {
            string trackerIpField = _mainForm.TextForAnnoncer();
            if (trackerIpField == null)
            {
                return (string.Empty, 0);
            }

            string[] parts = trackerIpField.Split(':');

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
        private async Task SendDataAsync()
        {
            string ipAddressString;
            int port;
            try
            {
                (ipAddressString, port) = SplitIpAndPort();

                // Create a TCP client and connect to the server
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(ipAddressString, port);

                    // Send data asynchronously
                    PTTBlock block = new("0x02", JsonSerializer.Serialize(_newTorrent));
                    byte[] data = Encoding.UTF8.GetBytes(block.ToString());
                    await client.GetStream().WriteAsync(data, 0, data.Length);

                    // Handle any response from the server if needed
                    // ...
                }

            }
            catch (Exception ex)
            {

                // Handle exceptions that may occur during the TCP operation
                throw new Exception("Error sending data: " + ex.Message);

            }
        }
    }
}
