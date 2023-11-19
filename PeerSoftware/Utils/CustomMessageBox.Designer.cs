namespace PeerSoftware.Utils
{
    partial class CustomMessageBox
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
            this.btnYes = new MaterialSkin.Controls.MaterialButton();
            this.btnNo = new MaterialSkin.Controls.MaterialButton();
            this.msg = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYes.Depth = 0;
            this.btnYes.HighEmphasis = true;
            this.btnYes.Icon = null;
            this.btnYes.Location = new System.Drawing.Point(147, 230);
            this.btnYes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYes.Name = "btnYes";
            this.btnYes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYes.Size = new System.Drawing.Size(64, 36);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Yes";
            this.btnYes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYes.UseAccentColor = false;
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNo.Depth = 0;
            this.btnNo.HighEmphasis = true;
            this.btnNo.Icon = null;
            this.btnNo.Location = new System.Drawing.Point(219, 230);
            this.btnNo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNo.Name = "btnNo";
            this.btnNo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNo.Size = new System.Drawing.Size(64, 36);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNo.UseAccentColor = false;
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // msg
            // 
            this.msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msg.Depth = 0;
            this.msg.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.msg.Location = new System.Drawing.Point(-1, 64);
            this.msg.MouseState = MaterialSkin.MouseState.HOVER;
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(413, 217);
            this.msg.TabIndex = 2;
            this.msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 275);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.msg);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(412, 275);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(412, 275);
            this.Name = "CustomMessageBox";
            this.Text = "CustomMessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnYes;
        private MaterialSkin.Controls.MaterialButton btnNo;
        public MaterialSkin.Controls.MaterialLabel msg;
    }
}