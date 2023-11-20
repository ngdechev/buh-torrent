namespace PeerSoftware
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            buhTorrent = new TabPage();
            button5 = new MaterialSkin.Controls.MaterialButton();
            button4 = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel5 = new TableLayoutPanel();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            label2 = new MaterialSkin.Controls.MaterialLabel();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            browes = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            pagelabel = new MaterialSkin.Controls.MaterialLabel();
            searchBar = new MaterialSkin.Controls.MaterialTextBox2();
            button2 = new MaterialSkin.Controls.MaterialButton();
            button1 = new MaterialSkin.Controls.MaterialButton();
            refresh = new MaterialSkin.Controls.MaterialButton();
            search = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel7 = new TableLayoutPanel();
            browseTabTorrentAction = new MaterialSkin.Controls.MaterialLabel();
            browseTabTorrentDescription = new MaterialSkin.Controls.MaterialLabel();
            browseTabTorrentSize = new MaterialSkin.Controls.MaterialLabel();
            browseTabTorrentName = new MaterialSkin.Controls.MaterialLabel();
            myTorrents = new TabPage();
            createNewTorrent = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel6 = new TableLayoutPanel();
            myTorrentsTabNameLabel = new MaterialSkin.Controls.MaterialLabel();
            myTorrentsTabDescriptionLabel = new MaterialSkin.Controls.MaterialLabel();
            myTorrentsTabActionLabel = new MaterialSkin.Controls.MaterialLabel();
            label5 = new MaterialSkin.Controls.MaterialLabel();
            tableLayoutPanel4 = new TableLayoutPanel();
            settings = new TabPage();
            settingsTabClientGroupBox = new GroupBox();
            startupSettings = new GroupBox();
            startMinimizedCheckbox = new MaterialSkin.Controls.MaterialCheckbox();
            startupCheckbox = new MaterialSkin.Controls.MaterialCheckbox();
            theme = new GroupBox();
            comboBoxTheme = new MaterialSkin.Controls.MaterialComboBox();
            darkModeSwitch = new MaterialSkin.Controls.MaterialSwitch();
            peerSettings = new GroupBox();
            browseDownloadsLocationLabel = new MaterialSkin.Controls.MaterialLabel();
            btnBrowseDownloadLocation = new MaterialSkin.Controls.MaterialButton();
            browseDownloadLocationTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            maxActiveDownloadsSlider = new MaterialSkin.Controls.MaterialSlider();
            maxDownloadsFromPeersSlider = new MaterialSkin.Controls.MaterialSlider();
            settingsTabTrackerGroupBox = new GroupBox();
            trackerIP = new MaterialSkin.Controls.MaterialTextBox2();
            save = new MaterialSkin.Controls.MaterialButton();
            help = new TabPage();
            tabControlIcons = new ImageList(components);
            progressBar2 = new ProgressBar();
            label4 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            buttonIcons = new ImageList(components);
            panel1 = new Panel();
            notifyIcon1 = new NotifyIcon(components);
            tabControl1.SuspendLayout();
            buhTorrent.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            browes.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            myTorrents.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            settings.SuspendLayout();
            settingsTabClientGroupBox.SuspendLayout();
            startupSettings.SuspendLayout();
            theme.SuspendLayout();
            peerSettings.SuspendLayout();
            settingsTabTrackerGroupBox.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(buhTorrent);
            tabControl1.Controls.Add(browes);
            tabControl1.Controls.Add(myTorrents);
            tabControl1.Controls.Add(settings);
            tabControl1.Controls.Add(help);
            tabControl1.ImageList = tabControlIcons;
            tabControl1.Location = new Point(4, 65);
            tabControl1.MinimumSize = new Size(892, 450);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(892, 450);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // buhTorrent
            // 
            buhTorrent.BackColor = Color.White;
            buhTorrent.Controls.Add(button5);
            buhTorrent.Controls.Add(button4);
            buhTorrent.Controls.Add(tableLayoutPanel5);
            buhTorrent.Controls.Add(tableLayoutPanel1);
            buhTorrent.ImageKey = "downloading_torrents.png";
            buhTorrent.Location = new Point(4, 39);
            buhTorrent.Name = "buhTorrent";
            buhTorrent.Padding = new Padding(3);
            buhTorrent.Size = new Size(884, 407);
            buhTorrent.TabIndex = 0;
            buhTorrent.Text = "Downloading";
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.AutoSize = false;
            button5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button5.Depth = 0;
            button5.HighEmphasis = true;
            button5.Icon = (Image)resources.GetObject("button5.Icon");
            button5.Location = new Point(761, 47);
            button5.Margin = new Padding(4, 6, 4, 6);
            button5.MouseState = MaterialSkin.MouseState.HOVER;
            button5.Name = "button5";
            button5.NoAccentTextColor = Color.Empty;
            button5.Size = new Size(116, 36);
            button5.TabIndex = 14;
            button5.Text = "Resume";
            button5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button5.UseAccentColor = false;
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.AutoSize = false;
            button4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button4.Depth = 0;
            button4.HighEmphasis = true;
            button4.Icon = (Image)resources.GetObject("button4.Icon");
            button4.Location = new Point(761, 9);
            button4.Margin = new Padding(4, 6, 4, 6);
            button4.MouseState = MaterialSkin.MouseState.HOVER;
            button4.Name = "button4";
            button4.NoAccentTextColor = Color.Empty;
            button4.Size = new Size(116, 36);
            button4.TabIndex = 13;
            button4.Text = "Pause All";
            button4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            button4.UseAccentColor = false;
            button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.21986F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.78014F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel5.Controls.Add(label3, 2, 0);
            tableLayoutPanel5.Controls.Add(label2, 1, 0);
            tableLayoutPanel5.Controls.Add(label1, 0, 0);
            tableLayoutPanel5.Location = new Point(3, 66);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(744, 24);
            tableLayoutPanel5.TabIndex = 12;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Depth = 0;
            label3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label3.Location = new Point(566, 2);
            label3.MouseState = MaterialSkin.MouseState.HOVER;
            label3.Name = "label3";
            label3.Size = new Size(139, 19);
            label3.TabIndex = 15;
            label3.Text = "Download Progress";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.Location = new Point(478, 2);
            label2.MouseState = MaterialSkin.MouseState.HOVER;
            label2.Name = "label2";
            label2.Size = new Size(31, 19);
            label2.TabIndex = 15;
            label2.Text = "Size";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(3, 2);
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(43, 19);
            label1.TabIndex = 15;
            label1.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.85523F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.14477F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 194F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
            tableLayoutPanel1.Location = new Point(3, 91);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(875, 311);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // browes
            // 
            browes.BackColor = Color.White;
            browes.Controls.Add(tableLayoutPanel2);
            browes.Controls.Add(pagelabel);
            browes.Controls.Add(searchBar);
            browes.Controls.Add(button2);
            browes.Controls.Add(button1);
            browes.Controls.Add(refresh);
            browes.Controls.Add(search);
            browes.Controls.Add(tableLayoutPanel7);
            browes.ImageKey = "search.png";
            browes.Location = new Point(4, 39);
            browes.Name = "browes";
            browes.Padding = new Padding(3);
            browes.Size = new Size(884, 407);
            browes.TabIndex = 1;
            browes.Text = "Browse";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.Location = new Point(3, 139);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(876, 262);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // pagelabel
            // 
            pagelabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pagelabel.AutoSize = true;
            pagelabel.Depth = 0;
            pagelabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pagelabel.Location = new Point(727, 86);
            pagelabel.MouseState = MaterialSkin.MouseState.HOVER;
            pagelabel.Name = "pagelabel";
            pagelabel.Size = new Size(114, 19);
            pagelabel.TabIndex = 16;
            pagelabel.Text = "Page Number: 0";
            // 
            // searchBar
            // 
            searchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBar.AnimateReadOnly = false;
            searchBar.AutoCompleteMode = AutoCompleteMode.None;
            searchBar.AutoCompleteSource = AutoCompleteSource.None;
            searchBar.BackgroundImageLayout = ImageLayout.None;
            searchBar.CharacterCasing = CharacterCasing.Normal;
            searchBar.Depth = 0;
            searchBar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchBar.HideSelection = true;
            searchBar.Hint = "Search for torrent file...";
            searchBar.LeadingIcon = null;
            searchBar.Location = new Point(9, 16);
            searchBar.MaxLength = 32767;
            searchBar.MouseState = MaterialSkin.MouseState.OUT;
            searchBar.Name = "searchBar";
            searchBar.PasswordChar = '\0';
            searchBar.PrefixSuffixText = null;
            searchBar.ReadOnly = false;
            searchBar.RightToLeft = RightToLeft.No;
            searchBar.SelectedText = "";
            searchBar.SelectionLength = 0;
            searchBar.SelectionStart = 0;
            searchBar.ShortcutsEnabled = true;
            searchBar.Size = new Size(617, 48);
            searchBar.TabIndex = 15;
            searchBar.TabStop = false;
            searchBar.TextAlign = HorizontalAlignment.Left;
            searchBar.TrailingIcon = null;
            searchBar.UseSystemPasswordChar = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.AutoSize = false;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.BackColor = Color.White;
            button2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button2.Depth = 0;
            button2.HighEmphasis = true;
            button2.Icon = (Image)resources.GetObject("button2.Icon");
            button2.Location = new Point(839, 76);
            button2.Margin = new Padding(4, 6, 4, 6);
            button2.MouseState = MaterialSkin.MouseState.HOVER;
            button2.Name = "button2";
            button2.NoAccentTextColor = Color.Empty;
            button2.Size = new Size(38, 36);
            button2.TabIndex = 14;
            button2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            button2.UseAccentColor = false;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.AutoSize = false;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            button1.Depth = 0;
            button1.HighEmphasis = true;
            button1.Icon = (Image)resources.GetObject("button1.Icon");
            button1.Location = new Point(690, 76);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.MouseState = MaterialSkin.MouseState.HOVER;
            button1.Name = "button1";
            button1.NoAccentTextColor = Color.Empty;
            button1.Size = new Size(40, 36);
            button1.TabIndex = 0;
            button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            button1.UseAccentColor = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // refresh
            // 
            refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refresh.AutoSize = false;
            refresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            refresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            refresh.Depth = 0;
            refresh.HighEmphasis = true;
            refresh.Icon = (Image)resources.GetObject("refresh.Icon");
            refresh.Location = new Point(758, 28);
            refresh.Margin = new Padding(4, 6, 4, 6);
            refresh.MouseState = MaterialSkin.MouseState.HOVER;
            refresh.Name = "refresh";
            refresh.NoAccentTextColor = Color.Empty;
            refresh.Size = new Size(112, 36);
            refresh.TabIndex = 13;
            refresh.Text = "Refresh";
            refresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            refresh.UseAccentColor = false;
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += refresh_Click;
            // 
            // search
            // 
            search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            search.AutoSize = false;
            search.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            search.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            search.Depth = 0;
            search.HighEmphasis = true;
            search.Icon = (Image)resources.GetObject("search.Icon");
            search.Location = new Point(642, 28);
            search.Margin = new Padding(4, 6, 4, 6);
            search.MouseState = MaterialSkin.MouseState.HOVER;
            search.Name = "search";
            search.NoAccentTextColor = Color.Empty;
            search.Size = new Size(112, 36);
            search.TabIndex = 0;
            search.Text = "Search";
            search.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            search.UseAccentColor = false;
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel7.ColumnCount = 4;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.57915F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.42085F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 471F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
            tableLayoutPanel7.Controls.Add(browseTabTorrentAction, 3, 0);
            tableLayoutPanel7.Controls.Add(browseTabTorrentDescription, 2, 0);
            tableLayoutPanel7.Controls.Add(browseTabTorrentSize, 1, 0);
            tableLayoutPanel7.Controls.Add(browseTabTorrentName, 0, 0);
            tableLayoutPanel7.Location = new Point(3, 114);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(874, 24);
            tableLayoutPanel7.TabIndex = 12;
            // 
            // browseTabTorrentAction
            // 
            browseTabTorrentAction.Anchor = AnchorStyles.Left;
            browseTabTorrentAction.AutoSize = true;
            browseTabTorrentAction.Depth = 0;
            browseTabTorrentAction.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            browseTabTorrentAction.Location = new Point(744, 2);
            browseTabTorrentAction.MouseState = MaterialSkin.MouseState.HOVER;
            browseTabTorrentAction.Name = "browseTabTorrentAction";
            browseTabTorrentAction.Size = new Size(46, 19);
            browseTabTorrentAction.TabIndex = 19;
            browseTabTorrentAction.Text = "Action";
            // 
            // browseTabTorrentDescription
            // 
            browseTabTorrentDescription.Anchor = AnchorStyles.Left;
            browseTabTorrentDescription.AutoSize = true;
            browseTabTorrentDescription.Depth = 0;
            browseTabTorrentDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            browseTabTorrentDescription.Location = new Point(273, 2);
            browseTabTorrentDescription.MouseState = MaterialSkin.MouseState.HOVER;
            browseTabTorrentDescription.Name = "browseTabTorrentDescription";
            browseTabTorrentDescription.Size = new Size(81, 19);
            browseTabTorrentDescription.TabIndex = 18;
            browseTabTorrentDescription.Text = "Description";
            // 
            // browseTabTorrentSize
            // 
            browseTabTorrentSize.Anchor = AnchorStyles.Left;
            browseTabTorrentSize.AutoSize = true;
            browseTabTorrentSize.Depth = 0;
            browseTabTorrentSize.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            browseTabTorrentSize.Location = new Point(140, 2);
            browseTabTorrentSize.MouseState = MaterialSkin.MouseState.HOVER;
            browseTabTorrentSize.Name = "browseTabTorrentSize";
            browseTabTorrentSize.Size = new Size(31, 19);
            browseTabTorrentSize.TabIndex = 1;
            browseTabTorrentSize.Text = "Size";
            // 
            // browseTabTorrentName
            // 
            browseTabTorrentName.Anchor = AnchorStyles.Left;
            browseTabTorrentName.AutoSize = true;
            browseTabTorrentName.Depth = 0;
            browseTabTorrentName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            browseTabTorrentName.Location = new Point(3, 2);
            browseTabTorrentName.MouseState = MaterialSkin.MouseState.HOVER;
            browseTabTorrentName.Name = "browseTabTorrentName";
            browseTabTorrentName.Size = new Size(43, 19);
            browseTabTorrentName.TabIndex = 0;
            browseTabTorrentName.Text = "Name";
            // 
            // myTorrents
            // 
            myTorrents.BackColor = Color.White;
            myTorrents.Controls.Add(createNewTorrent);
            myTorrents.Controls.Add(tableLayoutPanel6);
            myTorrents.Controls.Add(tableLayoutPanel4);
            myTorrents.ImageKey = "files.png";
            myTorrents.Location = new Point(4, 39);
            myTorrents.Name = "myTorrents";
            myTorrents.Size = new Size(884, 407);
            myTorrents.TabIndex = 2;
            myTorrents.Text = "My Torrents";
            // 
            // createNewTorrent
            // 
            createNewTorrent.AutoSize = false;
            createNewTorrent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            createNewTorrent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            createNewTorrent.Depth = 0;
            createNewTorrent.HighEmphasis = true;
            createNewTorrent.Icon = (Image)resources.GetObject("createNewTorrent.Icon");
            createNewTorrent.Location = new Point(4, 11);
            createNewTorrent.Margin = new Padding(4, 6, 4, 6);
            createNewTorrent.MouseState = MaterialSkin.MouseState.HOVER;
            createNewTorrent.Name = "createNewTorrent";
            createNewTorrent.NoAccentTextColor = Color.Empty;
            createNewTorrent.Size = new Size(172, 36);
            createNewTorrent.TabIndex = 12;
            createNewTorrent.Text = "Create Torrent";
            createNewTorrent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            createNewTorrent.UseAccentColor = false;
            createNewTorrent.UseVisualStyleBackColor = true;
            createNewTorrent.Click += createNewTorrent_Click;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel6.ColumnCount = 4;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.74799F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.25201F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 124F));
            tableLayoutPanel6.Controls.Add(myTorrentsTabNameLabel, 0, 0);
            tableLayoutPanel6.Controls.Add(myTorrentsTabDescriptionLabel, 2, 0);
            tableLayoutPanel6.Controls.Add(myTorrentsTabActionLabel, 2, 0);
            tableLayoutPanel6.Controls.Add(label5, 1, 0);
            tableLayoutPanel6.Location = new Point(3, 56);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel6.Size = new Size(878, 24);
            tableLayoutPanel6.TabIndex = 11;
            // 
            // myTorrentsTabNameLabel
            // 
            myTorrentsTabNameLabel.Anchor = AnchorStyles.Left;
            myTorrentsTabNameLabel.AutoSize = true;
            myTorrentsTabNameLabel.Depth = 0;
            myTorrentsTabNameLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            myTorrentsTabNameLabel.Location = new Point(3, 2);
            myTorrentsTabNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            myTorrentsTabNameLabel.Name = "myTorrentsTabNameLabel";
            myTorrentsTabNameLabel.Size = new Size(43, 19);
            myTorrentsTabNameLabel.TabIndex = 13;
            myTorrentsTabNameLabel.Text = "Name";
            // 
            // myTorrentsTabDescriptionLabel
            // 
            myTorrentsTabDescriptionLabel.Anchor = AnchorStyles.Left;
            myTorrentsTabDescriptionLabel.AutoSize = true;
            myTorrentsTabDescriptionLabel.Depth = 0;
            myTorrentsTabDescriptionLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            myTorrentsTabDescriptionLabel.Location = new Point(376, 2);
            myTorrentsTabDescriptionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            myTorrentsTabDescriptionLabel.Name = "myTorrentsTabDescriptionLabel";
            myTorrentsTabDescriptionLabel.Size = new Size(81, 19);
            myTorrentsTabDescriptionLabel.TabIndex = 14;
            myTorrentsTabDescriptionLabel.Text = "Description";
            // 
            // myTorrentsTabActionLabel
            // 
            myTorrentsTabActionLabel.Anchor = AnchorStyles.Left;
            myTorrentsTabActionLabel.AutoSize = true;
            myTorrentsTabActionLabel.Depth = 0;
            myTorrentsTabActionLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            myTorrentsTabActionLabel.Location = new Point(756, 2);
            myTorrentsTabActionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            myTorrentsTabActionLabel.Name = "myTorrentsTabActionLabel";
            myTorrentsTabActionLabel.Size = new Size(46, 19);
            myTorrentsTabActionLabel.TabIndex = 13;
            myTorrentsTabActionLabel.Text = "Action";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Depth = 0;
            label5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label5.Location = new Point(293, 2);
            label5.MouseState = MaterialSkin.MouseState.HOVER;
            label5.Name = "label5";
            label5.Size = new Size(31, 19);
            label5.TabIndex = 13;
            label5.Text = "Size";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.AutoScroll = true;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 4;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.74799F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.25201F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121F));
            tableLayoutPanel4.Location = new Point(3, 81);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 266F));
            tableLayoutPanel4.Size = new Size(878, 323);
            tableLayoutPanel4.TabIndex = 9;
            // 
            // settings
            // 
            settings.BackColor = Color.White;
            settings.Controls.Add(settingsTabClientGroupBox);
            settings.Controls.Add(settingsTabTrackerGroupBox);
            settings.ImageKey = "settings.png";
            settings.Location = new Point(4, 39);
            settings.Name = "settings";
            settings.Size = new Size(884, 407);
            settings.TabIndex = 3;
            settings.Text = "Settings";
            // 
            // settingsTabClientGroupBox
            // 
            settingsTabClientGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            settingsTabClientGroupBox.Controls.Add(startupSettings);
            settingsTabClientGroupBox.Controls.Add(theme);
            settingsTabClientGroupBox.Controls.Add(peerSettings);
            settingsTabClientGroupBox.Location = new Point(481, 9);
            settingsTabClientGroupBox.Name = "settingsTabClientGroupBox";
            settingsTabClientGroupBox.Size = new Size(400, 395);
            settingsTabClientGroupBox.TabIndex = 7;
            settingsTabClientGroupBox.TabStop = false;
            settingsTabClientGroupBox.Text = "Client Settings";
            // 
            // startupSettings
            // 
            startupSettings.Controls.Add(startMinimizedCheckbox);
            startupSettings.Controls.Add(startupCheckbox);
            startupSettings.Location = new Point(6, 22);
            startupSettings.Name = "startupSettings";
            startupSettings.Size = new Size(388, 62);
            startupSettings.TabIndex = 12;
            startupSettings.TabStop = false;
            startupSettings.Text = "Startup Settings";
            // 
            // startMinimizedCheckbox
            // 
            startMinimizedCheckbox.AutoSize = true;
            startMinimizedCheckbox.Depth = 0;
            startMinimizedCheckbox.Location = new Point(178, 19);
            startMinimizedCheckbox.Margin = new Padding(0);
            startMinimizedCheckbox.MouseLocation = new Point(-1, -1);
            startMinimizedCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            startMinimizedCheckbox.Name = "startMinimizedCheckbox";
            startMinimizedCheckbox.ReadOnly = false;
            startMinimizedCheckbox.Ripple = true;
            startMinimizedCheckbox.Size = new Size(147, 37);
            startMinimizedCheckbox.TabIndex = 1;
            startMinimizedCheckbox.Text = "Start Minimized";
            startMinimizedCheckbox.UseVisualStyleBackColor = true;
            // 
            // startupCheckbox
            // 
            startupCheckbox.AutoSize = true;
            startupCheckbox.Depth = 0;
            startupCheckbox.Location = new Point(6, 19);
            startupCheckbox.Margin = new Padding(0);
            startupCheckbox.MouseLocation = new Point(-1, -1);
            startupCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            startupCheckbox.Name = "startupCheckbox";
            startupCheckbox.ReadOnly = false;
            startupCheckbox.Ripple = true;
            startupCheckbox.Size = new Size(172, 37);
            startupCheckbox.TabIndex = 0;
            startupCheckbox.Text = "Start with Windows";
            startupCheckbox.UseVisualStyleBackColor = true;
            // 
            // theme
            // 
            theme.Controls.Add(comboBoxTheme);
            theme.Controls.Add(darkModeSwitch);
            theme.Location = new Point(6, 90);
            theme.Name = "theme";
            theme.Size = new Size(388, 86);
            theme.TabIndex = 11;
            theme.TabStop = false;
            theme.Text = "Theme Settings";
            // 
            // comboBoxTheme
            // 
            comboBoxTheme.AutoResize = false;
            comboBoxTheme.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxTheme.Depth = 0;
            comboBoxTheme.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxTheme.DropDownHeight = 174;
            comboBoxTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTheme.DropDownWidth = 121;
            comboBoxTheme.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxTheme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxTheme.FormattingEnabled = true;
            comboBoxTheme.IntegralHeight = false;
            comboBoxTheme.ItemHeight = 43;
            comboBoxTheme.Location = new Point(6, 22);
            comboBoxTheme.MaxDropDownItems = 4;
            comboBoxTheme.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxTheme.Name = "comboBoxTheme";
            comboBoxTheme.Size = new Size(235, 49);
            comboBoxTheme.StartIndex = 0;
            comboBoxTheme.TabIndex = 9;
            comboBoxTheme.SelectedIndexChanged += comboBoxTheme_SelectedIndexChanged;
            // 
            // darkModeSwitch
            // 
            darkModeSwitch.AutoSize = true;
            darkModeSwitch.Depth = 0;
            darkModeSwitch.Location = new Point(250, 34);
            darkModeSwitch.Margin = new Padding(0);
            darkModeSwitch.MouseLocation = new Point(-1, -1);
            darkModeSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            darkModeSwitch.Name = "darkModeSwitch";
            darkModeSwitch.Ripple = true;
            darkModeSwitch.Size = new Size(135, 37);
            darkModeSwitch.TabIndex = 8;
            darkModeSwitch.Text = "Dark Mode";
            darkModeSwitch.UseVisualStyleBackColor = true;
            darkModeSwitch.CheckedChanged += darkModeSwitch_CheckedChanged;
            // 
            // peerSettings
            // 
            peerSettings.Controls.Add(browseDownloadsLocationLabel);
            peerSettings.Controls.Add(btnBrowseDownloadLocation);
            peerSettings.Controls.Add(browseDownloadLocationTextBox);
            peerSettings.Controls.Add(maxActiveDownloadsSlider);
            peerSettings.Controls.Add(maxDownloadsFromPeersSlider);
            peerSettings.Location = new Point(6, 182);
            peerSettings.Name = "peerSettings";
            peerSettings.Size = new Size(388, 207);
            peerSettings.TabIndex = 6;
            peerSettings.TabStop = false;
            peerSettings.Text = "Peer Settings";
            // 
            // browseDownloadsLocationLabel
            // 
            browseDownloadsLocationLabel.AutoSize = true;
            browseDownloadsLocationLabel.Depth = 0;
            browseDownloadsLocationLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            browseDownloadsLocationLabel.Location = new Point(6, 28);
            browseDownloadsLocationLabel.MouseState = MaterialSkin.MouseState.HOVER;
            browseDownloadsLocationLabel.Name = "browseDownloadsLocationLabel";
            browseDownloadsLocationLabel.Size = new Size(147, 19);
            browseDownloadsLocationLabel.TabIndex = 12;
            browseDownloadsLocationLabel.Text = "Downloads Location";
            // 
            // btnBrowseDownloadLocation
            // 
            btnBrowseDownloadLocation.AutoSize = false;
            btnBrowseDownloadLocation.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBrowseDownloadLocation.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBrowseDownloadLocation.Depth = 0;
            btnBrowseDownloadLocation.HighEmphasis = true;
            btnBrowseDownloadLocation.Icon = (Image)resources.GetObject("btnBrowseDownloadLocation.Icon");
            btnBrowseDownloadLocation.Location = new Point(250, 67);
            btnBrowseDownloadLocation.Margin = new Padding(4, 6, 4, 6);
            btnBrowseDownloadLocation.MouseState = MaterialSkin.MouseState.HOVER;
            btnBrowseDownloadLocation.Name = "btnBrowseDownloadLocation";
            btnBrowseDownloadLocation.NoAccentTextColor = Color.Empty;
            btnBrowseDownloadLocation.Size = new Size(116, 36);
            btnBrowseDownloadLocation.TabIndex = 6;
            btnBrowseDownloadLocation.Text = "Browse";
            btnBrowseDownloadLocation.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBrowseDownloadLocation.UseAccentColor = false;
            btnBrowseDownloadLocation.UseVisualStyleBackColor = true;
            // 
            // browseDownloadLocationTextBox
            // 
            browseDownloadLocationTextBox.AnimateReadOnly = false;
            browseDownloadLocationTextBox.AutoCompleteMode = AutoCompleteMode.None;
            browseDownloadLocationTextBox.AutoCompleteSource = AutoCompleteSource.None;
            browseDownloadLocationTextBox.BackgroundImageLayout = ImageLayout.None;
            browseDownloadLocationTextBox.CharacterCasing = CharacterCasing.Normal;
            browseDownloadLocationTextBox.Depth = 0;
            browseDownloadLocationTextBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            browseDownloadLocationTextBox.HideSelection = true;
            browseDownloadLocationTextBox.LeadingIcon = null;
            browseDownloadLocationTextBox.Location = new Point(6, 59);
            browseDownloadLocationTextBox.MaxLength = 32767;
            browseDownloadLocationTextBox.MouseState = MaterialSkin.MouseState.OUT;
            browseDownloadLocationTextBox.Name = "browseDownloadLocationTextBox";
            browseDownloadLocationTextBox.PasswordChar = '\0';
            browseDownloadLocationTextBox.PrefixSuffixText = null;
            browseDownloadLocationTextBox.ReadOnly = true;
            browseDownloadLocationTextBox.RightToLeft = RightToLeft.No;
            browseDownloadLocationTextBox.SelectedText = "";
            browseDownloadLocationTextBox.SelectionLength = 0;
            browseDownloadLocationTextBox.SelectionStart = 0;
            browseDownloadLocationTextBox.ShortcutsEnabled = true;
            browseDownloadLocationTextBox.Size = new Size(235, 48);
            browseDownloadLocationTextBox.TabIndex = 11;
            browseDownloadLocationTextBox.TabStop = false;
            browseDownloadLocationTextBox.TextAlign = HorizontalAlignment.Left;
            browseDownloadLocationTextBox.TrailingIcon = null;
            browseDownloadLocationTextBox.UseSystemPasswordChar = false;
            // 
            // maxActiveDownloadsSlider
            // 
            maxActiveDownloadsSlider.Depth = 0;
            maxActiveDownloadsSlider.ForeColor = Color.FromArgb(222, 0, 0, 0);
            maxActiveDownloadsSlider.Location = new Point(6, 159);
            maxActiveDownloadsSlider.MouseState = MaterialSkin.MouseState.HOVER;
            maxActiveDownloadsSlider.Name = "maxActiveDownloadsSlider";
            maxActiveDownloadsSlider.RangeMax = 5;
            maxActiveDownloadsSlider.Size = new Size(376, 40);
            maxActiveDownloadsSlider.TabIndex = 10;
            maxActiveDownloadsSlider.Text = "Maximum Active Downloads";
            maxActiveDownloadsSlider.Value = 2;
            // 
            // maxDownloadsFromPeersSlider
            // 
            maxDownloadsFromPeersSlider.Depth = 0;
            maxDownloadsFromPeersSlider.ForeColor = Color.FromArgb(222, 0, 0, 0);
            maxDownloadsFromPeersSlider.Location = new Point(6, 113);
            maxDownloadsFromPeersSlider.MouseState = MaterialSkin.MouseState.HOVER;
            maxDownloadsFromPeersSlider.Name = "maxDownloadsFromPeersSlider";
            maxDownloadsFromPeersSlider.RangeMax = 5;
            maxDownloadsFromPeersSlider.Size = new Size(376, 40);
            maxDownloadsFromPeersSlider.TabIndex = 9;
            maxDownloadsFromPeersSlider.Text = "Maximum Downloads from";
            maxDownloadsFromPeersSlider.Value = 2;
            maxDownloadsFromPeersSlider.ValueSuffix = " Peers";
            // 
            // settingsTabTrackerGroupBox
            // 
            settingsTabTrackerGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            settingsTabTrackerGroupBox.Controls.Add(trackerIP);
            settingsTabTrackerGroupBox.Controls.Add(save);
            settingsTabTrackerGroupBox.ForeColor = SystemColors.ControlText;
            settingsTabTrackerGroupBox.Location = new Point(3, 9);
            settingsTabTrackerGroupBox.Name = "settingsTabTrackerGroupBox";
            settingsTabTrackerGroupBox.Size = new Size(472, 395);
            settingsTabTrackerGroupBox.TabIndex = 6;
            settingsTabTrackerGroupBox.TabStop = false;
            settingsTabTrackerGroupBox.Text = "Tracker Settings";
            // 
            // trackerIP
            // 
            trackerIP.AnimateReadOnly = false;
            trackerIP.AutoCompleteMode = AutoCompleteMode.None;
            trackerIP.AutoCompleteSource = AutoCompleteSource.None;
            trackerIP.BackgroundImageLayout = ImageLayout.None;
            trackerIP.CharacterCasing = CharacterCasing.Normal;
            trackerIP.Depth = 0;
            trackerIP.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            trackerIP.HideSelection = true;
            trackerIP.Hint = "Enter tracker IP and port..";
            trackerIP.LeadingIcon = null;
            trackerIP.Location = new Point(6, 22);
            trackerIP.MaxLength = 32767;
            trackerIP.MouseState = MaterialSkin.MouseState.OUT;
            trackerIP.Name = "trackerIP";
            trackerIP.PasswordChar = '\0';
            trackerIP.PrefixSuffixText = null;
            trackerIP.ReadOnly = false;
            trackerIP.RightToLeft = RightToLeft.No;
            trackerIP.SelectedText = "";
            trackerIP.SelectionLength = 0;
            trackerIP.SelectionStart = 0;
            trackerIP.ShortcutsEnabled = true;
            trackerIP.Size = new Size(265, 48);
            trackerIP.TabIndex = 5;
            trackerIP.TabStop = false;
            trackerIP.TextAlign = HorizontalAlignment.Left;
            trackerIP.TrailingIcon = null;
            trackerIP.UseSystemPasswordChar = false;
            // 
            // save
            // 
            save.AutoSize = false;
            save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            save.Depth = 0;
            save.HighEmphasis = true;
            save.Icon = (Image)resources.GetObject("save.Icon");
            save.Location = new Point(278, 34);
            save.Margin = new Padding(4, 6, 4, 6);
            save.MouseState = MaterialSkin.MouseState.HOVER;
            save.Name = "save";
            save.NoAccentTextColor = Color.Empty;
            save.Size = new Size(116, 36);
            save.TabIndex = 3;
            save.Text = "Connect";
            save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            save.UseAccentColor = false;
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // help
            // 
            help.BackColor = Color.White;
            help.ImageKey = "help.png";
            help.Location = new Point(4, 39);
            help.Name = "help";
            help.Size = new Size(884, 407);
            help.TabIndex = 4;
            help.Text = "Help";
            // 
            // tabControlIcons
            // 
            tabControlIcons.ColorDepth = ColorDepth.Depth32Bit;
            tabControlIcons.ImageStream = (ImageListStreamer)resources.GetObject("tabControlIcons.ImageStream");
            tabControlIcons.TransparentColor = Color.Transparent;
            tabControlIcons.Images.SetKeyName(0, "downloading_torrents.png");
            tabControlIcons.Images.SetKeyName(1, "files.png");
            tabControlIcons.Images.SetKeyName(2, "search.png");
            tabControlIcons.Images.SetKeyName(3, "settings.png");
            tabControlIcons.Images.SetKeyName(4, "help.png");
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(65, 4);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(54, 20);
            progressBar2.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(4, 27);
            label4.Name = "label4";
            label4.Size = new Size(47, 45);
            label4.TabIndex = 9;
            label4.Text = "Torrent Name 2023";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.None;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(progressBar2, 1, 0);
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonIcons
            // 
            buttonIcons.ColorDepth = ColorDepth.Depth32Bit;
            buttonIcons.ImageSize = new Size(32, 32);
            buttonIcons.TransparentColor = Color.Transparent;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Location = new Point(494, 67);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(403, 37);
            panel1.TabIndex = 15;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "BuhTorrent is minimized";
            notifyIcon1.BalloonTipTitle = "BuhTorrent";
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.MouseClick += NotifyIcon_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(899, 520);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(899, 419);
            Name = "Form1";
            Padding = new Padding(0, 64, 0, 500);
            Text = "BuhTorrent";
            FormClosing += MainForm_FormClosing;
            tabControl1.ResumeLayout(false);
            buhTorrent.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            browes.ResumeLayout(false);
            browes.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            myTorrents.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            settings.ResumeLayout(false);
            settingsTabClientGroupBox.ResumeLayout(false);
            startupSettings.ResumeLayout(false);
            startupSettings.PerformLayout();
            theme.ResumeLayout(false);
            theme.PerformLayout();
            peerSettings.ResumeLayout(false);
            peerSettings.PerformLayout();
            settingsTabTrackerGroupBox.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }



        #endregion

        private TabControl tabControl1;
        private TabPage browes;
        private TabPage myTorrents;
        private TabPage settings;
        private TabPage help;
        private TableLayoutPanel tableLayoutPanel2;
        private ProgressBar progressBar2;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TabPage buhTorrent;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;

        private ImageList tabControlIcons;
        private MaterialSkin.Controls.MaterialButton search;
        private MaterialSkin.Controls.MaterialButton refresh;
        private MaterialSkin.Controls.MaterialTextBox2 searchBar;
        private MaterialSkin.Controls.MaterialButton button2;
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialLabel pagelabel;
        private ImageList buttonIcons;
        private MaterialSkin.Controls.MaterialLabel browseTabTorrentName;
        private MaterialSkin.Controls.MaterialLabel browseTabTorrentAction;
        private MaterialSkin.Controls.MaterialLabel browseTabTorrentDescription;
        private MaterialSkin.Controls.MaterialLabel browseTabTorrentSize;
        private MaterialSkin.Controls.MaterialButton button5;
        private MaterialSkin.Controls.MaterialButton button4;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialButton createNewTorrent;
        private MaterialSkin.Controls.MaterialLabel myTorrentsTabActionLabel;
        private MaterialSkin.Controls.MaterialLabel label5;
        private MaterialSkin.Controls.MaterialLabel myTorrentsTabNameLabel;
        private MaterialSkin.Controls.MaterialTextBox2 trackerIP;
        private MaterialSkin.Controls.MaterialButton save;
        private GroupBox settingsTabTrackerGroupBox;
        private GroupBox settingsTabClientGroupBox;
        private MaterialSkin.Controls.MaterialSlider maxDownloadsFromPeersSlider;
        private MaterialSkin.Controls.MaterialLabel myTorrentsTabDescriptionLabel;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialComboBox comboBoxTheme;
        private GroupBox theme;
        private GroupBox startupSettings;
        private MaterialSkin.Controls.MaterialCheckbox startMinimizedCheckbox;
        private MaterialSkin.Controls.MaterialCheckbox startupCheckbox;
        private GroupBox peerSettings;
        public MaterialSkin.Controls.MaterialSwitch darkModeSwitch;
        private MaterialSkin.Controls.MaterialSlider maxActiveDownloadsSlider;
        private MaterialSkin.Controls.MaterialButton btnBrowseDownloadLocation;
        private MaterialSkin.Controls.MaterialTextBox2 browseDownloadLocationTextBox;
        private MaterialSkin.Controls.MaterialLabel browseDownloadsLocationLabel;


        private Label browseTabSizeLabel;
        private Label browseTabDescriptionLabel;
        private NotifyIcon notifyIcon1;

    }
}

