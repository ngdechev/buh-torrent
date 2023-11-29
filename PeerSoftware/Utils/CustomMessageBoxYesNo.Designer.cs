using MaterialSkin.Controls;

namespace PeerSoftware.Utils
{
    partial class CustomMessageBoxYesNo : MaterialForm
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
            btnYes = new MaterialSkin.Controls.MaterialButton();
            btnNo = new MaterialSkin.Controls.MaterialButton();
            msg = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnYes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYes.Depth = 0;
            btnYes.HighEmphasis = true;
            btnYes.Icon = null;
            btnYes.Location = new Point(144, 230);
            btnYes.Margin = new Padding(4, 6, 4, 6);
            btnYes.MouseState = MaterialSkin.MouseState.HOVER;
            btnYes.Name = "btnYes";
            btnYes.NoAccentTextColor = Color.Empty;
            btnYes.Size = new Size(64, 36);
            btnYes.TabIndex = 0;
            btnYes.Text = "Yes";
            btnYes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYes.UseAccentColor = false;
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnNo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNo.Depth = 0;
            btnNo.HighEmphasis = true;
            btnNo.Icon = null;
            btnNo.Location = new Point(216, 230);
            btnNo.Margin = new Padding(4, 6, 4, 6);
            btnNo.MouseState = MaterialSkin.MouseState.HOVER;
            btnNo.Name = "btnNo";
            btnNo.NoAccentTextColor = Color.Empty;
            btnNo.Size = new Size(64, 36);
            btnNo.TabIndex = 1;
            btnNo.Text = "No";
            btnNo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNo.UseAccentColor = false;
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // msg
            // 
            msg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            msg.Depth = 0;
            msg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            msg.Location = new Point(6, 64);
            msg.MouseState = MaterialSkin.MouseState.HOVER;
            msg.Name = "msg";
            msg.Size = new Size(400, 208);
            msg.TabIndex = 2;
            msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(412, 275);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(msg);
            MaximizeBox = false;
            MaximumSize = new Size(412, 275);
            MinimizeBox = false;
            MinimumSize = new Size(412, 275);
            Name = "CustomMessageBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CustomMessageBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnYes;
        private MaterialSkin.Controls.MaterialButton btnNo;
        public MaterialSkin.Controls.MaterialLabel msg;
    }
}