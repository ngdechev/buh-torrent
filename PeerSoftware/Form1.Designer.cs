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
            tableLayoutPanel1.SuspendLayout();
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
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(913, 597);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // buhTorrent
            // 
            buhTorrent.Controls.Add(resumeAll);
            buhTorrent.Controls.Add(pauseAll);
            buhTorrent.Controls.Add(label2);
            buhTorrent.Controls.Add(label1);
            buhTorrent.Controls.Add(tableLayoutPanel1);
            buhTorrent.Location = new Point(4, 29);
            buhTorrent.Margin = new Padding(3, 4, 3, 4);
            buhTorrent.Name = "buhTorrent";
            buhTorrent.Padding = new Padding(3, 4, 3, 4);
            buhTorrent.Size = new Size(905, 564);
            buhTorrent.TabIndex = 0;
            buhTorrent.Text = "BuhTorrent";
            buhTorrent.UseVisualStyleBackColor = true;
            // 
            // resumeAll
            // 
            resumeAll.Location = new Point(717, 33);
            resumeAll.Margin = new Padding(3, 4, 3, 4);
            resumeAll.Name = "resumeAll";
            resumeAll.Size = new Size(86, 31);
            resumeAll.TabIndex = 11;
            resumeAll.Text = "Resume All";
            resumeAll.UseVisualStyleBackColor = true;
            // 
            // pauseAll
            // 
            pauseAll.Location = new Point(809, 33);
            pauseAll.Margin = new Padding(3, 4, 3, 4);
            pauseAll.Name = "pauseAll";
            pauseAll.Size = new Size(86, 31);
            pauseAll.TabIndex = 10;
            pauseAll.Text = "Pause All";
            pauseAll.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(413, 33);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 9;
            label2.Text = "Progress";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 33);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.Controls.Add(progressBar1, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(status, 2, 0);
            tableLayoutPanel1.Location = new Point(5, 72);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.5F));
            tableLayoutPanel1.Size = new Size(896, 409);
            tableLayoutPanel1.TabIndex = 7;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(407, 5);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(395, 27);
            progressBar1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(4, 16);
            label3.Name = "label3";
            label3.Size = new Size(136, 20);
            label3.TabIndex = 9;
            label3.Text = "Torrent Name 2023";
            // 
            // status
            // 
            status.Location = new Point(810, 5);
            status.Margin = new Padding(3, 4, 3, 4);
            status.Name = "status";
            status.Size = new Size(80, 31);
            status.TabIndex = 10;
            status.Text = "Pause";
            status.UseVisualStyleBackColor = true;
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
            browes.Location = new Point(4, 29);
            browes.Margin = new Padding(3, 4, 3, 4);
            browes.Name = "browes";
            browes.Padding = new Padding(3, 4, 3, 4);
            browes.Size = new Size(905, 564);
            browes.TabIndex = 1;
            browes.Text = "Browse";
            browes.UseVisualStyleBackColor = true;
            // 
            // pagelabel
            // 
            pagelabel.AutoSize = true;
            pagelabel.Location = new Point(547, 79);
            pagelabel.Name = "pagelabel";
            pagelabel.Size = new Size(111, 20);
            pagelabel.TabIndex = 11;
            pagelabel.Text = "Page Number 0";
            // 
            // button2
            // 
            button2.Location = new Point(784, 73);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 10;
            button2.Text = "next";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(673, 73);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
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
            tableLayoutPanel2.Location = new Point(3, 107);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(896, 445);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // refresh
            // 
            refresh.Location = new Point(808, 27);
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
            search.Location = new Point(715, 27);
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
            searchBar.Location = new Point(17, 27);
            searchBar.Margin = new Padding(3, 4, 3, 4);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(691, 27);
            searchBar.TabIndex = 0;
            // 
            // myTorrents
            // 
            myTorrents.Controls.Add(createNewTorrent);
            myTorrents.Controls.Add(tableLayoutPanel4);
            myTorrents.Location = new Point(4, 29);
            myTorrents.Margin = new Padding(3, 4, 3, 4);
            myTorrents.Name = "myTorrents";
            myTorrents.Size = new Size(905, 564);
            myTorrents.TabIndex = 2;
            myTorrents.Text = "My Torrents";
            myTorrents.UseVisualStyleBackColor = true;
            // 
            // createNewTorrent
            // 
            createNewTorrent.Location = new Point(72, 24);
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
            tableLayoutPanel4.Anchor = AnchorStyles.None;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.61878F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.38122F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            tableLayoutPanel4.Controls.Add(delete, 2, 0);
            tableLayoutPanel4.Controls.Add(label8, 0, 0);
            tableLayoutPanel4.Controls.Add(label9, 1, 0);
            tableLayoutPanel4.Location = new Point(3, 76);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 87.5F));
            tableLayoutPanel4.Size = new Size(896, 409);
            tableLayoutPanel4.TabIndex = 9;
            // 
            // delete
            // 
            delete.Location = new Point(806, 5);
            delete.Margin = new Padding(3, 4, 3, 4);
            delete.Name = "delete";
            delete.Size = new Size(80, 31);
            delete.TabIndex = 10;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(4, 16);
            label8.Name = "label8";
            label8.Size = new Size(53, 20);
            label8.TabIndex = 9;
            label8.Text = "Name ";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(450, 16);
            label9.Name = "label9";
            label9.Size = new Size(36, 20);
            label9.TabIndex = 11;
            label9.Text = "Size";
            // 
            // settings
            // 
            settings.Controls.Add(trackerIP);
            settings.Controls.Add(save);
            settings.Controls.Add(label10);
            settings.Location = new Point(4, 29);
            settings.Margin = new Padding(3, 4, 3, 4);
            settings.Name = "settings";
            settings.Size = new Size(905, 564);
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
            help.Size = new Size(905, 564);
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
            ClientSize = new Size(917, 601);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
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

    }
}

