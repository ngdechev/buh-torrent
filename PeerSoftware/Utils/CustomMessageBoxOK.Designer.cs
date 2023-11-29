namespace PeerSoftware.Utils
{
    partial class CustomMessageBoxOK
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
            msg = new MaterialSkin.Controls.MaterialLabel();
            btnOK = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
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
            // btnOK
            // 
            btnOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOK.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOK.Depth = 0;
            btnOK.HighEmphasis = true;
            btnOK.Icon = null;
            btnOK.Location = new Point(183, 230);
            btnOK.Margin = new Padding(4, 6, 4, 6);
            btnOK.MouseState = MaterialSkin.MouseState.HOVER;
            btnOK.Name = "btnOK";
            btnOK.NoAccentTextColor = Color.Empty;
            btnOK.Size = new Size(64, 36);
            btnOK.TabIndex = 3;
            btnOK.Text = "Ok";
            btnOK.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOK.UseAccentColor = false;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // CustomMessageBoxOK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(412, 275);
            Controls.Add(btnOK);
            Controls.Add(msg);
            MaximizeBox = false;
            MaximumSize = new Size(412, 275);
            MinimizeBox = false;
            MinimumSize = new Size(412, 275);
            Name = "CustomMessageBoxOK";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CustomMessageBoxOK";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        public MaterialSkin.Controls.MaterialLabel msg;
        private MaterialSkin.Controls.MaterialButton btnOK;
    }
}