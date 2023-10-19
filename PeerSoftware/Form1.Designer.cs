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
            tabControl1 = new TabControl();
            buhTorrent = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            button5 = new Button();
            button4 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            browes = new TabPage();
            pagelabel = new Label();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            refresh = new Button();
            search = new Button();
            searchBar = new TextBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            browseTabTorrentName = new Label();
            browseTabSizeLabel = new Label();
            browseTabDescriptionLabel = new Label();
            myTorrents = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            label5 = new Label();
            myTorrentsTabActionLabel = new Label();
            myTorrentsTabNameLabel = new Label();
            createNewTorrent = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            settings = new TabPage();
            trackerIP = new TextBox();
            save = new Button();
            label10 = new Label();
            help = new TabPage();
            progressBar2 = new ProgressBar();
            label4 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            tabControl1.SuspendLayout();
            buhTorrent.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            browes.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            myTorrents.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            settings.SuspendLayout();
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
            tabControl1.Location = new Point(1, 1);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.MinimumSize = new Size(1047, 697);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1047, 697);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // buhTorrent
            // 
            buhTorrent.Controls.Add(tableLayoutPanel5);
            buhTorrent.Controls.Add(button5);
            buhTorrent.Controls.Add(button4);
            buhTorrent.Controls.Add(tableLayoutPanel1);
            buhTorrent.Location = new Point(4, 29);
            buhTorrent.Margin = new Padding(3, 4, 3, 4);
            buhTorrent.Name = "buhTorrent";
            buhTorrent.Padding = new Padding(3, 4, 3, 4);
            buhTorrent.Size = new Size(1039, 664);
            buhTorrent.TabIndex = 0;
            buhTorrent.Text = "BuhTorrent";
            buhTorrent.UseVisualStyleBackColor = true;
            buhTorrent.Click += buhTorrent_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.26573F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.7342653F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
            tableLayoutPanel5.Controls.Add(label3, 2, 0);
            tableLayoutPanel5.Controls.Add(label1, 0, 0);
            tableLayoutPanel5.Controls.Add(label2, 1, 0);
            tableLayoutPanel5.Location = new Point(10, 71);
            tableLayoutPanel5.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(785, 32);
            tableLayoutPanel5.TabIndex = 12;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(629, 6);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 3;
            label3.Text = "Download Progress";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 8;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(531, 6);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 9;
            label2.Text = "Size";
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(904, 64);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(86, 31);
            button5.TabIndex = 11;
            button5.Text = "Resume All";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(904, 25);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(86, 31);
            button4.TabIndex = 10;
            button4.Text = "Pause All";
            button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.85523F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.1447659F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 272F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            tableLayoutPanel1.Location = new Point(10, 104);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(979, 364);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // browes
            // 
            browes.Controls.Add(pagelabel);
            browes.Controls.Add(button2);
            browes.Controls.Add(button1);
            browes.Controls.Add(tableLayoutPanel2);
            browes.Controls.Add(refresh);
            browes.Controls.Add(search);
            browes.Controls.Add(searchBar);
            browes.Controls.Add(tableLayoutPanel7);
            browes.Location = new Point(4, 29);
            browes.Margin = new Padding(3, 4, 3, 4);
            browes.Name = "browes";
            browes.Padding = new Padding(3, 4, 3, 4);
            browes.Size = new Size(1039, 664);
            browes.TabIndex = 1;
            browes.Text = "Browse";
            browes.UseVisualStyleBackColor = true;
            // 
            // pagelabel
            // 
            pagelabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pagelabel.AutoSize = true;
            pagelabel.Location = new Point(703, 71);
            pagelabel.Name = "pagelabel";
            pagelabel.Size = new Size(111, 20);
            pagelabel.TabIndex = 11;
            pagelabel.Text = "Page Number 0";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(904, 65);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 10;
            button2.Text = "Next";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(811, 65);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 9;
            button1.Text = "Previos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            tableLayoutPanel2.Location = new Point(3, 104);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(986, 356);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // refresh
            // 
            refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refresh.Location = new Point(904, 27);
            refresh.Margin = new Padding(3, 4, 3, 4);
            refresh.Name = "refresh";
            refresh.Size = new Size(86, 31);
            refresh.TabIndex = 2;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += refresh_Click;
            // 
            // search
            // 
            search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            search.Location = new Point(811, 27);
            search.Margin = new Padding(3, 4, 3, 4);
            search.Name = "search";
            search.Size = new Size(86, 31);
            search.TabIndex = 1;
            search.Text = "Search";
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // searchBar
            // 
            searchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBar.Location = new Point(3, 27);
            searchBar.Margin = new Padding(3, 4, 3, 4);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(801, 27);
            searchBar.TabIndex = 0;
            searchBar.KeyDown += textBox1_KeyDown;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel7.ColumnCount = 3;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.6124039F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.3875961F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 691F));
            tableLayoutPanel7.Controls.Add(browseTabTorrentName, 0, 0);
            tableLayoutPanel7.Controls.Add(browseTabSizeLabel, 1, 0);
            tableLayoutPanel7.Controls.Add(browseTabDescriptionLabel, 2, 0);
            tableLayoutPanel7.Location = new Point(3, 71);
            tableLayoutPanel7.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(986, 32);
            tableLayoutPanel7.TabIndex = 12;
            // 
            // browseTabTorrentName
            // 
            browseTabTorrentName.Anchor = AnchorStyles.Left;
            browseTabTorrentName.AutoSize = true;
            browseTabTorrentName.Location = new Point(3, 6);
            browseTabTorrentName.Name = "browseTabTorrentName";
            browseTabTorrentName.Size = new Size(49, 20);
            browseTabTorrentName.TabIndex = 0;
            browseTabTorrentName.Text = "Name";
            // 
            // browseTabSizeLabel
            // 
            browseTabSizeLabel.Anchor = AnchorStyles.Left;
            browseTabSizeLabel.AutoSize = true;
            browseTabSizeLabel.Location = new Point(149, 6);
            browseTabSizeLabel.Name = "browseTabSizeLabel";
            browseTabSizeLabel.Size = new Size(36, 20);
            browseTabSizeLabel.TabIndex = 1;
            browseTabSizeLabel.Text = "Size";
            // 
            // browseTabDescriptionLabel
            // 
            browseTabDescriptionLabel.Anchor = AnchorStyles.Left;
            browseTabDescriptionLabel.AutoSize = true;
            browseTabDescriptionLabel.Location = new Point(297, 6);
            browseTabDescriptionLabel.Name = "browseTabDescriptionLabel";
            browseTabDescriptionLabel.Size = new Size(85, 20);
            browseTabDescriptionLabel.TabIndex = 2;
            browseTabDescriptionLabel.Text = "Description";
            // 
            // myTorrents
            // 
            myTorrents.Controls.Add(tableLayoutPanel6);
            myTorrents.Controls.Add(createNewTorrent);
            myTorrents.Controls.Add(tableLayoutPanel4);
            myTorrents.Location = new Point(4, 29);
            myTorrents.Margin = new Padding(3, 4, 3, 4);
            myTorrents.Name = "myTorrents";
            myTorrents.Size = new Size(1039, 664);
            myTorrents.TabIndex = 2;
            myTorrents.Text = "My Torrents";
            myTorrents.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.15464F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.84536F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            tableLayoutPanel6.Controls.Add(label5, 0, 0);
            tableLayoutPanel6.Controls.Add(myTorrentsTabActionLabel, 1, 0);
            tableLayoutPanel6.Controls.Add(myTorrentsTabNameLabel, 0, 0);
            tableLayoutPanel6.Location = new Point(8, 65);
            tableLayoutPanel6.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel6.Size = new Size(977, 32);
            tableLayoutPanel6.TabIndex = 11;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(488, 6);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 2;
            label5.Text = "Size";
            // 
            // myTorrentsTabActionLabel
            // 
            myTorrentsTabActionLabel.Anchor = AnchorStyles.Left;
            myTorrentsTabActionLabel.AutoSize = true;
            myTorrentsTabActionLabel.Location = new Point(883, 6);
            myTorrentsTabActionLabel.Name = "myTorrentsTabActionLabel";
            myTorrentsTabActionLabel.Size = new Size(52, 20);
            myTorrentsTabActionLabel.TabIndex = 1;
            myTorrentsTabActionLabel.Text = "Action";
            // 
            // myTorrentsTabNameLabel
            // 
            myTorrentsTabNameLabel.Anchor = AnchorStyles.Left;
            myTorrentsTabNameLabel.AutoSize = true;
            myTorrentsTabNameLabel.Location = new Point(3, 6);
            myTorrentsTabNameLabel.Name = "myTorrentsTabNameLabel";
            myTorrentsTabNameLabel.Size = new Size(49, 20);
            myTorrentsTabNameLabel.TabIndex = 0;
            myTorrentsTabNameLabel.Text = "Name";
            // 
            // createNewTorrent
            // 
            createNewTorrent.Location = new Point(3, 27);
            createNewTorrent.Margin = new Padding(3, 4, 3, 4);
            createNewTorrent.Name = "createNewTorrent";
            createNewTorrent.Size = new Size(142, 31);
            createNewTorrent.TabIndex = 10;
            createNewTorrent.Text = "Create new Torrent";
            createNewTorrent.UseVisualStyleBackColor = true;
            createNewTorrent.Click += createNewTorrent_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.61878F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.38122F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            tableLayoutPanel4.Location = new Point(8, 105);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 353F));
            tableLayoutPanel4.Size = new Size(977, 355);
            tableLayoutPanel4.TabIndex = 9;
            // 
            // settings
            // 
            settings.Controls.Add(trackerIP);
            settings.Controls.Add(save);
            settings.Controls.Add(label10);
            settings.Location = new Point(4, 29);
            settings.Margin = new Padding(3, 4, 3, 4);
            settings.Name = "settings";
            settings.Size = new Size(1039, 664);
            settings.TabIndex = 3;
            settings.Text = "Settings";
            settings.UseVisualStyleBackColor = true;
            // 
            // trackerIP
            // 
            trackerIP.Location = new Point(80, 37);
            trackerIP.Margin = new Padding(3, 4, 3, 4);
            trackerIP.Name = "trackerIP";
            trackerIP.Size = new Size(198, 27);
            trackerIP.TabIndex = 2;
            trackerIP.Text = "127.0.0.1:12345";
            // 
            // save
            // 
            save.Location = new Point(193, 76);
            save.Margin = new Padding(3, 4, 3, 4);
            save.Name = "save";
            save.Size = new Size(86, 31);
            save.TabIndex = 1;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 41);
            label10.Name = "label10";
            label10.Size = new Size(65, 20);
            label10.TabIndex = 0;
            label10.Text = "Traker IP";
            // 
            // help
            // 
            help.Location = new Point(4, 29);
            help.Margin = new Padding(3, 4, 3, 4);
            help.Name = "help";
            help.Size = new Size(1039, 664);
            help.TabIndex = 4;
            help.Text = "Help";
            help.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 509);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1025, 546);
            Name = "Form1";
            Text = "BuhTorrent";
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
            settings.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }



        #endregion

        private TabControl tabControl1;
        private TabPage browes;
        private TabPage myTorrents;
        private TabPage settings;
        private TabPage help;
        private TextBox searchBar;
        private Button refresh;
        private Button search;
        private TableLayoutPanel tableLayoutPanel2;
        private ProgressBar progressBar2;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel3;
        private Button createNewTorrent;
        private TableLayoutPanel tableLayoutPanel4;
        private Button save;
        private Label label10;
        private TextBox trackerIP;

        private Button button2;
        private Button button1;
        private Label pagelabel;
        private TabPage buhTorrent;
        private Label label3;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button5;
        private Button button4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label5;
        private Label myTorrentsTabActionLabel;
        private Label myTorrentsTabNameLabel;
        private TableLayoutPanel tableLayoutPanel7;
        private Label browseTabTorrentName;
        private Label browseTabSizeLabel;
        private Label browseTabDescriptionLabel;
    }
}

