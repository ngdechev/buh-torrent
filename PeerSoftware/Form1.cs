using PeerSoftware;
using PTT_Parser;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using PeerSoftware.Storage;
using PeerSoftware.Utils;
using PeerSoftware.Services;
using System.Collections.Generic;
using PeerSoftware.UDP;
using PeerSoftware.Upload;
using PeerSoftware.Download;

namespace PeerSoftware
{
    public partial class Form1 : Form
    {
        private List<Control> _titleControls = new List<Control>();
        private List<Control> _sizeControls = new List<Control>();
        private List<Control> _descriptionControls = new List<Control>();
        private List<Control> _downloadControls = new List<Control>();

        private List<string> _torrentDownloadingNames = new List<string>();
        private int _allPage = 0;
        private int _allMaxPage = 0;

        private int _resultPage = 0;
        private int _resultMaxPage = 0;
        private bool _searchOnFlag = false;

        private ITorrentStorage _storage;
        private Connections _connections;
        private TorrentFileServices _torrentFileServices;
        private SharedFileServices _sharedFileServices;
        private CommonUtils _commonUtils;
        private NetworkUtils _networkUtils;
        private UDPSender _udpSender;
        private Downloader _downloader;
        
        public Form1()
        {
            InitializeComponent();

            _storage = new TorrentStorage();
            _connections = new Connections();
            _torrentFileServices = new TorrentFileServices();
            _sharedFileServices = new SharedFileServices();
            _commonUtils = new CommonUtils();
            _networkUtils = new NetworkUtils();
            _udpSender = new UDPSender(_networkUtils);

            UploadPeerServer uploadserver = new UploadPeerServer(_storage);

            Thread peerThread = new Thread(uploadserver.Start);

            peerThread.Start();

            _downloader = new Downloader();

            // Create the TableLayoutPanel for the heading row
            TableLayoutPanel headingTableLayoutPanel = new TableLayoutPanel();

            headingTableLayoutPanel.ColumnCount = 3;

            // Create the heading labels
            Label nameLabel = new Label();
            nameLabel.Text = "Name1";

            headingTableLayoutPanel.Controls.Add(nameLabel, 0, 0);

            Label sizeLabel1 = new Label();
            sizeLabel1.Text = "File Size1";
            headingTableLayoutPanel.Controls.Add(sizeLabel1, 1, 0);

            Label progressLabel = new Label();
            progressLabel.Text = "Progress1";

            headingTableLayoutPanel.Controls.Add(progressLabel, 2, 0);

            this.Controls.Add(headingTableLayoutPanel);

            for (int i = 0; i < 5; i++)
            {
                Label titleLabel = new Label();
                Label sizeLabel = new Label();
                Label descriptionLabel = new Label(); // Corrected the variable name
                Button downloadButton = new Button();

                downloadButton.Text = "Download";
                downloadButton.Click += DownloadButton_Click;
                downloadButton.Visible = false;

                tableLayoutPanel2.Controls.Add(titleLabel, 0, i);
                tableLayoutPanel2.Controls.Add(sizeLabel, 1, i);
                tableLayoutPanel2.Controls.Add(descriptionLabel, 2, i); // Corrected the index
                tableLayoutPanel2.Controls.Add(downloadButton, 3, i);


                _titleControls.Add(titleLabel);
                _sizeControls.Add(sizeLabel);
                _descriptionControls.Add(descriptionLabel);
                _downloadControls.Add(downloadButton);


            }

        }

