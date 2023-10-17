namespace PeerSoftware
{
    partial class FormNewTorrent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            upload = new Button();
            label1 = new Label();
            label2 = new Label();
            torrentName = new TextBox();
            browseFile = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            filePathTextBox = new TextBox();
            groupBox2 = new GroupBox();
            fileSizeTextBox = new TextBox();
            fileSize = new Label();
            description = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // upload
            // 
            upload.Location = new Point(8, 208);
            upload.Name = "upload";
            upload.Size = new Size(75, 23);
            upload.TabIndex = 0;
            upload.Text = "Create";
            upload.UseVisualStyleBackColor = true;
            upload.Click += upload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "Torrent Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 108);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Description";
            // 
            // torrentName
            // 
            torrentName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            torrentName.Location = new Point(8, 37);
            torrentName.Name = "torrentName";
            torrentName.Size = new Size(581, 23);
            torrentName.TabIndex = 3;
            // 
            // browseFile
            // 
            browseFile.Location = new Point(6, 65);
            browseFile.Name = "browseFile";
            browseFile.Size = new Size(77, 28);
            browseFile.TabIndex = 5;
            browseFile.Text = "Browse";
            browseFile.UseVisualStyleBackColor = true;
            browseFile.Click += browseFile_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(filePathTextBox);
            groupBox1.Controls.Add(browseFile);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(597, 102);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Source";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 18);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 7;
            label3.Text = "File Path";
            // 
            // filePathTextBox
            // 
            filePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            filePathTextBox.BackColor = Color.White;
            filePathTextBox.Enabled = false;
            filePathTextBox.Location = new Point(8, 36);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.ReadOnly = true;
            filePathTextBox.Size = new Size(583, 23);
            filePathTextBox.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(fileSizeTextBox);
            groupBox2.Controls.Add(fileSize);
            groupBox2.Controls.Add(description);
            groupBox2.Controls.Add(upload);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(torrentName);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 120);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(597, 238);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Torrent Properties";
            // 
            // fileSizeTextBox
            // 
            fileSizeTextBox.BackColor = Color.White;
            fileSizeTextBox.Enabled = false;
            fileSizeTextBox.Location = new Point(8, 81);
            fileSizeTextBox.Name = "fileSizeTextBox";
            fileSizeTextBox.ReadOnly = true;
            fileSizeTextBox.Size = new Size(65, 23);
            fileSizeTextBox.TabIndex = 8;
            // 
            // fileSize
            // 
            fileSize.AutoSize = true;
            fileSize.Location = new Point(6, 63);
            fileSize.Name = "fileSize";
            fileSize.Size = new Size(48, 15);
            fileSize.TabIndex = 7;
            fileSize.Text = "File Size";
            // 
            // description
            // 
            description.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            description.Location = new Point(8, 126);
            description.Multiline = true;
            description.Name = "description";
            description.PlaceholderText = "Add description..";
            description.ScrollBars = ScrollBars.Horizontal;
            description.Size = new Size(583, 76);
            description.TabIndex = 6;
            // 
            // FormNewTorrent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 371);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MaximumSize = new Size(959, 410);
            MinimumSize = new Size(444, 410);
            Name = "FormNewTorrent";
            Text = "Create New Torrent";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button upload;
        private Label label1;
        private Label label2;
        private TextBox torrentName;
        private TextBox description;
        private Button browseFile;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox filePathTextBox;
        private Label label3;
        private Panel panel1;
        private TextBox textBox1;
        private TextBox fileSizeTextBox;
        private Label fileSize;
    }
}