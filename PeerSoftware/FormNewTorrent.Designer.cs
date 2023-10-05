﻿namespace PeerSoftware
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
            description = new RichTextBox();
            browseFile = new Button();
            SuspendLayout();
            // 
            // upload
            // 
            upload.Location = new Point(260, 216);
            upload.Name = "upload";
            upload.Size = new Size(75, 23);
            upload.TabIndex = 0;
            upload.Text = "Upload";
            upload.UseVisualStyleBackColor = true;
            upload.Click += upload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 58);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "Torrent Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 96);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Description";
            // 
            // torrentName
            // 
            torrentName.Location = new Point(121, 58);
            torrentName.Name = "torrentName";
            torrentName.Size = new Size(100, 23);
            torrentName.TabIndex = 3;
            // 
            // description
            // 
            description.Location = new Point(121, 96);
            description.Name = "description";
            description.Size = new Size(214, 100);
            description.TabIndex = 4;
            description.Text = "";
            // 
            // browseFile
            // 
            browseFile.Location = new Point(65, 15);
            browseFile.Name = "browseFile";
            browseFile.Size = new Size(274, 28);
            browseFile.TabIndex = 5;
            browseFile.Text = "Browse file to share ";
            browseFile.UseVisualStyleBackColor = true;
            browseFile.Click += browseFile_Click;
            // 
            // FormNewTorrent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 282);
            Controls.Add(browseFile);
            Controls.Add(description);
            Controls.Add(torrentName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(upload);
            Name = "FormNewTorrent";
            Text = "FormNewTorrent";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button upload;
        private Label label1;
        private Label label2;
        private TextBox torrentName;
        private RichTextBox description;
        private Button browseFile;
    }
}