        private void search_Click(object sender, EventArgs e)
        {
            List<TorrentFile> results = _torrentFileServices.SearchTorrentFiles(searchBar.Text, ref _resultMaxPage, ref _searchOnFlag, _storage.GetAllTorrentFiles());
            Show(_resultPage, results);

            _storage.GetResultTorrentFiles().Clear();
            _storage.GetResultTorrentFiles().AddRange(results);
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            _searchOnFlag = false;
            Show(_allPage, _storage.GetAllTorrentFiles());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_searchOnFlag)
            {
                if (_allPage - 1 >= 0)
                {
                    _allPage--;
                    pagelabel.Text = "Page Number " + _allPage.ToString();
                }
                Show(_allPage, _storage.GetAllTorrentFiles());
            }
            else
            {
                if (_resultPage - 1 >= 0)
                {
                    _resultPage--;
                    pagelabel.Text = "Page Number " + _resultPage.ToString();
                }
                Show(_resultPage, _storage.GetResultTorrentFiles());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!_searchOnFlag)
            {
                if (_allPage + 1 < _allMaxPage)
                {
                    _allPage++;
                    pagelabel.Text = "Page Number " + _allPage.ToString();
                }
                Show(_allPage, _storage.GetAllTorrentFiles());
            }
            else
            {
                if (_resultPage + 1 < _resultMaxPage)
                {
                    _resultPage++;
                    pagelabel.Text = "Page Number " + _resultPage.ToString();
                }
                Show(_resultPage, _storage.GetResultTorrentFiles());
            }

        }

        void Show(int i, List<TorrentFile> torrentFiles)
        {
            List<TorrentFile> disable = StatusDownloadButton();
            int row = i * 5;
            for (int index = 0; index < _titleControls.Count; index++)
            {
                Control titleControl = _titleControls[index];
                Control sizeControl = _sizeControls[index];
                Control descriptionControl = _descriptionControls[index];
                Control downloadButtonControl = _downloadControls[index];

                if (index + row < torrentFiles.Count)
                {
                    if (titleControl != null)
                    {
                        titleControl.Text = torrentFiles[index + row].info.torrentName;
                    }

                    if (sizeControl != null)
                    {
                        sizeControl.Text = _commonUtils.FormatFileSize(torrentFiles[index + row].info.length);
                    }

                    if (descriptionControl != null)
                    {
                        descriptionControl.Text = torrentFiles[index + row].info.description;
                    }

                    if (downloadButtonControl != null)
                    {
                        downloadButtonControl.Visible = true;
                    }
                }
                else
                {
                    // If there are no more items in torrentFiles, clear the text of the controls


                    if (titleControl != null)
                    {
                        titleControl.Text = "";
                    }

                    if (sizeControl != null)
                    {
                        sizeControl.Text = "";
                    }

                    if (descriptionControl != null)
                    {
                        descriptionControl.Text = "";
                    }

                    if (downloadButtonControl != null)
                    {
                        downloadButtonControl.Visible = false;
                    }
                }
                if (_torrentDownloadingNames.Count != 0)
                {
                    foreach (string name in _torrentDownloadingNames)
                    {
                        if (titleControl.Text == name)
                        {
                            _downloadControls[index].Enabled = false;
                            break;
                        }
                        if (titleControl.Text != name)
                        {
                            _downloadControls[index].Enabled = true;
                        }

                    }
                }

            }
        }
        private List<TorrentFile> StatusDownloadButton()

