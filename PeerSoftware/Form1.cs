using PeerSoftware.Download;
using PeerSoftware.Services;
using PeerSoftware.Storage;
using PeerSoftware.UDP;
using PeerSoftware.Upload;
using PeerSoftware.Download;
using System.Drawing;
using Microsoft.VisualBasic;
using Timer = System.Windows.Forms.Timer;
using MaterialSkin.Controls;

using PeerSoftware.Utils;
using PTT_Parser;
using System.Windows.Forms;
using System.Net.Sockets;

namespace PeerSoftware
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkin.MaterialSkinManager _materialSkinManager;

        private CustomMessageBox _customMessageBox;

        private List<MaterialLabel> _materialTitleControls = new List<MaterialLabel>();
        private List<MaterialLabel> _materialSizeControls = new List<MaterialLabel>();
        private List<MaterialLabel> _materialDescriptionControls = new List<MaterialLabel>();
        private List<MaterialButton> _materialDownloadControls = new List<MaterialButton>();

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

        private ContextMenuStrip _systemTrayContextMenu;

        public Form1()
        {
            InitializeComponent();


            // New UI Stuff
            _materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;

            _materialSkinManager.EnforceBackcolorOnAllComponents = false;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            _materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Green600,
                MaterialSkin.Primary.Green700,
                MaterialSkin.Primary.Blue900,
                MaterialSkin.Accent.Purple700,
                MaterialSkin.TextShade.WHITE);

            UILightMode();

            FormClosing += MainForm_FormClosing;

            _systemTrayContextMenu = new ContextMenuStrip();

            notifyIcon1.Text = Application.ProductName;
            //notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon1.BalloonTipTitle = Application.ProductName;
            notifyIcon1.BalloonTipText = $"{Application.ProductName} is minimized";
            notifyIcon1.ContextMenuStrip = _systemTrayContextMenu;
            notifyIcon1.MouseClick += NotifyIcon_MouseClick;


            _systemTrayContextMenu.Items.Add("Settings", null, OnMenuItem1Clicked);
            _systemTrayContextMenu.Items.Add("Close App", null, OnMenuItem2Clicked);


            _storage = new TorrentStorage();
            _connections = new Connections();
            _torrentFileServices = new TorrentFileServices();
            _sharedFileServices = new SharedFileServices();
            _commonUtils = new CommonUtils();
            _networkUtils = new NetworkUtils();
            _udpSender = new UDPSender(_networkUtils);

            _customMessageBox = new CustomMessageBox(this);

            /*            comboBoxTheme.Items.Add("Lime with Blue Accent");
                        comboBoxTheme.Items.Add("Blue-Grey with Light Blue Accent");
                        comboBoxTheme.Items.Add("Indigo with Pink Accent");
                        comboBoxTheme.Items.Add("Teal with Amber Accent");
                        comboBoxTheme.Items.Add("Deep Purple with Orange Accent");
                        comboBoxTheme.Items.Add("Blue with Yellow Accent");
                        comboBoxTheme.Items.Add("Green with Lime Accent");*/


            foreach (var themeName in _commonUtils.themeKeyMapping.Keys)
            {
                comboBoxTheme.Items.Add(themeName);
            }




            // Create the TableLayoutPanel for the heading row
            TableLayoutPanel headingTableLayoutPanel = new TableLayoutPanel();

            headingTableLayoutPanel.ColumnCount = 3;

            // Create the heading labels
            Label nameLabel = new Label();
            nameLabel.Text = "Name1";


            comboBoxTheme.SelectedItem = "Lime with Purple Accent";

            UploadPeerServer uploadserver = new UploadPeerServer(_storage);

            Thread peerThread = new Thread(uploadserver.Start);

            peerThread.Start();

            _downloader = new Downloader();

            for (int i = 0; i < 5; i++)
            {
                MaterialLabel materialTitleLabel = new MaterialLabel();
                MaterialLabel materialSizeLabel = new MaterialLabel();
                MaterialLabel materialDescriptionLabel = new MaterialLabel();
                MaterialButton materialDownloadButton = new MaterialButton();

                materialDownloadButton.Visible = false;
                materialDownloadButton.Text = "Download";
                materialDownloadButton.Click += DownloadButton_Click;
                materialDownloadButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\download.png");
                materialDownloadButton.Anchor = AnchorStyles.None;

                tableLayoutPanel2.Controls.Add(materialTitleLabel, 0, i);
                tableLayoutPanel2.Controls.Add(materialSizeLabel, 1, i);
                tableLayoutPanel2.Controls.Add(materialDescriptionLabel, 2, i);
                tableLayoutPanel2.Controls.Add(materialDownloadButton, 3, i);

                _materialTitleControls.Add(materialTitleLabel);
                _materialSizeControls.Add(materialSizeLabel);
                _materialDescriptionControls.Add(materialDescriptionLabel);
                _materialDownloadControls.Add(materialDownloadButton);
            }

        }

        private void OnMenuItem1Clicked(object? sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            tabControl1.SelectedIndex = 3;
            Show();

            notifyIcon1.Visible = false;
        }

        private void OnMenuItem2Clicked(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        public ITorrentStorage GetTorrentStorage()
        {
            return _storage;
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
            _allMaxPage = (int)Math.Ceiling(_storage.GetAllTorrentFiles().Count / 5.0);
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

        private void Show(int i, List<TorrentFile> torrentFiles)
        {
            int row = i * 5;

            for (int index = 0; index < _materialTitleControls.Count; index++)
            {
                MaterialLabel materialTitleControl = _materialTitleControls[index];
                MaterialLabel materialSizeControl = _materialSizeControls[index];
                MaterialLabel materialDescriptionControl = _materialDescriptionControls[index];
                MaterialButton materialButtonControl = _materialDownloadControls[index];

                if (index + row < torrentFiles.Count)
                {
                    if (materialTitleControl != null)
                    {
                        materialTitleControl.Text = torrentFiles[index + row].info.torrentName;
                    }

                    if (materialSizeControl != null)
                    {
                        materialSizeControl.Text = _commonUtils.FormatFileSize(torrentFiles[index + row].info.length);
                    }

                    if (materialDescriptionControl != null)
                    {
                        materialDescriptionControl.Text = torrentFiles[index + row].info.description;
                    }

                    if (materialButtonControl != null)
                    {
                        materialButtonControl.Visible = true;
                    }
                }
                else
                {
                    if (materialTitleControl != null)
                    {
                        materialTitleControl.Text = "";
                    }

                    if (materialSizeControl != null)
                    {
                        materialSizeControl.Text = "";
                    }

                    if (materialDescriptionControl != null)
                    {
                        materialDescriptionControl.Text = "";
                    }

                    if (materialButtonControl != null)
                    {
                        materialButtonControl.Visible = false;
                    }
                }
                if (_torrentDownloadingNames.Count != 0)
                {
                    foreach (string name in _torrentDownloadingNames)
                    {
                        if (materialTitleControl.Text == name)
                        {
                            _materialDownloadControls[index].Enabled = false;
                            break;
                        }
                        if (materialTitleControl.Text != name)
                        {
                            _materialDownloadControls[index].Enabled = true;
                        }

                    }
                }

            }
        }

        /*
          private void Show(int i, List<TorrentFile> torrentFiles)
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
         */

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                _torrentFileServices.LoadData(_storage, this);
            }
            if (tabControl1.SelectedIndex == 2)
            {
                Thread.Sleep(100);
                await Task.Yield();
                ShowMyTorrents();
            }
        }

        private async void ShowMyTorrents()
        {
            List<TorrentFile> temp = new List<TorrentFile>();

            while (tableLayoutPanel4.Controls.Count > 0)
            {
                tableLayoutPanel4.Controls[0].Dispose();

                temp.Clear();
            }

            temp = await Task.Run(() => _commonUtils.LoadMyTorrents(_storage));

            Thread.Sleep(100);

            foreach (TorrentFile torrentFile in temp)
            {
                MaterialLabel materialMyTorrentName = new MaterialLabel();
                materialMyTorrentName.Text = torrentFile.info.torrentName;

                MaterialLabel materialMyTorrentDescription = new MaterialLabel();
                materialMyTorrentDescription.Text = torrentFile.info.description;

                MaterialLabel materialMyTorrentSize = new MaterialLabel();
                materialMyTorrentSize.Text = _commonUtils.FormatFileSize(torrentFile.info.length);

                MaterialButton materialMyTorrentDownloadButton = new MaterialButton();
                materialMyTorrentDownloadButton.Text = "Delete";
                materialMyTorrentDownloadButton.Anchor = AnchorStyles.Top;
                materialMyTorrentDownloadButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\delete.png");
                materialMyTorrentDownloadButton.Click += DeleteMyTorrentButton_Click;

                tableLayoutPanel4.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));

                foreach (Control control in tableLayoutPanel4.Controls)
                {
                    int row = tableLayoutPanel4.GetRow(control);
                    tableLayoutPanel4.SetRow(control, row + 1);
                }

                tableLayoutPanel4.Controls.Add(materialMyTorrentName, 0, 0);
                tableLayoutPanel4.Controls.Add(materialMyTorrentSize, 1, 0);
                tableLayoutPanel4.Controls.Add(materialMyTorrentDescription, 2, 0);
                tableLayoutPanel4.Controls.Add(materialMyTorrentDownloadButton, 3, 0);
            }
        }


        public void DeleteMyTorrentButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int rowIndex = tableLayoutPanel4.GetRow(deleteButton);
            Label torrentName = (Label)tableLayoutPanel4.GetControlFromPosition(0, rowIndex);
            List<TorrentFile> torrentFiles = _torrentFileServices
                .SearchTorrentFiles(torrentName.Text, ref _resultMaxPage, ref _searchOnFlag, _storage.GetMyTorrentFiles());

            string payload = $"{_networkUtils.GetLocalIPAddress()}:{_networkUtils.GetLocalPort()}|{torrentFiles.First().info.checksum}";
            string trackerIp;
            int trackerPort;
            (trackerIp, trackerPort) = _networkUtils.SplitIpAndPort(this);
            TcpClient tcpClient = new TcpClient(trackerIp, trackerPort);
            _connections.SendPTTMessage(tcpClient, 0x03, payload);

            string folderPath = $@"{Directory.GetCurrentDirectory()}\\MyTorrent\\{torrentName.Text}.json";

            _customMessageBox.SetTitle("Delete Confirmation");
            _customMessageBox.SetMessageText($"Do you want to delete {torrentName.Text}.json?");

            if (_customMessageBox.ShowDialog() == DialogResult.Yes)
            {
                _customMessageBox.SetTitle("Delete Confirmation");
                _customMessageBox.SetMessageText($"Do you want to delete shared file also?");
                if ( File.Exists(torrentFiles.First().info.fileName) && _customMessageBox.ShowDialog() == DialogResult.Yes)
                {
                    File.Delete(torrentFiles.First().info.fileName);
                }
                if( File.Exists(folderPath))
                {
                    File.Delete(folderPath);
                }
                ShowMyTorrents();
            }

            //DialogResult result = MessageBox.Show($"Do you want to delete {torrentName.Text}.json?", "Confirmation", MessageBoxButtons.YesNo);
            /*
            if (result == DialogResult.Yes)
            {
                File.Delete(folderPath);

                ShowMyTorrents();
            }
            */
        }

        // Downloading torrents tab..
        public void DownloadButton_Click(object sender, EventArgs e)
        {
            MaterialButton downloadButton = (MaterialButton)sender;

            _storage.GetPeerWithMyFaile();

            if (!(sender as Control).Enabled)
            {
                return;
            }

            downloadButton.Enabled = false;

            int rowIndex = tableLayoutPanel2.GetRow(downloadButton); // Get the row index of the clicked button
            MaterialLabel torrentNameLabel = (MaterialLabel)tableLayoutPanel2.GetControlFromPosition(0, rowIndex);
            MaterialLabel sizeLabel = (MaterialLabel)tableLayoutPanel2.GetControlFromPosition(1, rowIndex);

            MaterialLabel label1 = new MaterialLabel();
            label1.Text = torrentNameLabel.Text;

            List<TorrentFile> torrentFiles = _torrentFileServices.SearchTorrentFiles(label1.Text, ref _resultMaxPage, ref _searchOnFlag, _storage.GetAllTorrentFiles());

            MaterialLabel label2 = new MaterialLabel();
            label2.Text = _commonUtils.FormatFileSize(torrentFiles[0].info.length);//((long)sizeLabel.Text.ToString);
            _storage.GetDownloadTorrentFiles().AddRange(torrentFiles);

            _storage.GetDownloadTorrentFiles().Add(torrentFiles[0]);

            MaterialProgressBar progressBar = new MaterialProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Height = 100;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            MaterialButton button = new MaterialButton();
            button.Text = "Pause";
            button.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\pause.png");
            button.Size = new Size(200, 200);
            button.Anchor = AnchorStyles.None;

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
            List<string> receivedLivePeers = _connections.SendAndRecieveData06(block, this); // LIVEPEERS broke here

            _downloader.Download(torrentFiles.First(), receivedLivePeers, progressBar, _networkUtils, this);

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

            ShowMyTorrents();
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

        public static void SetProgressBarValue(MaterialProgressBar progressBar, int count)
        {
            progressBar.Value = count;
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTheme.SelectedItem != null)
            {
                string selectedTheme = comboBoxTheme.SelectedItem.ToString();

                if (_commonUtils.themeKeyMapping.TryGetValue(selectedTheme, out string selectedThemeKey))
                {
                    MaterialSkin.ColorScheme selectedColorScheme = _commonUtils.LoadTheme(selectedThemeKey);

                    _materialSkinManager.ColorScheme = selectedColorScheme;
                    UILightMode();

                    Refresh();
                }
            }
        }

        private void darkModeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (darkModeSwitch.Checked)
            {
                UIDarkMode();
            }
            else
            {
                UILightMode();
            }
        }

        private void UILightMode()
        {
            _materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;

            panel1.BackColor = Color.FromArgb(240, 240, 240);

            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel4.BackColor = Color.White;
            tableLayoutPanel5.BackColor = Color.White;
            tableLayoutPanel6.BackColor = Color.White;
            tableLayoutPanel7.BackColor = Color.White;

            settingsTabTrackerGroupBox.ForeColor = Color.Black;
            settingsTabClientGroupBox.ForeColor = Color.Black;
            settingsTabTrackerGroupBox.BackColor = Color.White;
            settingsTabClientGroupBox.BackColor = Color.White;

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabPage.BackColor = Color.White;
            }

            /*
             tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel4.BackColor = Color.White;
            tableLayoutPanel5.BackColor = Color.White;
            tableLayoutPanel6.BackColor = Color.White;
            tableLayoutPanel7.BackColor = Color.White;

            settingsTabTrackerGroupBox.BackColor = Color.White;
            settingsTabClientGroupBox.BackColor = Color.White;

            foreach (Control control in tableLayoutPanel7.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    label.BackColor = Color.White;
                }
            }

            foreach (Control control in tableLayoutPanel6.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    label.BackColor = Color.White;
                }
            }

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabPage.BackColor = Color.White;
            }
             */
        }

        private void UIDarkMode()
        {
            _materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;

            Color darkColor = Color.FromArgb(50, 50, 50);

            panel1.BackColor = Color.FromArgb(240, 240, 240);
            panel1.Location = new Point(492, 67);
            panel1.Size = new Size(404, 37);

            tableLayoutPanel1.BackColor = darkColor;
            tableLayoutPanel2.BackColor = darkColor;
            tableLayoutPanel4.BackColor = darkColor;
            tableLayoutPanel5.BackColor = darkColor;
            tableLayoutPanel6.BackColor = darkColor;
            tableLayoutPanel7.BackColor = darkColor;

            settingsTabTrackerGroupBox.ForeColor = Color.White;
            settingsTabClientGroupBox.ForeColor = Color.White;

            settingsTabTrackerGroupBox.BackColor = darkColor;
            settingsTabClientGroupBox.BackColor = darkColor;

            //UpdateBackgroundColors
        }
        /*
        private void UpdateBackgroundColors()
        {
            Color darkBackground = Color.FromArgb(38, 50, 56); // Your desired background colo

            settingsTabTrackerGroupBox.BackColor = darkBackground;
            settingsTabClientGroupBox.BackColor = darkBackground;

            tableLayoutPanel1.BackColor = darkBackground;
            tableLayoutPanel2.BackColor = darkBackground;
            tableLayoutPanel4.BackColor = darkBackground;
            tableLayoutPanel5.BackColor = darkBackground;
            tableLayoutPanel6.BackColor = darkBackground;
            tableLayoutPanel7.BackColor = darkBackground;

            // Iterate through controls and set their background color
            foreach (Control control in this.Controls)
            {
                control.BackColor = darkBackground;

                // Check for nested controls
                if (control.HasChildren)
                {
                    foreach (Control nestedControl in control.Controls)
                    {
                        nestedControl.BackColor = darkBackground;
                        // You might need further checks or customization depending on your control hierarchy
                    }
                }
            }

            foreach (Control control in tableLayoutPanel7.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    label.BackColor = darkBackground;
                }
            }

            foreach (Control control in tableLayoutPanel6.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    label.BackColor = darkBackground;
                }
            }

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabPage.BackColor = darkBackground;
            }
        }
        */

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Normal;
                Show();

                notifyIcon1.Visible = false;
            }
        }
    }
}