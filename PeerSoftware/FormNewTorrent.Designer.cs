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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewTorrent));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseFile = new MaterialSkin.Controls.MaterialButton();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.filePathTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.upload = new MaterialSkin.Controls.MaterialButton();
            this.description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.fileSizeTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.fileSize = new MaterialSkin.Controls.MaterialLabel();
            this.torrentName = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.browseFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.filePathTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 151);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Source";
            // 
            // browseFile
            // 
            this.browseFile.AutoSize = false;
            this.browseFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browseFile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.browseFile.Depth = 0;
            this.browseFile.HighEmphasis = true;
            this.browseFile.Icon = ((System.Drawing.Image)(resources.GetObject("browseFile.Icon")));
            this.browseFile.Location = new System.Drawing.Point(6, 98);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.browseFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.browseFile.Name = "browseFile";
            this.browseFile.NoAccentTextColor = System.Drawing.Color.Empty;
            this.browseFile.Size = new System.Drawing.Size(112, 36);
            this.browseFile.TabIndex = 10;
            this.browseFile.Text = "Browse";
            this.browseFile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.browseFile.UseAccentColor = false;
            this.browseFile.UseVisualStyleBackColor = true;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "File Path";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextBox.AnimateReadOnly = false;
            this.filePathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.filePathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.filePathTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.filePathTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.filePathTextBox.Depth = 0;
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filePathTextBox.HideSelection = true;
            this.filePathTextBox.LeadingIcon = null;
            this.filePathTextBox.Location = new System.Drawing.Point(6, 41);
            this.filePathTextBox.MaxLength = 32767;
            this.filePathTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.PasswordChar = '\0';
            this.filePathTextBox.PrefixSuffixText = null;
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filePathTextBox.SelectedText = "";
            this.filePathTextBox.SelectionLength = 0;
            this.filePathTextBox.SelectionStart = 0;
            this.filePathTextBox.ShortcutsEnabled = true;
            this.filePathTextBox.Size = new System.Drawing.Size(598, 48);
            this.filePathTextBox.TabIndex = 8;
            this.filePathTextBox.TabStop = false;
            this.filePathTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.filePathTextBox.TrailingIcon = null;
            this.filePathTextBox.UseSystemPasswordChar = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.upload);
            this.groupBox2.Controls.Add(this.description);
            this.groupBox2.Controls.Add(this.materialLabel1);
            this.groupBox2.Controls.Add(this.fileSizeTextBox);
            this.groupBox2.Controls.Add(this.fileSize);
            this.groupBox2.Controls.Add(this.torrentName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 349);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Torrent Properties";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // upload
            // 
            this.upload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.upload.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.upload.Depth = 0;
            this.upload.HighEmphasis = true;
            this.upload.Icon = ((System.Drawing.Image)(resources.GetObject("upload.Icon")));
            this.upload.Location = new System.Drawing.Point(7, 296);
            this.upload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.upload.MouseState = MaterialSkin.MouseState.HOVER;
            this.upload.Name = "upload";
            this.upload.NoAccentTextColor = System.Drawing.Color.Empty;
            this.upload.Size = new System.Drawing.Size(104, 36);
            this.upload.TabIndex = 15;
            this.upload.Text = "Create";
            this.upload.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.upload.UseAccentColor = false;
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // description
            // 
            this.description.AnimateReadOnly = false;
            this.description.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.description.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.description.Depth = 0;
            this.description.HideSelection = true;
            this.description.Hint = "Add description..";
            this.description.Location = new System.Drawing.Point(6, 187);
            this.description.MaxLength = 32767;
            this.description.MouseState = MaterialSkin.MouseState.OUT;
            this.description.Name = "description";
            this.description.PasswordChar = '\0';
            this.description.ReadOnly = false;
            this.description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.description.SelectedText = "";
            this.description.SelectionLength = 0;
            this.description.SelectionStart = 0;
            this.description.ShortcutsEnabled = true;
            this.description.Size = new System.Drawing.Size(583, 100);
            this.description.TabIndex = 14;
            this.description.TabStop = false;
            this.description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.description.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 165);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 13;
            this.materialLabel1.Text = "Description";
            // 
            // fileSizeTextBox
            // 
            this.fileSizeTextBox.AnimateReadOnly = false;
            this.fileSizeTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.fileSizeTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.fileSizeTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fileSizeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.fileSizeTextBox.Depth = 0;
            this.fileSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileSizeTextBox.HideSelection = true;
            this.fileSizeTextBox.LeadingIcon = null;
            this.fileSizeTextBox.Location = new System.Drawing.Point(6, 114);
            this.fileSizeTextBox.MaxLength = 32767;
            this.fileSizeTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.fileSizeTextBox.Name = "fileSizeTextBox";
            this.fileSizeTextBox.PasswordChar = '\0';
            this.fileSizeTextBox.PrefixSuffixText = null;
            this.fileSizeTextBox.ReadOnly = true;
            this.fileSizeTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileSizeTextBox.SelectedText = "";
            this.fileSizeTextBox.SelectionLength = 0;
            this.fileSizeTextBox.SelectionStart = 0;
            this.fileSizeTextBox.ShortcutsEnabled = true;
            this.fileSizeTextBox.Size = new System.Drawing.Size(86, 48);
            this.fileSizeTextBox.TabIndex = 12;
            this.fileSizeTextBox.TabStop = false;
            this.fileSizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.fileSizeTextBox.TrailingIcon = null;
            this.fileSizeTextBox.UseSystemPasswordChar = false;
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Depth = 0;
            this.fileSize.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fileSize.Location = new System.Drawing.Point(6, 92);
            this.fileSize.MouseState = MaterialSkin.MouseState.HOVER;
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(60, 19);
            this.fileSize.TabIndex = 11;
            this.fileSize.Text = "File Size";
            // 
            // torrentName
            // 
            this.torrentName.AnimateReadOnly = false;
            this.torrentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.torrentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.torrentName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.torrentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.torrentName.Depth = 0;
            this.torrentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.torrentName.HideSelection = true;
            this.torrentName.LeadingIcon = null;
            this.torrentName.Location = new System.Drawing.Point(6, 41);
            this.torrentName.MaxLength = 32767;
            this.torrentName.MouseState = MaterialSkin.MouseState.OUT;
            this.torrentName.Name = "torrentName";
            this.torrentName.PasswordChar = '\0';
            this.torrentName.PrefixSuffixText = null;
            this.torrentName.ReadOnly = false;
            this.torrentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.torrentName.SelectedText = "";
            this.torrentName.SelectionLength = 0;
            this.torrentName.SelectionStart = 0;
            this.torrentName.ShortcutsEnabled = true;
            this.torrentName.Size = new System.Drawing.Size(583, 48);
            this.torrentName.TabIndex = 10;
            this.torrentName.TabStop = false;
            this.torrentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.torrentName.TrailingIcon = null;
            this.torrentName.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Torrent Name";
            // 
            // FormNewTorrent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 585);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 410);
            this.Name = "FormNewTorrent";
            this.Text = "Create New Torrent";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel1;
        private TextBox textBox1;
        private MaterialSkin.Controls.MaterialButton browseFile;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialTextBox2 filePathTextBox;
        private MaterialSkin.Controls.MaterialLabel fileSize;
        private MaterialSkin.Controls.MaterialTextBox2 torrentName;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialButton upload;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 description;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 fileSizeTextBox;
    }
}