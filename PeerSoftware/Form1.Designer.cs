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
            resumeAll = new Button();
            pauseAll = new Button();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            status = new Button();
            browes = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            label5 = new Label();
            download = new Button();
            refresh = new Button();
            search = new Button();
            searchBar = new TextBox();
            myTorrents = new TabPage();
            settings = new TabPage();
            help = new TabPage();
            progressBar2 = new ProgressBar();
            label4 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            delete = new Button();
            label8 = new Label();
            label9 = new Label();
            createNewTorrent = new Button();
            label10 = new Label();
            save = new Button();
            trakerIP = new TextBox();
            tabControl1.SuspendLayout();
            buhTorrent.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            browes.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            myTorrents.SuspendLayout();
            settings.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
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
            // 
            // buhTorrent
            // 
            buhTorrent.Controls.Add(resumeAll);
            buhTorrent.Controls.Add(pauseAll);
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
            // resumeAll
            // 
            resumeAll.Location = new Point(627, 25);
            resumeAll.Name = "resumeAll";
            resumeAll.Size = new Size(75, 23);
            resumeAll.TabIndex = 11;
            resumeAll.Text = "Resume All";
            resumeAll.UseVisualStyleBackColor = true;
            // 
            // pauseAll
            // 
            pauseAll.Location = new Point(708, 25);
            pauseAll.Name = "pauseAll";
            pauseAll.Size = new Size(75, 23);
            pauseAll.TabIndex = 10;
            pauseAll.Text = "Pause All";
            pauseAll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(361, 25);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 9;
            label2.Text = "Progress";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 25);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 8;
            label1.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(progressBar1, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(status, 2, 0);
            tableLayoutPanel1.Location = new Point(4, 54);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.5F));
            tableLayoutPanel1.Size = new Size(784, 307);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(357, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(346, 20);
            progressBar1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(4, 12);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 9;
            label3.Text = "Torrent Name 2023";
            // 
            // status
            // 
            status.Location = new Point(710, 4);
            status.Name = "status";
            status.Size = new Size(70, 23);
            status.TabIndex = 10;
            status.Text = "Pause";
            status.UseVisualStyleBackColor = true;
            // 
            // browes
            // 
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
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.44444F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.5555573F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 567F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(download, 3, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(label6, 1, 0);
            tableLayoutPanel2.Controls.Add(label7, 2, 0);
            tableLayoutPanel2.Location = new Point(3, 57);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 87.5F));
            tableLayoutPanel2.Size = new Size(784, 307);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(4, 12);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 9;
            label5.Text = "Name ";
            // 
            // download
            // 
            download.Location = new Point(707, 4);
            download.Name = "download";
            download.Size = new Size(70, 23);
            download.TabIndex = 10;
            download.Text = "Download";
            download.UseVisualStyleBackColor = true;
            // 
            // refresh
            // 
            refresh.Location = new Point(707, 20);
            refresh.Name = "refresh";
            refresh.Size = new Size(75, 23);
            refresh.TabIndex = 2;
            refresh.Text = "Refresh";
            refresh.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            search.Location = new Point(626, 20);
            search.Name = "search";
            search.Size = new Size(75, 23);
            search.TabIndex = 1;
            search.Text = "Search";
            search.UseVisualStyleBackColor = true;
            // 
            // searchBar
            // 
            searchBar.Location = new Point(15, 20);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(605, 23);
            searchBar.TabIndex = 0;
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
            // settings
            // 
            settings.Controls.Add(trakerIP);
            settings.Controls.Add(save);
            settings.Controls.Add(label10);
            settings.Location = new Point(4, 24);
            settings.Name = "settings";
            settings.Size = new Size(791, 420);
            settings.TabIndex = 3;
            settings.Text = "Settings";
            settings.UseVisualStyleBackColor = true;
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
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(91, 12);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 11;
            label6.Text = "Size";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(139, 12);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 12;
            label7.Text = "Descripion";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.None;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.61878F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.38122F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
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
            delete.Location = new Point(707, 4);
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
            label9.Location = new Point(395, 12);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 11;
            label9.Text = "Size";
            // 
            // createNewTorrent
            // 
            createNewTorrent.Location = new Point(63, 18);
            createNewTorrent.Name = "createNewTorrent";
            createNewTorrent.Size = new Size(124, 23);
            createNewTorrent.TabIndex = 10;
            createNewTorrent.Text = "Create new Torrent";
            createNewTorrent.UseVisualStyleBackColor = true;
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
            // save
            // 
            save.Location = new Point(169, 57);
            save.Name = "save";
            save.Size = new Size(75, 23);
            save.TabIndex = 1;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            // 
            // trakerIP
            // 
            trakerIP.Location = new Point(70, 28);
            trakerIP.Name = "trakerIP";
            trakerIP.Size = new Size(174, 23);
            trakerIP.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 451);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "BuhTorrent";
            tabControl1.ResumeLayout(false);
            buhTorrent.ResumeLayout(false);
            buhTorrent.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            browes.ResumeLayout(false);
            browes.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            myTorrents.ResumeLayout(false);
            settings.ResumeLayout(false);
            settings.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private TabControl tabControl1;
        private TabPage buhTorrent;
        private TabPage browes;
        private TabPage myTorrents;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private ProgressBar progressBar1;
        private Label label3;
        private Button pauseAll;
        private TabPage settings;
        private TabPage help;
        private Button resumeAll;
        private Button status;
        private TextBox searchBar;
        private Button refresh;
        private Button search;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private Button download;
        private ProgressBar progressBar2;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label6;
        private Label label7;
        private Button createNewTorrent;
        private TableLayoutPanel tableLayoutPanel4;
        private Button delete;
        private Label label8;
        private Label label9;
        private Button save;
        private Label label10;
        private TextBox trakerIP;
    }
}