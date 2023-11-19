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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buhTorrent = new System.Windows.Forms.TabPage();
            this.button5 = new MaterialSkin.Controls.MaterialButton();
            this.button4 = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.browes = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pagelabel = new MaterialSkin.Controls.MaterialLabel();
            this.searchBar = new MaterialSkin.Controls.MaterialTextBox2();
            this.button2 = new MaterialSkin.Controls.MaterialButton();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.refresh = new MaterialSkin.Controls.MaterialButton();
            this.search = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.browseTabTorrentAction = new MaterialSkin.Controls.MaterialLabel();
            this.browseTabTorrentDescription = new MaterialSkin.Controls.MaterialLabel();
            this.browseTabTorrentSize = new MaterialSkin.Controls.MaterialLabel();
            this.browseTabTorrentName = new MaterialSkin.Controls.MaterialLabel();
            this.myTorrents = new System.Windows.Forms.TabPage();
            this.createNewTorrent = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.myTorrentsTabNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.myTorrentsTabDescriptionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.myTorrentsTabActionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.label5 = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.settings = new System.Windows.Forms.TabPage();
            this.settingsTabClientGroupBox = new System.Windows.Forms.GroupBox();
            this.startupSettings = new System.Windows.Forms.GroupBox();
            this.startMinimizedCheckbox = new MaterialSkin.Controls.MaterialCheckbox();
            this.startupCheckbox = new MaterialSkin.Controls.MaterialCheckbox();
            this.theme = new System.Windows.Forms.GroupBox();
            this.comboBoxTheme = new MaterialSkin.Controls.MaterialComboBox();
            this.darkModeSwitch = new MaterialSkin.Controls.MaterialSwitch();
            this.peerSettings = new System.Windows.Forms.GroupBox();
            this.materialSlider1 = new MaterialSkin.Controls.MaterialSlider();
            this.settingsTabTrackerGroupBox = new System.Windows.Forms.GroupBox();
            this.trackerIP = new MaterialSkin.Controls.MaterialTextBox2();
            this.save = new MaterialSkin.Controls.MaterialButton();
            this.help = new System.Windows.Forms.TabPage();
            this.tabControlIcons = new System.Windows.Forms.ImageList(this.components);
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonIcons = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.buhTorrent.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.browes.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.myTorrents.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.settings.SuspendLayout();
            this.settingsTabClientGroupBox.SuspendLayout();
            this.startupSettings.SuspendLayout();
            this.theme.SuspendLayout();
            this.peerSettings.SuspendLayout();
            this.settingsTabTrackerGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.buhTorrent);
            this.tabControl1.Controls.Add(this.browes);
            this.tabControl1.Controls.Add(this.myTorrents);
            this.tabControl1.Controls.Add(this.settings);
            this.tabControl1.Controls.Add(this.help);
            this.tabControl1.ImageList = this.tabControlIcons;
            this.tabControl1.Location = new System.Drawing.Point(4, 65);
            this.tabControl1.MinimumSize = new System.Drawing.Size(892, 450);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(892, 450);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // buhTorrent
            // 
            this.buhTorrent.BackColor = System.Drawing.Color.White;
            this.buhTorrent.Controls.Add(this.button5);
            this.buhTorrent.Controls.Add(this.button4);
            this.buhTorrent.Controls.Add(this.tableLayoutPanel5);
            this.buhTorrent.Controls.Add(this.tableLayoutPanel1);
            this.buhTorrent.ImageKey = "downloading_torrents.png";
            this.buhTorrent.Location = new System.Drawing.Point(4, 39);
            this.buhTorrent.Name = "buhTorrent";
            this.buhTorrent.Padding = new System.Windows.Forms.Padding(3);
            this.buhTorrent.Size = new System.Drawing.Size(884, 407);
            this.buhTorrent.TabIndex = 0;
            this.buhTorrent.Text = "Downloading";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.AutoSize = false;
            this.button5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button5.Depth = 0;
            this.button5.HighEmphasis = true;
            this.button5.Icon = ((System.Drawing.Image)(resources.GetObject("button5.Icon")));
            this.button5.Location = new System.Drawing.Point(761, 47);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button5.MouseState = MaterialSkin.MouseState.HOVER;
            this.button5.Name = "button5";
            this.button5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button5.Size = new System.Drawing.Size(116, 36);
            this.button5.TabIndex = 14;
            this.button5.Text = "Resume";
            this.button5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button5.UseAccentColor = false;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.AutoSize = false;
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button4.Depth = 0;
            this.button4.HighEmphasis = true;
            this.button4.Icon = ((System.Drawing.Image)(resources.GetObject("button4.Icon")));
            this.button4.Location = new System.Drawing.Point(761, 9);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button4.MouseState = MaterialSkin.MouseState.HOVER;
            this.button4.Name = "button4";
            this.button4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button4.Size = new System.Drawing.Size(116, 36);
            this.button4.TabIndex = 13;
            this.button4.Text = "Pause All";
            this.button4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button4.UseAccentColor = false;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.21986F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78014F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel5.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 66);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(744, 24);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(566, 2);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Download Progress";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(478, 2);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Size";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.85523F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.14477F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 91);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 311);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // browes
            // 
            this.browes.BackColor = System.Drawing.Color.White;
            this.browes.Controls.Add(this.tableLayoutPanel2);
            this.browes.Controls.Add(this.pagelabel);
            this.browes.Controls.Add(this.searchBar);
            this.browes.Controls.Add(this.button2);
            this.browes.Controls.Add(this.button1);
            this.browes.Controls.Add(this.refresh);
            this.browes.Controls.Add(this.search);
            this.browes.Controls.Add(this.tableLayoutPanel7);
            this.browes.ImageKey = "search.png";
            this.browes.Location = new System.Drawing.Point(4, 39);
            this.browes.Name = "browes";
            this.browes.Padding = new System.Windows.Forms.Padding(3);
            this.browes.Size = new System.Drawing.Size(884, 407);
            this.browes.TabIndex = 1;
            this.browes.Text = "Browse";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 139);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(876, 262);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // pagelabel
            // 
            this.pagelabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pagelabel.AutoSize = true;
            this.pagelabel.Depth = 0;
            this.pagelabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pagelabel.Location = new System.Drawing.Point(727, 86);
            this.pagelabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.pagelabel.Name = "pagelabel";
            this.pagelabel.Size = new System.Drawing.Size(114, 19);
            this.pagelabel.TabIndex = 16;
            this.pagelabel.Text = "Page Number: 0";
            // 
            // searchBar
            // 
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.AnimateReadOnly = false;
            this.searchBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.searchBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.searchBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.searchBar.Depth = 0;
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchBar.HideSelection = true;
            this.searchBar.Hint = "Search for torrent file...";
            this.searchBar.LeadingIcon = null;
            this.searchBar.Location = new System.Drawing.Point(9, 16);
            this.searchBar.MaxLength = 32767;
            this.searchBar.MouseState = MaterialSkin.MouseState.OUT;
            this.searchBar.Name = "searchBar";
            this.searchBar.PasswordChar = '\0';
            this.searchBar.PrefixSuffixText = null;
            this.searchBar.ReadOnly = false;
            this.searchBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.searchBar.SelectedText = "";
            this.searchBar.SelectionLength = 0;
            this.searchBar.SelectionStart = 0;
            this.searchBar.ShortcutsEnabled = true;
            this.searchBar.Size = new System.Drawing.Size(617, 48);
            this.searchBar.TabIndex = 15;
            this.searchBar.TabStop = false;
            this.searchBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchBar.TrailingIcon = null;
            this.searchBar.UseSystemPasswordChar = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = false;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button2.Depth = 0;
            this.button2.HighEmphasis = true;
            this.button2.Icon = ((System.Drawing.Image)(resources.GetObject("button2.Icon")));
            this.button2.Location = new System.Drawing.Point(839, 76);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button2.MouseState = MaterialSkin.MouseState.HOVER;
            this.button2.Name = "button2";
            this.button2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button2.Size = new System.Drawing.Size(38, 36);
            this.button2.TabIndex = 14;
            this.button2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.button2.UseAccentColor = false;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = false;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = ((System.Drawing.Image)(resources.GetObject("button1.Icon")));
            this.button1.Location = new System.Drawing.Point(690, 76);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(40, 36);
            this.button1.TabIndex = 0;
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // refresh
            // 
            this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh.AutoSize = false;
            this.refresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.refresh.Depth = 0;
            this.refresh.HighEmphasis = true;
            this.refresh.Icon = ((System.Drawing.Image)(resources.GetObject("refresh.Icon")));
            this.refresh.Location = new System.Drawing.Point(758, 28);
            this.refresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.refresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.refresh.Name = "refresh";
            this.refresh.NoAccentTextColor = System.Drawing.Color.Empty;
            this.refresh.Size = new System.Drawing.Size(112, 36);
            this.refresh.TabIndex = 13;
            this.refresh.Text = "Refresh";
            this.refresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.refresh.UseAccentColor = false;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search.AutoSize = false;
            this.search.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.search.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.search.Depth = 0;
            this.search.HighEmphasis = true;
            this.search.Icon = ((System.Drawing.Image)(resources.GetObject("search.Icon")));
            this.search.Location = new System.Drawing.Point(642, 28);
            this.search.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.search.MouseState = MaterialSkin.MouseState.HOVER;
            this.search.Name = "search";
            this.search.NoAccentTextColor = System.Drawing.Color.Empty;
            this.search.Size = new System.Drawing.Size(112, 36);
            this.search.TabIndex = 0;
            this.search.Text = "Search";
            this.search.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.search.UseAccentColor = false;
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.57915F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.42085F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 471F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel7.Controls.Add(this.browseTabTorrentAction, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.browseTabTorrentDescription, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.browseTabTorrentSize, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.browseTabTorrentName, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 114);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(874, 24);
            this.tableLayoutPanel7.TabIndex = 12;
            this.tableLayoutPanel7.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel7_Paint);
            // 
            // browseTabTorrentAction
            // 
            this.browseTabTorrentAction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.browseTabTorrentAction.AutoSize = true;
            this.browseTabTorrentAction.Depth = 0;
            this.browseTabTorrentAction.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.browseTabTorrentAction.Location = new System.Drawing.Point(744, 2);
            this.browseTabTorrentAction.MouseState = MaterialSkin.MouseState.HOVER;
            this.browseTabTorrentAction.Name = "browseTabTorrentAction";
            this.browseTabTorrentAction.Size = new System.Drawing.Size(46, 19);
            this.browseTabTorrentAction.TabIndex = 19;
            this.browseTabTorrentAction.Text = "Action";
            // 
            // browseTabTorrentDescription
            // 
            this.browseTabTorrentDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.browseTabTorrentDescription.AutoSize = true;
            this.browseTabTorrentDescription.Depth = 0;
            this.browseTabTorrentDescription.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.browseTabTorrentDescription.Location = new System.Drawing.Point(273, 2);
            this.browseTabTorrentDescription.MouseState = MaterialSkin.MouseState.HOVER;
            this.browseTabTorrentDescription.Name = "browseTabTorrentDescription";
            this.browseTabTorrentDescription.Size = new System.Drawing.Size(81, 19);
            this.browseTabTorrentDescription.TabIndex = 18;
            this.browseTabTorrentDescription.Text = "Description";
            // 
            // browseTabTorrentSize
            // 
            this.browseTabTorrentSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.browseTabTorrentSize.AutoSize = true;
            this.browseTabTorrentSize.Depth = 0;
            this.browseTabTorrentSize.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.browseTabTorrentSize.Location = new System.Drawing.Point(140, 2);
            this.browseTabTorrentSize.MouseState = MaterialSkin.MouseState.HOVER;
            this.browseTabTorrentSize.Name = "browseTabTorrentSize";
            this.browseTabTorrentSize.Size = new System.Drawing.Size(31, 19);
            this.browseTabTorrentSize.TabIndex = 1;
            this.browseTabTorrentSize.Text = "Size";
            // 
            // browseTabTorrentName
            // 
            this.browseTabTorrentName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.browseTabTorrentName.AutoSize = true;
            this.browseTabTorrentName.Depth = 0;
            this.browseTabTorrentName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.browseTabTorrentName.Location = new System.Drawing.Point(3, 2);
            this.browseTabTorrentName.MouseState = MaterialSkin.MouseState.HOVER;
            this.browseTabTorrentName.Name = "browseTabTorrentName";
            this.browseTabTorrentName.Size = new System.Drawing.Size(43, 19);
            this.browseTabTorrentName.TabIndex = 0;
            this.browseTabTorrentName.Text = "Name";
            // 
            // myTorrents
            // 
            this.myTorrents.BackColor = System.Drawing.Color.White;
            this.myTorrents.Controls.Add(this.createNewTorrent);
            this.myTorrents.Controls.Add(this.tableLayoutPanel6);
            this.myTorrents.Controls.Add(this.tableLayoutPanel4);
            this.myTorrents.ImageKey = "files.png";
            this.myTorrents.Location = new System.Drawing.Point(4, 39);
            this.myTorrents.Name = "myTorrents";
            this.myTorrents.Size = new System.Drawing.Size(884, 407);
            this.myTorrents.TabIndex = 2;
            this.myTorrents.Text = "My Torrents";
            // 
            // createNewTorrent
            // 
            this.createNewTorrent.AutoSize = false;
            this.createNewTorrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createNewTorrent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.createNewTorrent.Depth = 0;
            this.createNewTorrent.HighEmphasis = true;
            this.createNewTorrent.Icon = ((System.Drawing.Image)(resources.GetObject("createNewTorrent.Icon")));
            this.createNewTorrent.Location = new System.Drawing.Point(4, 11);
            this.createNewTorrent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.createNewTorrent.MouseState = MaterialSkin.MouseState.HOVER;
            this.createNewTorrent.Name = "createNewTorrent";
            this.createNewTorrent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.createNewTorrent.Size = new System.Drawing.Size(172, 36);
            this.createNewTorrent.TabIndex = 12;
            this.createNewTorrent.Text = "Create Torrent";
            this.createNewTorrent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.createNewTorrent.UseAccentColor = false;
            this.createNewTorrent.UseVisualStyleBackColor = true;
            this.createNewTorrent.Click += new System.EventHandler(this.createNewTorrent_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.74799F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.25201F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel6.Controls.Add(this.myTorrentsTabNameLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.myTorrentsTabDescriptionLabel, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.myTorrentsTabActionLabel, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 56);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(878, 24);
            this.tableLayoutPanel6.TabIndex = 11;
            // 
            // myTorrentsTabNameLabel
            // 
            this.myTorrentsTabNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.myTorrentsTabNameLabel.AutoSize = true;
            this.myTorrentsTabNameLabel.Depth = 0;
            this.myTorrentsTabNameLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.myTorrentsTabNameLabel.Location = new System.Drawing.Point(3, 2);
            this.myTorrentsTabNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.myTorrentsTabNameLabel.Name = "myTorrentsTabNameLabel";
            this.myTorrentsTabNameLabel.Size = new System.Drawing.Size(43, 19);
            this.myTorrentsTabNameLabel.TabIndex = 13;
            this.myTorrentsTabNameLabel.Text = "Name";
            // 
            // myTorrentsTabDescriptionLabel
            // 
            this.myTorrentsTabDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.myTorrentsTabDescriptionLabel.AutoSize = true;
            this.myTorrentsTabDescriptionLabel.Depth = 0;
            this.myTorrentsTabDescriptionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.myTorrentsTabDescriptionLabel.Location = new System.Drawing.Point(376, 2);
            this.myTorrentsTabDescriptionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.myTorrentsTabDescriptionLabel.Name = "myTorrentsTabDescriptionLabel";
            this.myTorrentsTabDescriptionLabel.Size = new System.Drawing.Size(81, 19);
            this.myTorrentsTabDescriptionLabel.TabIndex = 14;
            this.myTorrentsTabDescriptionLabel.Text = "Description";
            // 
            // myTorrentsTabActionLabel
            // 
            this.myTorrentsTabActionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.myTorrentsTabActionLabel.AutoSize = true;
            this.myTorrentsTabActionLabel.Depth = 0;
            this.myTorrentsTabActionLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.myTorrentsTabActionLabel.Location = new System.Drawing.Point(756, 2);
            this.myTorrentsTabActionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.myTorrentsTabActionLabel.Name = "myTorrentsTabActionLabel";
            this.myTorrentsTabActionLabel.Size = new System.Drawing.Size(46, 19);
            this.myTorrentsTabActionLabel.TabIndex = 13;
            this.myTorrentsTabActionLabel.Text = "Action";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(293, 2);
            this.label5.MouseState = MaterialSkin.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Size";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.74799F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.25201F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 81);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(878, 323);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.White;
            this.settings.Controls.Add(this.settingsTabClientGroupBox);
            this.settings.Controls.Add(this.settingsTabTrackerGroupBox);
            this.settings.ImageKey = "settings.png";
            this.settings.Location = new System.Drawing.Point(4, 39);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(884, 407);
            this.settings.TabIndex = 3;
            this.settings.Text = "Settings";
            // 
            // settingsTabClientGroupBox
            // 
            this.settingsTabClientGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabClientGroupBox.Controls.Add(this.startupSettings);
            this.settingsTabClientGroupBox.Controls.Add(this.theme);
            this.settingsTabClientGroupBox.Controls.Add(this.peerSettings);
            this.settingsTabClientGroupBox.Location = new System.Drawing.Point(481, 9);
            this.settingsTabClientGroupBox.Name = "settingsTabClientGroupBox";
            this.settingsTabClientGroupBox.Size = new System.Drawing.Size(400, 395);
            this.settingsTabClientGroupBox.TabIndex = 7;
            this.settingsTabClientGroupBox.TabStop = false;
            this.settingsTabClientGroupBox.Text = "Client Settings";
            // 
            // startupSettings
            // 
            this.startupSettings.Controls.Add(this.startMinimizedCheckbox);
            this.startupSettings.Controls.Add(this.startupCheckbox);
            this.startupSettings.Location = new System.Drawing.Point(6, 22);
            this.startupSettings.Name = "startupSettings";
            this.startupSettings.Size = new System.Drawing.Size(388, 102);
            this.startupSettings.TabIndex = 12;
            this.startupSettings.TabStop = false;
            this.startupSettings.Text = "Startup Settings";
            // 
            // startMinimizedCheckbox
            // 
            this.startMinimizedCheckbox.AutoSize = true;
            this.startMinimizedCheckbox.Depth = 0;
            this.startMinimizedCheckbox.Location = new System.Drawing.Point(6, 56);
            this.startMinimizedCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.startMinimizedCheckbox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.startMinimizedCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.startMinimizedCheckbox.Name = "startMinimizedCheckbox";
            this.startMinimizedCheckbox.ReadOnly = false;
            this.startMinimizedCheckbox.Ripple = true;
            this.startMinimizedCheckbox.Size = new System.Drawing.Size(147, 37);
            this.startMinimizedCheckbox.TabIndex = 1;
            this.startMinimizedCheckbox.Text = "Start Minimized";
            this.startMinimizedCheckbox.UseVisualStyleBackColor = true;
            // 
            // startupCheckbox
            // 
            this.startupCheckbox.AutoSize = true;
            this.startupCheckbox.Depth = 0;
            this.startupCheckbox.Location = new System.Drawing.Point(6, 19);
            this.startupCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.startupCheckbox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.startupCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.startupCheckbox.Name = "startupCheckbox";
            this.startupCheckbox.ReadOnly = false;
            this.startupCheckbox.Ripple = true;
            this.startupCheckbox.Size = new System.Drawing.Size(172, 37);
            this.startupCheckbox.TabIndex = 0;
            this.startupCheckbox.Text = "Start with Windows";
            this.startupCheckbox.UseVisualStyleBackColor = true;
            // 
            // theme
            // 
            this.theme.Controls.Add(this.comboBoxTheme);
            this.theme.Controls.Add(this.darkModeSwitch);
            this.theme.Location = new System.Drawing.Point(6, 130);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(388, 125);
            this.theme.TabIndex = 11;
            this.theme.TabStop = false;
            this.theme.Text = "Theme Settings";
            // 
            // comboBoxTheme
            // 
            this.comboBoxTheme.AutoResize = false;
            this.comboBoxTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxTheme.Depth = 0;
            this.comboBoxTheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxTheme.DropDownHeight = 174;
            this.comboBoxTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTheme.DropDownWidth = 121;
            this.comboBoxTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxTheme.FormattingEnabled = true;
            this.comboBoxTheme.IntegralHeight = false;
            this.comboBoxTheme.ItemHeight = 43;
            this.comboBoxTheme.Location = new System.Drawing.Point(6, 59);
            this.comboBoxTheme.MaxDropDownItems = 4;
            this.comboBoxTheme.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxTheme.Name = "comboBoxTheme";
            this.comboBoxTheme.Size = new System.Drawing.Size(221, 49);
            this.comboBoxTheme.StartIndex = 0;
            this.comboBoxTheme.TabIndex = 9;
            this.comboBoxTheme.SelectedIndexChanged += new System.EventHandler(this.comboBoxTheme_SelectedIndexChanged);
            // 
            // darkModeSwitch
            // 
            this.darkModeSwitch.AutoSize = true;
            this.darkModeSwitch.Depth = 0;
            this.darkModeSwitch.Location = new System.Drawing.Point(6, 19);
            this.darkModeSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.darkModeSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.darkModeSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            this.darkModeSwitch.Name = "darkModeSwitch";
            this.darkModeSwitch.Ripple = true;
            this.darkModeSwitch.Size = new System.Drawing.Size(135, 37);
            this.darkModeSwitch.TabIndex = 8;
            this.darkModeSwitch.Text = "Dark Mode";
            this.darkModeSwitch.UseVisualStyleBackColor = true;
            this.darkModeSwitch.CheckedChanged += new System.EventHandler(this.darkModeSwitch_CheckedChanged);
            // 
            // peerSettings
            // 
            this.peerSettings.Controls.Add(this.materialSlider1);
            this.peerSettings.Location = new System.Drawing.Point(6, 261);
            this.peerSettings.Name = "peerSettings";
            this.peerSettings.Size = new System.Drawing.Size(388, 67);
            this.peerSettings.TabIndex = 6;
            this.peerSettings.TabStop = false;
            this.peerSettings.Text = "Peer Settings";
            // 
            // materialSlider1
            // 
            this.materialSlider1.Depth = 0;
            this.materialSlider1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialSlider1.Location = new System.Drawing.Point(6, 22);
            this.materialSlider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSlider1.Name = "materialSlider1";
            this.materialSlider1.RangeMax = 5;
            this.materialSlider1.Size = new System.Drawing.Size(376, 40);
            this.materialSlider1.TabIndex = 9;
            this.materialSlider1.Text = "Maximum Downloads from";
            this.materialSlider1.Value = 2;
            this.materialSlider1.ValueSuffix = " Peers";
            // 
            // settingsTabTrackerGroupBox
            // 
            this.settingsTabTrackerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabTrackerGroupBox.Controls.Add(this.trackerIP);
            this.settingsTabTrackerGroupBox.Controls.Add(this.save);
            this.settingsTabTrackerGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsTabTrackerGroupBox.Location = new System.Drawing.Point(3, 9);
            this.settingsTabTrackerGroupBox.Name = "settingsTabTrackerGroupBox";
            this.settingsTabTrackerGroupBox.Size = new System.Drawing.Size(472, 395);
            this.settingsTabTrackerGroupBox.TabIndex = 6;
            this.settingsTabTrackerGroupBox.TabStop = false;
            this.settingsTabTrackerGroupBox.Text = "Tracker Settings";
            // 
            // trackerIP
            // 
            this.trackerIP.AnimateReadOnly = false;
            this.trackerIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.trackerIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.trackerIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.trackerIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.trackerIP.Depth = 0;
            this.trackerIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.trackerIP.HideSelection = true;
            this.trackerIP.Hint = "Enter tracker IP and port..";
            this.trackerIP.LeadingIcon = null;
            this.trackerIP.Location = new System.Drawing.Point(6, 22);
            this.trackerIP.MaxLength = 32767;
            this.trackerIP.MouseState = MaterialSkin.MouseState.OUT;
            this.trackerIP.Name = "trackerIP";
            this.trackerIP.PasswordChar = '\0';
            this.trackerIP.PrefixSuffixText = null;
            this.trackerIP.ReadOnly = false;
            this.trackerIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackerIP.SelectedText = "";
            this.trackerIP.SelectionLength = 0;
            this.trackerIP.SelectionStart = 0;
            this.trackerIP.ShortcutsEnabled = true;
            this.trackerIP.Size = new System.Drawing.Size(265, 48);
            this.trackerIP.TabIndex = 5;
            this.trackerIP.TabStop = false;
            this.trackerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.trackerIP.TrailingIcon = null;
            this.trackerIP.UseSystemPasswordChar = false;
            // 
            // save
            // 
            this.save.AutoSize = false;
            this.save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.save.Depth = 0;
            this.save.HighEmphasis = true;
            this.save.Icon = ((System.Drawing.Image)(resources.GetObject("save.Icon")));
            this.save.Location = new System.Drawing.Point(278, 34);
            this.save.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.save.MouseState = MaterialSkin.MouseState.HOVER;
            this.save.Name = "save";
            this.save.NoAccentTextColor = System.Drawing.Color.Empty;
            this.save.Size = new System.Drawing.Size(116, 36);
            this.save.TabIndex = 3;
            this.save.Text = "Connect";
            this.save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.save.UseAccentColor = false;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.White;
            this.help.ImageKey = "help.png";
            this.help.Location = new System.Drawing.Point(4, 39);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(884, 407);
            this.help.TabIndex = 4;
            this.help.Text = "Help";
            // 
            // tabControlIcons
            // 
            this.tabControlIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.tabControlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabControlIcons.ImageStream")));
            this.tabControlIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.tabControlIcons.Images.SetKeyName(0, "downloading_torrents.png");
            this.tabControlIcons.Images.SetKeyName(1, "files.png");
            this.tabControlIcons.Images.SetKeyName(2, "search.png");
            this.tabControlIcons.Images.SetKeyName(3, "settings.png");
            this.tabControlIcons.Images.SetKeyName(4, "help.png");
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(65, 4);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(54, 20);
            this.progressBar2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 45);
            this.label4.TabIndex = 9;
            this.label4.Text = "Torrent Name 2023";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.progressBar2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonIcons
            // 
            this.buttonIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.buttonIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.buttonIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(494, 67);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 37);
            this.panel1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(899, 520);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 500);
            this.Text = "BuhTorrent";
            this.tabControl1.ResumeLayout(false);
            this.buhTorrent.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.browes.ResumeLayout(false);
            this.browes.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.myTorrents.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.settings.ResumeLayout(false);
            this.settingsTabClientGroupBox.ResumeLayout(false);
            this.startupSettings.ResumeLayout(false);
            this.startupSettings.PerformLayout();
            this.theme.ResumeLayout(false);
            this.theme.PerformLayout();
            this.peerSettings.ResumeLayout(false);
            this.settingsTabTrackerGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private MaterialSkin.Controls.MaterialSlider materialSlider1;
        private MaterialSkin.Controls.MaterialLabel myTorrentsTabDescriptionLabel;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialComboBox comboBoxTheme;
        private GroupBox theme;
        private GroupBox startupSettings;
        private MaterialSkin.Controls.MaterialCheckbox startMinimizedCheckbox;
        private MaterialSkin.Controls.MaterialCheckbox startupCheckbox;
        private GroupBox peerSettings;
        public MaterialSkin.Controls.MaterialSwitch darkModeSwitch;
    }
}

