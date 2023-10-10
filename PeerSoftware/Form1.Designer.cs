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
            button5 = new Button();
            button4 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            browes = new TabPage();
            pagelabel = new Label();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            refresh = new Button();
            search = new Button();
            searchBar = new TextBox();
            myTorrents = new TabPage();
            createNewTorrent = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            delete = new Button();
            label8 = new Label();
            label9 = new Label();
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
            browes.SuspendLayout();
            myTorrents.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            settings.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(buhTorrent);
            tabControl1.Controls.Add(browes);
            tabControl1.Controls.Add(myTorrents);
            tabControl1.Controls.Add(settings);
            tabControl1.Controls.Add(help);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(799, 448);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // buhTorrent
            // 
            buhTorrent.Controls.Add(button5);
            buhTorrent.Controls.Add(button4);
            buhTorrent.Controls.Add(label3);
            buhTorrent.Controls.Add(label2);
            buhTorrent.Controls.Add(label1);
            buhTorrent.Controls.Add(tableLayoutPanel1);
            buhTorrent.Location = new Point(4, 24);
            buhTorrent.Name = "buhTorrent";
            buhTorrent.Padding = new Padding(3);
            buhTorrent.Size = new Size(791, 420);
            buhTorrent.TabIndex = 0;
            buhTorrent.Text = "BuhTorrent";
            buhTorrent.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(627, 25);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 11;
            button5.Text = "Resume All";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(708, 25);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 10;
            button4.Text = "Pause All";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(473, 43);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 3;
            label3.Text = "Download Progress";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(402, 43);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 9;
            label2.Text = "Size";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 8;
            label1.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.85523F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.1447659F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 238F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Location = new Point(7, 60);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(778, 353);
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
            browes.Location = new Point(4, 24);
            browes.Name = "browes";
            browes.Padding = new Padding(3);
            browes.Size = new Size(791, 420);
            browes.TabIndex = 1;
            browes.Text = "Browse";
            browes.UseVisualStyleBackColor = true;
            // 
            // pagelabel
            // 
            pagelabel.AutoSize = true;
            pagelabel.Location = new Point(479, 59);
            pagelabel.Name = "pagelabel";
            pagelabel.Size = new Size(89, 15);
            pagelabel.TabIndex = 11;
            pagelabel.Text = "Page Number 0";
            // 
            // button2
            // 
            button2.Location = new Point(686, 55);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "next";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(589, 55);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "previos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.Location = new Point(3, 80);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(784, 334);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // refresh
            // 
            refresh.Location = new Point(707, 20);
            refresh.Name = "refresh";
            refresh.Size = new Size(75, 23);
            refresh.TabIndex = 2;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += refresh_Click;
            // 
            // search
            // 
            search.Location = new Point(626, 20);
            search.Name = "search";
            search.Size = new Size(75, 23);
            search.TabIndex = 1;
            search.Text = "Search";
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // searchBar
            // 
            searchBar.Location = new Point(15, 20);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(605, 23);
            searchBar.TabIndex = 0;
            searchBar.KeyDown += textBox1_KeyDown;
            // 
            // myTorrents
            // 
            myTorrents.Controls.Add(createNewTorrent);
            myTorrents.Controls.Add(tableLayoutPanel4);
            myTorrents.Location = new Point(4, 24);
            myTorrents.Name = "myTorrents";
            myTorrents.Size = new Size(791, 420);
            myTorrents.TabIndex = 2;
            myTorrents.Text = "My Torrents";
            myTorrents.UseVisualStyleBackColor = true;
            // 
            // createNewTorrent
            // 
            createNewTorrent.Location = new Point(63, 18);
            createNewTorrent.Name = "createNewTorrent";
            createNewTorrent.Size = new Size(124, 23);
            createNewTorrent.TabIndex = 10;
            createNewTorrent.Text = "Create new Torrent";
            createNewTorrent.UseVisualStyleBackColor = true;
            createNewTorrent.Click += createNewTorrent_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.None;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.61878F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.38122F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(delete, 2, 0);
            tableLayoutPanel4.Controls.Add(label8, 0, 0);
            tableLayoutPanel4.Controls.Add(label9, 1, 0);
            tableLayoutPanel4.Location = new Point(3, 57);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 87.5F));
            tableLayoutPanel4.Size = new Size(784, 307);
            tableLayoutPanel4.TabIndex = 9;
            // 
            // delete
            // 
            delete.Location = new Point(704, 4);
            delete.Name = "delete";
            delete.Size = new Size(70, 23);
            delete.TabIndex = 10;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(4, 12);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 9;
            label8.Text = "Name ";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(393, 12);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 11;
            label9.Text = "Size";
            // 
            // settings
            // 
            settings.Controls.Add(trackerIP);
            settings.Controls.Add(save);
            settings.Controls.Add(label10);
            settings.Location = new Point(4, 24);
            settings.Name = "settings";
            settings.Size = new Size(791, 420);
            settings.TabIndex = 3;
            settings.Text = "Settings";
            settings.UseVisualStyleBackColor = true;
            // 
            // trackerIP
            // 
            trackerIP.Location = new Point(70, 28);
            trackerIP.Name = "trackerIP";
            trackerIP.Size = new Size(174, 23);
            trackerIP.TabIndex = 2;
            trackerIP.Text = "127.0.0.1:12345";
            // 
            // save
            // 
            save.Location = new Point(169, 57);
            save.Name = "save";
            save.Size = new Size(75, 23);
            save.TabIndex = 1;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 31);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 0;
            label10.Text = "Traker IP";
            // 
            // help
            // 
            help.Location = new Point(4, 24);
            help.Name = "help";
            help.Size = new Size(791, 420);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 449);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "BuhTorrent";
            tabControl1.ResumeLayout(false);
            buhTorrent.ResumeLayout(false);
            buhTorrent.PerformLayout();
            browes.ResumeLayout(false);
            browes.PerformLayout();
            myTorrents.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
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
        private Button delete;
        private Label label8;
        private Label label9;
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
    }
}