        {
            if (tableLayoutPanel1.RowCount == 1)
            {
                return null;
            }
            List<string> downloadingTorrentsNames = new List<string>();
            List<TorrentFile> torrentFiles = new List<TorrentFile>();
            if (_searchOnFlag)
            {
                torrentFiles = _storage.GetResultTorrentFiles();
            }
            else
            {
                torrentFiles = _storage.GetAllTorrentFiles();
            }
            for (int i = 0; i < tableLayoutPanel1.RowCount - 1; i++)
            {
                downloadingTorrentsNames.Add(tableLayoutPanel1.GetControlFromPosition(0, i).Text);
            }
            List<TorrentFile> downloading = new List<TorrentFile>();
            foreach (TorrentFile torrent in torrentFiles)
            {
                foreach (string s in downloadingTorrentsNames)
                    if (torrent.info.fileName == s)
                    {
                        downloading.Add(torrent);
                    }
            }
            return downloading;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                _torrentFileServices.LoadData(_storage, this, ref _allMaxPage);
            }
            if (tabControl1.SelectedIndex == 3)
            {
                _commonUtils.ReceateTorrentFileForDownloadedFile(_storage, "770c27b920265cd2b0f0e579418e212d2f7ff26c672834d70697daf42a9852f5", this);
            }
        }

        // Downloading torrents tab..
        public void DownloadButton_Click(object sender, EventArgs e)
        {
            Button downloadButton = (Button)sender;
            _storage.GetPeerWithMyFaile();
            if (!(sender as Control).Enabled)
            {
                return;
            }

            downloadButton.Enabled = false;

            int rowIndex = tableLayoutPanel2.GetRow(downloadButton); // Get the row index of the clicked button
            Label torrentNameLabel = (Label)tableLayoutPanel2.GetControlFromPosition(0, rowIndex);
            Label sizeLabel = (Label)tableLayoutPanel2.GetControlFromPosition(1, rowIndex);

            Label label1 = new Label();
            label1.Text = torrentNameLabel.Text;

            List<TorrentFile> torrentFiles = _torrentFileServices.SearchTorrentFiles(searchBar.Text, ref _resultMaxPage, ref _searchOnFlag, _storage.GetAllTorrentFiles());

            Label label2 = new Label();
            label2.Text = _commonUtils.FormatFileSize(torrentFiles[0].info.length);//((long)sizeLabel.Text.ToString);
            _storage.GetDownloadTorrentFiles().AddRange(torrentFiles);

            _storage.GetDownloadTorrentFiles().Add(torrentFiles[0]);

            ProgressBar progressBar = new ProgressBar();

            Button button = new Button();
            button.Text = "Pause";

            // Create a new row
            tableLayoutPanel1.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));

            // Move the existing controls to the next row
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                int row = tableLayoutPanel1.GetRow(control);
                tableLayoutPanel1.SetRow(control, row + 1);
            }

            // Insert the new controls into the first row
            tableLayoutPanel1.Controls.Add(label1, 0, 0); // Add label1 to the first column of the first row
            tableLayoutPanel1.Controls.Add(label2, 1, 0); // Add label2 to the second column of the first row
            tableLayoutPanel1.Controls.Add(progressBar, 2, 0); // Add progressBar to the third column of the first row
            tableLayoutPanel1.Controls.Add(button, 3, 0); // Add button to the fourth column of the first row

            // Increment the row count
            tableLayoutPanel1.RowCount++;
            PTTBlock block = new PTTBlock(0x06, torrentFiles.First().info.checksum.Length, torrentFiles.First().info.checksum);
            List<string> receivedLivePeers = _connections.SendAndRecieveData06(block, this).ToList();

            _downloader.Download(torrentFiles.First(), receivedLivePeers);
            //_torrentFileServices.StartDownload(_connections, this, _storage, _sharedFileServices, _networkUtils);
            _torrentDownloadingNames.Add(label1.Text);
        }
        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<TorrentFile> results = _torrentFileServices.SearchTorrentFiles(searchBar.Text, ref _resultMaxPage, ref _searchOnFlag, _storage.GetAllTorrentFiles());
                Show(_resultPage, results);

                _storage.GetResultTorrentFiles().Clear();
                _storage.GetResultTorrentFiles().AddRange(results);

                // Optionally, you can prevent the "Enter" key from adding a newline to the TextBox
                e.SuppressKeyPress = true;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string trackerIpField;
            int trackerPortField;

            (trackerIpField, trackerPortField) = _networkUtils.SplitIpAndPort(this);

            _udpSender.Start(trackerIP.Text.Trim());

            _connections.AnnounceNewPeer(trackerIpField, trackerPortField);
        }

        private void createNewTorrent_Click(object sender, EventArgs e)
        {
            FormNewTorrent formNewTorrent = new FormNewTorrent(this, _networkUtils, _commonUtils);
            formNewTorrent.ShowDialog();
        }

        public string TextForAnnoncer()
        {
            return trackerIP.Text;
        }

        private void buhTorrent_Click(object sender, EventArgs e)
        {

        }

        public string GetIpFieldText()
        {
            return trackerIP.Text.Trim();
        }
    }
}
