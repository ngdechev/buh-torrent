﻿using MaterialSkin.Controls;
using PeerSoftware.Utils;
using PTT_Parser;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PeerSoftware
{
    public partial class FormNewTorrent : MaterialForm
    {
        Form1 _mainForm;
        TorrentFile _newTorrent;
        NetworkUtils _networkUtils;
        CommonUtils _commonUtils;
        CustomMessageBoxOK _customMessageBoxOK = new();

        public FormNewTorrent(Form1 mainForm, NetworkUtils networkUtils, CommonUtils commonUtils)
        {
            InitializeComponent();

            _newTorrent = new TorrentFile();
            _mainForm = mainForm;
            _networkUtils = networkUtils;
            _commonUtils = commonUtils;
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose File";
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
                    filePathTextBox.Text = filePath;
                    // Update any other parts of your UI or data structures as needed
                    torrentName.Text = newTorrentFile.info.torrentName;

                    fileSizeTextBox.Text = _commonUtils.FormatFileSize(fileSizeInBytes);
                    // Now, you can use newTorrentFile as needed
                    _newTorrent = newTorrentFile;
                }
            }
        }

        private async void upload_Click(object sender, EventArgs e)
        {
            try
            {
                upload.Enabled = false;

                if (_newTorrent.info == null)
                {
                    throw new Exception("The specified path does not exist or is empty. Please enter a valid path and try again..");
                }

                _newTorrent.info.torrentName = torrentName.Text;
                _newTorrent.info.description = description.Text;
                _newTorrent.announce = _mainForm.TextForAnnoncer();
                
                await SendDataAsync();

                upload.Enabled = true;

                this.Close();
            }
            catch (Exception ex)
            {
                _customMessageBoxOK.SetTitle("Attention");
                _customMessageBoxOK.SetMessageText(ex.Message);
                _customMessageBoxOK.ShowDialog();

                upload.Enabled = true;
            }
        }

        private async Task SendDataAsync()
        {
            string ipAddressString;
            int port;
            try
            {
                (ipAddressString, port) = _networkUtils.SplitIpAndPort(_mainForm);

                // Create a TCP client and connect to the server
                using (TcpClient client = new TcpClient())
                {

                    await client.ConnectAsync(ipAddressString, port);
                    string? myip = _networkUtils.GetLocalIPAddress() + ":" + _networkUtils.GetLocalPort().ToString();


                    // Send data asynchronously

                    string ipPlusJson = myip + ";" + JsonSerializer.Serialize(_newTorrent);
                    PTTBlock block = new(0x02, ipPlusJson.Length, ipPlusJson);

                    byte[] data = Encoding.UTF8.GetBytes(block.ToString());
                    await client.GetStream().WriteAsync(data, 0, data.Length);

                    // Handle any response from the server if needed
                    // ...
                    TorrentReader.WriteJSON("MyTorrent", _newTorrent);

                    client.Close();
                }

            }
            catch (Exception ex)
            {

                // Handle exceptions that may occur during the TCP operation
                throw new Exception("Error sending data: " + ex.Message);

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
