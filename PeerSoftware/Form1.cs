using MaterialSkin.Controls;
using Microsoft.Win32;
using PeerSoftware.Download;
using PeerSoftware.Services;
using PeerSoftware.Storage;
using PeerSoftware.UDP;
using PeerSoftware.Upload;
using PeerSoftware.Utils;
using PTT_Parser;
using System.Configuration;
using System.Net.Sockets;
using System.Text.Json;

namespace PeerSoftware
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkin.MaterialSkinManager _materialSkinManager;

        private CustomMessageBoxYesNo _customMessageBoxYesNo;
        private CustomMessageBoxOK _customMessageBoxOK;

        private List<MaterialLabel> _materialTitleControls = new List<MaterialLabel>();
        private List<MaterialLabel> _materialSizeControls = new List<MaterialLabel>();
        private List<MaterialLabel> _materialDescriptionControls = new List<MaterialLabel>();
        private List<MaterialButton> _materialDownloadControls = new List<MaterialButton>();

        private List<string> _torrentDownloadingNames = new List<string>();
        private int _allPage = 0;
        private int _allMaxPage = 0;

        private int _nPeersUploading;
        private int _nParallelDownloads;
        private string _sharedFileDownloadFolder;
        private string _serverSocket;

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

        private Configuration _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private ContextMenuStrip _systemTrayContextMenu;

        public Form1()
        {
            InitializeComponent();
            Logger.ClearLogFile();

            Logger.d($"Class -> {GetType().Name} | Method -> Form1()");

            // New UI Stuff
            _materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;

            _materialSkinManager.EnforceBackcolorOnAllComponents = false;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            /*            _materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                            MaterialSkin.Primary.Green600,
                            MaterialSkin.Primary.Green700,
                            MaterialSkin.Primary.Blue900,
                            MaterialSkin.Accent.Purple700,
                            MaterialSkin.TextShade.WHITE);*/

            //UILightMode();

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
            _torrentFileServices = new TorrentFileServices();
            _sharedFileServices = new SharedFileServices();
            _commonUtils = new CommonUtils();
            _networkUtils = new NetworkUtils();
            _connections = new Connections(_networkUtils);
            _udpSender = new UDPSender(_networkUtils);
            _customMessageBoxYesNo = new CustomMessageBoxYesNo(this);
            _customMessageBoxOK = new CustomMessageBoxOK();

            /*            comboBoxTheme.Items.Add("Lime with Blue Accent");
                        comboBoxTheme.Items.Add("Blue-Grey with Light Blue Accent");
                        comboBoxTheme.Items.Add("Indigo with Pink Accent");
                        comboBoxTheme.Items.Add("Teal with Amber Accent");
                        comboBoxTheme.Items.Add("Deep Purple with Orange Accent");
                        comboBoxTheme.Items.Add("Blue with Yellow Accent");
                        comboBoxTheme.Items.Add("Green with Lime Accent");*/

            comboBoxTheme.SelectedIndexChanged += ComboBoxTheme_SelectedIndexChanged;

            foreach (var themeName in _commonUtils.themeKeyMapping.Keys)
            {
                comboBoxTheme.Items.Add(themeName);
            }

            SetHelp();
            //settings

            _serverSocket = ConfigurationManager.AppSettings["serverSocket"];

            if (!(ConfigurationManager.AppSettings["downloadSharedFileLocation"] == "noPath"))
            {
                materialTextBox22.Text = ConfigurationManager.AppSettings["downloadSharedFileLocation"];
            }
            else
            {
                materialTextBox22.Text = $@"{Directory.GetCurrentDirectory()}\Download";
            }

            materialTextBox21.Text = ConfigurationManager.AppSettings["serverSocket"];

            int.TryParse(ConfigurationManager.AppSettings["peersUpoading"], out _nPeersUploading);
            maxDownloadsFromPeersSlider.Value = _nPeersUploading;

            int.TryParse(ConfigurationManager.AppSettings["peersDownloading"], out _nParallelDownloads);
            maxActiveDownloadsSlider.Value = _nParallelDownloads;


            string selectedTheme = ConfigurationManager.AppSettings["theme"].ToString();
            MaterialSkin.ColorScheme selectedColorScheme = _commonUtils.LoadTheme(selectedTheme);
            _materialSkinManager.ColorScheme = selectedColorScheme;
            comboBoxTheme.SelectedItem = selectedTheme;

            //comboBoxTheme.SelectedValue = ConfigurationManager.AppSettings["theme"];


            // Create the TableLayoutPanel for the heading row
            TableLayoutPanel headingTableLayoutPanel = new TableLayoutPanel();

            headingTableLayoutPanel.ColumnCount = 3;

            // Create the heading labels
            Label nameLabel = new Label();
            nameLabel.Text = "Name1";

            _commonUtils.LoadMyTorrents(_storage);

            UploadPeerServer uploadserver = new UploadPeerServer(_storage);
            Thread peerThread = new Thread(uploadserver.Start);

            peerThread.Start();

            _downloader = new Downloader();

            for (int i = 0; i < 5; i++)
            {
                MaterialLabel materialTitleLabel = new MaterialLabel();
                materialTitleLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                materialTitleLabel.AutoSize = true;
                MaterialLabel materialSizeLabel = new MaterialLabel();
                materialSizeLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                materialSizeLabel.AutoSize = true;
                MaterialLabel materialDescriptionLabel = new MaterialLabel();
                materialDescriptionLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                materialDescriptionLabel.AutoSize = true;
                MaterialButton materialDownloadButton = new MaterialButton();

                materialDownloadButton.Visible = false;
                materialDownloadButton.Text = "Download";
                materialDownloadButton.Click += DownloadButton_Click;
                materialDownloadButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\download.png");
                materialDownloadButton.Anchor = AnchorStyles.None;

                materialTitleLabel.AutoSize = true;

                tableLayoutPanel2.Controls.Add(materialTitleLabel, 0, i);
                tableLayoutPanel2.Controls.Add(materialSizeLabel, 1, i);
                tableLayoutPanel2.Controls.Add(materialDescriptionLabel, 2, i);
                tableLayoutPanel2.Controls.Add(materialDownloadButton, 3, i);

                _materialTitleControls.Add(materialTitleLabel);
                _materialSizeControls.Add(materialSizeLabel);
                _materialDescriptionControls.Add(materialDescriptionLabel);
                _materialDownloadControls.Add(materialDownloadButton);
            }



            try
            {
                if (materialTextBox21.Text != null)
                {
                    string[] ip = materialTextBox21.Text.Split(':', 2);
                    int.TryParse(ip[1], out int int_port);
                    _connections.AnnounceNewPeer(ip[0], int_port);
                    if (_connections.IsConnected() == true)
                    {
                        save.Text = "CONNECTED";
                        _udpSender.Start(_serverSocket);
                        Task.Run(() => _commonUtils.AnonceMyTorrents_OnStartUp(_storage, _networkUtils, this));
                        Resume_OnStartUp();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            _configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings"); // Refresh the appSettings section
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (ConfigurationManager.AppSettings["darkMode"] == "true")
            {
                darkModeSwitch.Checked = true;

                UIDarkMode();
                Refresh();
            }
            else
            {
                darkModeSwitch.Checked = false;

                UILightMode();
                Refresh();
            }

            if (ConfigurationManager.AppSettings["startMinimized"] == "true")
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;

                startMinimizedCheckbox.Checked = true;
            }
            else
            {
                startMinimizedCheckbox.Checked = false;
            }

            if (ConfigurationManager.AppSettings["startWithWindows"] == "true")
            {
                _configuration.AppSettings.Settings["startWithWindows"].Value = "true";
                startupCheckbox.Checked = true;

                SetStartup(true);
            }
            else
            {
                _configuration.AppSettings.Settings["startWithWindows"].Value = "false";
                startupCheckbox.Checked = false;

                SetStartup(false);
            }
        }

        public void SetStartup(bool isChecked)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            string appName = Application.ProductName;
            string executablePath = Application.ExecutablePath;

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (isChecked)
            {
                rk.SetValue(appName, executablePath);

                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            else
            {
                rk.DeleteValue(appName, false);
            }
        }


        private void ComboBoxTheme_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (comboBoxTheme.SelectedItem != null)
            {
                string selectedTheme = comboBoxTheme.SelectedItem.ToString();

                if (_commonUtils.themeKeyMapping.TryGetValue(selectedTheme, out string selectedThemeKey))
                {
                    MaterialSkin.ColorScheme selectedColorScheme = _commonUtils.LoadTheme(selectedThemeKey);

                    _materialSkinManager.ColorScheme = selectedColorScheme;

                    if (!darkModeSwitch.Checked)
                    {
                        FixLightUIBackgrounds();
                        Refresh();
                    }
                }

                _configuration.AppSettings.Settings["theme"].Value = selectedTheme;
            }
        }

        public string GetSharedFileDownloadFolder()
        {
            return _sharedFileDownloadFolder = materialTextBox22.Text;
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

        public int GetNPeersUploading()
        {
            return _nPeersUploading;
        }

        public ITorrentStorage GetTorrentStorage()
        {
            return _storage;
        }

        private void search_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            List<TorrentFile> results = _torrentFileServices.SearchTorrentFiles(searchBar.Text, ref _resultMaxPage, ref _searchOnFlag, _storage.GetAllTorrentFiles());
            Show(_resultPage, results);

            _storage.GetResultTorrentFiles().Clear();
            _storage.GetResultTorrentFiles().AddRange(results);
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            _searchOnFlag = false;
            _allMaxPage = (int)Math.Ceiling(_storage.GetAllTorrentFiles().Count / 5.0);
            Show(_allPage, _storage.GetAllTorrentFiles());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (!_searchOnFlag)
            {
                if (_allPage - 1 >= 0)
                {
                    _allPage--;
                    newPageLabel.Text = "Page Number " + _allPage.ToString();
                }
                Show(_allPage, _storage.GetAllTorrentFiles());
            }
            else
            {
                if (_resultPage - 1 >= 0)
                {
                    _resultPage--;
                    newPageLabel.Text = "Page Number " + _resultPage.ToString();
                }
                Show(_resultPage, _storage.GetResultTorrentFiles());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (!_searchOnFlag)
            {
                if (_allPage + 1 < _allMaxPage)
                {
                    _allPage++;
                    newPageLabel.Text = "Page Number " + _allPage.ToString();
                }
                Show(_allPage, _storage.GetAllTorrentFiles());
            }
            else
            {
                if (_resultPage + 1 < _resultMaxPage)
                {
                    _resultPage++;
                    newPageLabel.Text = "Page Number " + _resultPage.ToString();
                }
                Show(_resultPage, _storage.GetResultTorrentFiles());
            }

        }

        private void Show(int i, List<TorrentFile> torrentFiles)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (torrentFiles.Count == 0)
            {
                MaterialLabel materialDescriptionControl = _materialTitleControls[0];
                materialDescriptionControl.Text = "No torrents";
                return;
            }

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

        private void ClearAndShowMyTorrents()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (tabControl1.SelectedIndex == 1 && _connections.IsConnected() == true)
            {
                _torrentFileServices.LoadData(_storage, _networkUtils, this);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                tableLayoutPanel4.Controls.Clear();
                tableLayoutPanel4.RowStyles.Clear();
                tableLayoutPanel4.RowCount = 0;
                tableLayoutPanel4.SuspendLayout();
                ShowMyTorrents();
                tableLayoutPanel4.ResumeLayout();
            }
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAndShowMyTorrents();
        }

        private void ShowMyTorrents()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            List<TorrentFile> temp = _commonUtils.LoadMyTorrents(_storage);

            if (temp.Count == 0)
            {
                MaterialLabel materialMyTorrentName = new MaterialLabel();
                materialMyTorrentName.Text = "You don't have any torrents yet";

                materialMyTorrentName.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                materialMyTorrentName.AutoSize = true;
                tableLayoutPanel4.Controls.Add(materialMyTorrentName, 0, 0);

                return;
            }

            tableLayoutPanel4.SuspendLayout();

            tableLayoutPanel4.Controls.Clear();

            for (int i = 0; i < temp.Count; i++)
            {
                TorrentFile torrentFile = temp[i];

                MaterialLabel materialMyTorrentName = new MaterialLabel();
                materialMyTorrentName.Text = torrentFile.info.torrentName;
                materialMyTorrentName.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                materialMyTorrentName.AutoSize = true;

                MaterialLabel materialMyTorrentDescription = new MaterialLabel();
                materialMyTorrentDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

                materialMyTorrentDescription.Text = torrentFile.info.description;

                MaterialLabel materialMyTorrentSize = new MaterialLabel();
                materialMyTorrentSize.Text = _commonUtils.FormatFileSize(torrentFile.info.length);

                MaterialButton materialMyTorrentDownloadButton = new MaterialButton();
                materialMyTorrentDownloadButton.Text = "Delete";
                materialMyTorrentDownloadButton.Anchor = AnchorStyles.Top;
                materialMyTorrentDownloadButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\delete.png");
                materialMyTorrentDownloadButton.Click += DeleteMyTorrentButton_Click;

                int rowIndex = tableLayoutPanel4.RowCount++;
                tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                tableLayoutPanel4.Controls.Add(materialMyTorrentName, 0, rowIndex);
                tableLayoutPanel4.Controls.Add(materialMyTorrentSize, 1, rowIndex);
                tableLayoutPanel4.Controls.Add(materialMyTorrentDescription, 2, rowIndex);
                tableLayoutPanel4.Controls.Add(materialMyTorrentDownloadButton, 3, rowIndex);
            }

            tableLayoutPanel4.ResumeLayout();
        }

        public void DeleteMyTorrentButton_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            MaterialButton deleteButton = (MaterialButton)sender;
            int rowIndex = tableLayoutPanel4.GetRow(deleteButton);
            Label torrentName = (Label)tableLayoutPanel4.GetControlFromPosition(0, rowIndex);
            List<TorrentFile> torrentFiles = _torrentFileServices
                .SearchTorrentFiles(torrentName.Text, ref _resultMaxPage, ref _searchOnFlag, _storage.GetMyTorrentFiles());


            string folderPath = $@"{Directory.GetCurrentDirectory()}\\MyTorrent\\{torrentName.Text}.json";

            _customMessageBoxYesNo.SetTitle("Delete Confirmation");
            _customMessageBoxYesNo.SetMessageText($"Do you want to delete {torrentName.Text}.json?");



            // Create a new row
            tableLayoutPanel1.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));


            if (_customMessageBoxYesNo.ShowDialog() == DialogResult.Yes)
            {
                string payload = $"{_networkUtils.GetLocalIPAddress()}:{_networkUtils.GetLocalPort()}|{torrentFiles.First().info.checksum}";
                string trackerIp;
                int trackerPort;
                (trackerIp, trackerPort) = _networkUtils.SplitIpAndPort(this);
                TcpClient tcpClient = new TcpClient(trackerIp, trackerPort);
                _connections.SendPTTMessage(tcpClient, 0x03, payload);

                _customMessageBoxYesNo.SetTitle("Delete Confirmation");
                _customMessageBoxYesNo.SetMessageText($"Do you want to delete shared file also?");
                if (File.Exists(torrentFiles.First().info.fileName) && _customMessageBoxYesNo.ShowDialog() == DialogResult.Yes)
                {
                    File.Delete(torrentFiles.First().info.fileName);
                }
                if (File.Exists(folderPath))
                {
                    File.Delete(folderPath);
                }

                ClearAndShowMyTorrents();
            }

        }

        // Downloading torrents tab..
        public void DownloadButton_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            MaterialButton downloadButton = (MaterialButton)sender;

            _storage.GetPeerWithMyFaile();

            if (!(sender as Control).Enabled)
            {
                return;
            }

            int rowIndex = tableLayoutPanel2.GetRow(downloadButton); // Get the row index of the clicked button

            MaterialLabel torrentNameLabel = (MaterialLabel)tableLayoutPanel2.GetControlFromPosition(0, rowIndex);
            MaterialLabel sizeLabel = (MaterialLabel)tableLayoutPanel2.GetControlFromPosition(1, rowIndex);

            int idOfDownload = 0;
            if (_searchOnFlag)
            {
                idOfDownload = rowIndex + _resultPage * 5;
            }
            else
            {
                idOfDownload = rowIndex + _allPage * 5;
            }
            TorrentFile torrentFile = _storage.GetAllTorrentFiles()[idOfDownload];

            PTTBlock block = new PTTBlock(0x06, torrentFile.info.checksum.Length, torrentFile.info.checksum);
            List<string> receivedLivePeers = _connections.SendAndRecieveData06(block, this); // LIVEPEERS broke here

            if (receivedLivePeers.Count != 0)
            {
                downloadButton.Enabled = false;

                MaterialLabel label1 = new MaterialLabel();
                label1.Text = torrentNameLabel.Text;

                MaterialLabel label2 = new MaterialLabel();
                label2.Text = _commonUtils.FormatFileSize(torrentFile.info.length);//((long)sizeLabel.Text.ToString);
                _storage.GetDownloadTorrentFiles().Insert(0, torrentFile);


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
                button.Click += PauseResume_Click;

                // Create a new row
                tableLayoutPanel1.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));

                _storage.GetDownloadTorrentStatus().Add(_storage.GetDownloadTorrentStatus().Count, true);

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

                
                _downloader.Download(torrentFile, receivedLivePeers, progressBar, _networkUtils, this, 0);

                //_torrentFileServices.StartDownload(_connections, this, _storage, _sharedFileServices, _networkUtils);
                _torrentDownloadingNames.Add(label1.Text);
            } 
            else
            {
                _customMessageBoxOK.SetMessageText("There are no available peers who has the file.");
                _customMessageBoxOK.ShowDialog();
            }
        }

        private void PauseResume_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            MaterialButton pauseButton = (MaterialButton)sender;

            int rowIndex = tableLayoutPanel1.GetRow(pauseButton);

            TorrentFile torrentFile = _storage.GetDownloadTorrentFiles()[rowIndex];
            bool state = _storage.GetDownloadTorrentStatus().GetValueOrDefault(rowIndex);
            if (state)
            {
                _downloader.Pause(rowIndex);
                _storage.GetDownloadTorrentStatus()[rowIndex] = false;
                _storage.GetPausedTorrentFiles().Add(torrentFile);

                pauseButton.Text = "Resume";
                pauseButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\resume.png");
            }
            else
            {
                _storage.GetDownloadTorrentStatus()[rowIndex] = true;
                MaterialProgressBar progressBar = (MaterialProgressBar)tableLayoutPanel1.GetControlFromPosition(2, rowIndex);

                PTTBlock block = new PTTBlock(0x06, torrentFile.info.checksum.Length, torrentFile.info.checksum);
                List<string> receivedLivePeers = _connections.SendAndRecieveData06(block, this); // LIVEPEERS broke here

                if (receivedLivePeers.Count != 0)
                {
                    _storage.GetPausedTorrentFiles().Remove(torrentFile);
                    _downloader.Resume(torrentFile, receivedLivePeers, progressBar, _networkUtils, this, rowIndex);

                    pauseButton.Text = "Pause";
                    pauseButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\pause.png");
                }
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

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
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            string trackerIpField;
            int trackerPortField;

            (trackerIpField, trackerPortField) = _networkUtils.SplitIpAndPort(this);

            _udpSender.Start(materialTextBox21.Text.Trim());

            _configuration.AppSettings.Settings["serverSocket"].Value = materialTextBox21.Text.Trim();

            _connections.AnnounceNewPeer(trackerIpField, trackerPortField);
            if (_connections.IsConnected() == true)
            {
                Task.Run(() => _commonUtils.AnonceMyTorrents_OnStartUp(_storage, _networkUtils, this));
                save.Text = "CONNECTED";
            }
        }

        private void createNewTorrent_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            FormNewTorrent formNewTorrent = new FormNewTorrent(this, _networkUtils, _commonUtils);
            formNewTorrent.ShowDialog();

            ClearAndShowMyTorrents();
        }

        public string TextForAnnoncer()
        {
            return trackerIP.Text;
        }

        public int GetNParallelDownloads()
        {
            return _nParallelDownloads;
        }

        public string GetIpFieldText()
        {
            return trackerIP.Text.Trim();
        }

        public static void SetProgressBarValue(MaterialProgressBar progressBar, int count)
        {
            progressBar.Value = count;
        }

        private void darkModeSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (darkModeSwitch.Checked)
            {
                UIDarkMode();
                _configuration.AppSettings.Settings["darkMode"].Value = "true";
            }
            else
            {
                UILightMode();
                _configuration.AppSettings.Settings["darkMode"].Value = "false";
            }


            _configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings"); // Refresh the appSettings section
        }

        private void FixLightUIBackgrounds()
        {
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
        }

        private void UILightMode()
        {
            _materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;

            panel1.BackColor = Color.FromArgb(240, 240, 240);

            FixLightUIBackgrounds();
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


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (startMinimizedCheckbox.Checked)
            {
                _configuration.AppSettings.Settings["startMinimized"].Value = "true";
            }
            else
            {
                _configuration.AppSettings.Settings["startMinimized"].Value = "false";


            }

            if (startupCheckbox.Checked)
            {
                _configuration.AppSettings.Settings["startWithWindows"].Value = "true";
            }
            else
            {
                _configuration.AppSettings.Settings["startWithWindows"].Value = "false";
            }

            _configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            SavePausedData_OnShuttingDown();

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
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void maxDownloadsFromPeersSlider_MouseUp(object sender, MouseEventArgs e)
        {
            string temp = maxDownloadsFromPeersSlider.Value.ToString();
            _configuration.AppSettings.Settings["peersUpoading"].Value = temp;
            _configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void maxActiveDownloadsSlider_MouseUp(object sender, MouseEventArgs e)
        {
            string temp = maxActiveDownloadsSlider.Value.ToString();
            _configuration.AppSettings.Settings["peersDownloading"].Value = temp;
            _configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            using (FolderBrowserDialog openBrowserDialog = new FolderBrowserDialog())
            {
                if (openBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    _sharedFileDownloadFolder = openBrowserDialog.SelectedPath;

                    materialTextBox22.Text = _sharedFileDownloadFolder;

                    try
                    {
                        _configuration.AppSettings.Settings["downloadSharedFileLocation"].Value = _sharedFileDownloadFolder;
                        _configuration.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    catch (Exception ex)
                    {
                        Logger.e($"Error while saving configuration: {ex.Message}");
                    }

                    _configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings"); // Refresh the appSettings section
                }
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            string trackerIpField;
            int trackerPortField;

            (trackerIpField, trackerPortField) = _networkUtils.SplitIpAndPort(this);

            _connections.DestroyPeer(trackerIpField, trackerPortField);

            save.Text = "CONNECT";
            _udpSender.Stop();
        }

        private void Resume_OnStartUp()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            LoadPausedData();
            foreach (TorrentFile torrentFile in _storage.GetPausedTorrentFiles())
            {

                MaterialLabel label1 = new MaterialLabel();
                label1.Text = torrentFile.info.torrentName;

                MaterialLabel label2 = new MaterialLabel();
                label2.Text = _commonUtils.FormatFileSize(torrentFile.info.length);

                _storage.GetDownloadTorrentFiles().Add(torrentFile);

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
                button.Click += PauseResume_Click;

                // Create a new row
                tableLayoutPanel1.RowStyles.Insert(0, new RowStyle(SizeType.AutoSize));

                PTTBlock block = new PTTBlock(0x06, torrentFile.info.checksum.Length, torrentFile.info.checksum);
                List<string> receivedLivePeers = _connections.SendAndRecieveData06(block, this);
                _storage.GetPausedTorrentFiles().Remove(torrentFile);
                //_downloader.Resume(torrentFile, receivedLivePeers, progressBar, _networkUtils, this, );
            }
        }
        private void SavePausedData_OnShuttingDown()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            for (int rowIndex = 0; rowIndex < _storage.GetDownloadTorrentFiles().Count; rowIndex++)
            {
                if (_storage.GetDownloadTorrentStatus()[rowIndex])
                {
                    _downloader.Pause(rowIndex);
                    _storage.GetDownloadTorrentStatus()[rowIndex] = false;
                    _storage.GetPausedTorrentFiles().Add(_storage.GetDownloadTorrentFiles()[rowIndex]);
                }

            }

            string json = JsonSerializer.Serialize(_storage.GetPausedTorrentFiles());
            using (StreamWriter streamWriter = new StreamWriter("temp\\pausedTorrentFiles.json"))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
            }
        }
        private void LoadPausedData()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            string json;
            using (StreamReader streamReader = new StreamReader("temp\\pausedTorrentFiles.json"))
            {
                json = streamReader.ReadToEnd();
            }
            if (json == null)
            {
                _storage.GetPausedTorrentFiles().AddRange(JsonSerializer.Deserialize<List<TorrentFile>>(json));
            }
        }

        private void SetHelp()
        {
            materialHelp.Text = "BuhTorrent Help \r\n\r\nGetting Started\r\n\r\nBrowse Torrents: Click on the \"Browse\" tab to explore available torrents.\r\nSearch: Use the search bar to find specific torrents by their names or descriptions.\r\nDownload: Click on the \"Download\" button next to a torrent to start the download process.\r\nUpload: Go to the \"Upload\" section to share your own torrents.\r\nManaging Downloads\r\n\r\nPause/Resume: During a download, you can pause or resume the process using the \"Pause\" button.\r\nView Progress: Check the progress of your downloads in the \"Downloads\" tab.\r\nManaging Uploads\r\n\r\nCreating Torrents: To upload a file, select the \"Upload\" tab and follow the steps to create and share a torrent.\r\nSettings\r\n\r\nTheme: Adjust the app's theme in the \"Settings\" menu.\r\nConnection: Configure the connection settings for peer-to-peer sharing.\r\nFile Storage: Set the location for downloaded files in the settings.\r\nHelp and Support\r\n\r\nAbout: Find information about the BitTorrent application, version details, and developer contacts.\r\nFAQs: Get answers to common questions in the FAQ section.\r\nExiting the Application\r\n\r\nMinimize: Minimize the app to the system tray to keep it running in the background.\r\nClose: Exit the application using the close option.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MaterialLabel label = new MaterialLabel();
            int count = tableLayoutPanel1.RowCount;
            for (int rowIndex = 0; rowIndex < count - 1; rowIndex++)
            {
                MaterialButton pauseButton = (MaterialButton)tableLayoutPanel1.GetControlFromPosition(3, rowIndex);
                TorrentFile torrentFile = _storage.GetDownloadTorrentFiles()[rowIndex];
                bool state = _storage.GetDownloadTorrentStatus().GetValueOrDefault(rowIndex);
                if (state)
                {
                    _downloader.Pause(rowIndex);
                    _storage.GetDownloadTorrentStatus()[rowIndex] = false;
                    _storage.GetPausedTorrentFiles().Add(torrentFile);

                    pauseButton.Text = "Resume";
                    pauseButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\resume.png");
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MaterialLabel label = new MaterialLabel();
            int count = tableLayoutPanel1.RowCount;
            for (int rowIndex = 0; rowIndex < count - 1; rowIndex++)
            {
                MaterialButton pauseButton = (MaterialButton)tableLayoutPanel1.GetControlFromPosition(3, rowIndex);
                TorrentFile torrentFile = _storage.GetDownloadTorrentFiles()[rowIndex];
                bool state = _storage.GetDownloadTorrentStatus().GetValueOrDefault(rowIndex);
                if (!state)
                {
                    _storage.GetDownloadTorrentStatus()[rowIndex] = true;
                    MaterialProgressBar progressBar = (MaterialProgressBar)tableLayoutPanel1.GetControlFromPosition(2, rowIndex);

                    PTTBlock block = new PTTBlock(0x06, torrentFile.info.checksum.Length, torrentFile.info.checksum);
                    List<string> receivedLivePeers = _connections.SendAndRecieveData06(block, this); // LIVEPEERS broke here

                    if (receivedLivePeers.Count != 0)
                    {
                        _storage.GetPausedTorrentFiles().Remove(torrentFile);
                        _downloader.Resume(torrentFile, receivedLivePeers, (MaterialProgressBar)progressBar, _networkUtils, this, rowIndex);

                        pauseButton.Text = "Pause";
                        pauseButton.Icon = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Resources\\icons\\pause.png");
                    }

                }
            }
        }

    }
}