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
            groupBox1 = new GroupBox();
            browseFile = new MaterialSkin.Controls.MaterialButton();
            label3 = new MaterialSkin.Controls.MaterialLabel();
            filePathTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            groupBox2 = new GroupBox();
            upload = new MaterialSkin.Controls.MaterialButton();
            description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            fileSizeTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            fileSize = new MaterialSkin.Controls.MaterialLabel();
            torrentName = new MaterialSkin.Controls.MaterialTextBox2();
            label1 = new MaterialSkin.Controls.MaterialLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(browseFile);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(filePathTextBox);
            groupBox1.Location = new Point(6, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(612, 151);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Source";
            // 
            // browseFile
            // 
            browseFile.AutoSize = false;
            browseFile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            browseFile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            browseFile.Depth = 0;
            browseFile.HighEmphasis = true;
            browseFile.Icon = (Image)resources.GetObject("browseFile.Icon");
            browseFile.Location = new Point(6, 98);
            browseFile.Margin = new Padding(4, 6, 4, 6);
            browseFile.MouseState = MaterialSkin.MouseState.HOVER;
            browseFile.Name = "browseFile";
            browseFile.NoAccentTextColor = Color.Empty;
            browseFile.Size = new Size(112, 36);
            browseFile.TabIndex = 10;
            browseFile.Text = "Browse";
            browseFile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            browseFile.UseAccentColor = false;
            browseFile.UseVisualStyleBackColor = true;
            browseFile.Click += browseFile_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Depth = 0;
            label3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label3.Location = new Point(6, 19);
            label3.MouseState = MaterialSkin.MouseState.HOVER;
            label3.Name = "label3";
            label3.Size = new Size(63, 19);
            label3.TabIndex = 9;
            label3.Text = "File Path";
            // 
            // filePathTextBox
            // 
            filePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            filePathTextBox.AnimateReadOnly = false;
            filePathTextBox.AutoCompleteMode = AutoCompleteMode.None;
            filePathTextBox.AutoCompleteSource = AutoCompleteSource.None;
            filePathTextBox.BackgroundImageLayout = ImageLayout.None;
            filePathTextBox.CharacterCasing = CharacterCasing.Normal;
            filePathTextBox.Depth = 0;
            filePathTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            filePathTextBox.HideSelection = true;
            filePathTextBox.LeadingIcon = null;
            filePathTextBox.Location = new Point(6, 41);
            filePathTextBox.MaxLength = 32767;
            filePathTextBox.MouseState = MaterialSkin.MouseState.OUT;
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.PasswordChar = '\0';
            filePathTextBox.PrefixSuffixText = null;
            filePathTextBox.ReadOnly = true;
            filePathTextBox.RightToLeft = RightToLeft.No;
            filePathTextBox.SelectedText = "";
            filePathTextBox.SelectionLength = 0;
            filePathTextBox.SelectionStart = 0;
            filePathTextBox.ShortcutsEnabled = true;
            filePathTextBox.Size = new Size(598, 48);
            filePathTextBox.TabIndex = 8;
            filePathTextBox.TabStop = false;
            filePathTextBox.TextAlign = HorizontalAlignment.Left;
            filePathTextBox.TrailingIcon = null;
            filePathTextBox.UseSystemPasswordChar = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(upload);
            groupBox2.Controls.Add(description);
            groupBox2.Controls.Add(materialLabel1);
            groupBox2.Controls.Add(fileSizeTextBox);
            groupBox2.Controls.Add(fileSize);
            groupBox2.Controls.Add(torrentName);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(6, 227);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(612, 349);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Torrent Properties";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // upload
            // 
            upload.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            upload.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            upload.Depth = 0;
            upload.HighEmphasis = true;
            upload.Icon = (Image)resources.GetObject("upload.Icon");
            upload.Location = new Point(7, 296);
            upload.Margin = new Padding(4, 6, 4, 6);
            upload.MouseState = MaterialSkin.MouseState.HOVER;
            upload.Name = "upload";
            upload.NoAccentTextColor = Color.Empty;
            upload.Size = new Size(104, 36);
            upload.TabIndex = 15;
            upload.Text = "Create";
            upload.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            upload.UseAccentColor = false;
            upload.UseVisualStyleBackColor = true;
            upload.Click += upload_Click;
            // 
            // description
            // 
            description.AnimateReadOnly = false;
            description.BackgroundImageLayout = ImageLayout.None;
            description.CharacterCasing = CharacterCasing.Normal;
            description.Depth = 0;
            description.HideSelection = true;
            description.Hint = "Add description..";
            description.Location = new Point(6, 187);
            description.MaxLength = 32767;
            description.MouseState = MaterialSkin.MouseState.OUT;
            description.Name = "description";
            description.PasswordChar = '\0';
            description.ReadOnly = false;
            description.ScrollBars = ScrollBars.None;
            description.SelectedText = "";
            description.SelectionLength = 0;
            description.SelectionStart = 0;
            description.ShortcutsEnabled = true;
            description.Size = new Size(600, 100);
            description.TabIndex = 14;
            description.TabStop = false;
            description.TextAlign = HorizontalAlignment.Left;
            description.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(6, 165);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(81, 19);
            materialLabel1.TabIndex = 13;
            materialLabel1.Text = "Description";
            // 
            // fileSizeTextBox
            // 
            fileSizeTextBox.AnimateReadOnly = false;
            fileSizeTextBox.AutoCompleteMode = AutoCompleteMode.None;
            fileSizeTextBox.AutoCompleteSource = AutoCompleteSource.None;
            fileSizeTextBox.BackgroundImageLayout = ImageLayout.None;
            fileSizeTextBox.CharacterCasing = CharacterCasing.Normal;
            fileSizeTextBox.Depth = 0;
            fileSizeTextBox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            fileSizeTextBox.HideSelection = true;
            fileSizeTextBox.LeadingIcon = null;
            fileSizeTextBox.Location = new Point(6, 114);
            fileSizeTextBox.MaxLength = 32767;
            fileSizeTextBox.MouseState = MaterialSkin.MouseState.OUT;
            fileSizeTextBox.Name = "fileSizeTextBox";
            fileSizeTextBox.PasswordChar = '\0';
            fileSizeTextBox.PrefixSuffixText = null;
            fileSizeTextBox.ReadOnly = true;
            fileSizeTextBox.RightToLeft = RightToLeft.No;
            fileSizeTextBox.SelectedText = "";
            fileSizeTextBox.SelectionLength = 0;
            fileSizeTextBox.SelectionStart = 0;
            fileSizeTextBox.ShortcutsEnabled = true;
            fileSizeTextBox.Size = new Size(86, 48);
            fileSizeTextBox.TabIndex = 12;
            fileSizeTextBox.TabStop = false;
            fileSizeTextBox.TextAlign = HorizontalAlignment.Left;
            fileSizeTextBox.TrailingIcon = null;
            fileSizeTextBox.UseSystemPasswordChar = false;
            // 
            // fileSize
            // 
            fileSize.AutoSize = true;
            fileSize.Depth = 0;
            fileSize.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            fileSize.Location = new Point(6, 92);
            fileSize.MouseState = MaterialSkin.MouseState.HOVER;
            fileSize.Name = "fileSize";
            fileSize.Size = new Size(60, 19);
            fileSize.TabIndex = 11;
            fileSize.Text = "File Size";
            // 
            // torrentName
            // 
            torrentName.AnimateReadOnly = false;
            torrentName.AutoCompleteMode = AutoCompleteMode.None;
            torrentName.AutoCompleteSource = AutoCompleteSource.None;
            torrentName.BackgroundImageLayout = ImageLayout.None;
            torrentName.CharacterCasing = CharacterCasing.Normal;
            torrentName.Depth = 0;
            torrentName.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            torrentName.HideSelection = true;
            torrentName.LeadingIcon = null;
            torrentName.Location = new Point(6, 41);
            torrentName.MaxLength = 32767;
            torrentName.MouseState = MaterialSkin.MouseState.OUT;
            torrentName.Name = "torrentName";
            torrentName.PasswordChar = '\0';
            torrentName.PrefixSuffixText = null;
            torrentName.ReadOnly = false;
            torrentName.RightToLeft = RightToLeft.No;
            torrentName.SelectedText = "";
            torrentName.SelectionLength = 0;
            torrentName.SelectionStart = 0;
            torrentName.ShortcutsEnabled = true;
            torrentName.Size = new Size(598, 48);
            torrentName.TabIndex = 10;
            torrentName.TabStop = false;
            torrentName.TextAlign = HorizontalAlignment.Left;
            torrentName.TrailingIcon = null;
            torrentName.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(6, 19);
            label1.MouseState = MaterialSkin.MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(98, 19);
            label1.TabIndex = 9;
            label1.Text = "Torrent Name";
            // 
            // FormNewTorrent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(624, 585);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MaximumSize = new Size(624, 585);
            MinimumSize = new Size(624, 585);
            Name = "FormNewTorrent";
            Text = "Create New Torrent";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
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