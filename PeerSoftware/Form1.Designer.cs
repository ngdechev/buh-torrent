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
            tabPage1 = new TabPage();
            button4 = new Button();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            button1 = new Button();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(799, 448);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(791, 420);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "BuhTorrent";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(713, 116);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 10;
            button4.Text = "Pause All";
            button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 127);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 9;
            label2.Text = "Progress";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 127);
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
            tableLayoutPanel1.Controls.Add(checkBox1, 2, 0);
            tableLayoutPanel1.Location = new Point(4, 145);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.5F));
            tableLayoutPanel1.Size = new Size(784, 216);
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
            label3.Location = new Point(4, 6);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 9;
            label3.Text = "Torrent Name 2023";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(710, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(57, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Pause";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(4, 64);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 23);
            comboBox1.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(213, 63);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "Download";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(213, 35);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(201, 23);
            textBox2.TabIndex = 2;
            textBox2.Text = "Search Files by Name..";
            // 
            // button1
            // 
            button1.Location = new Point(213, 6);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Tracker IP Address..";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(791, 420);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(791, 420);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Help";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 396);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "BuhTorrent";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button3;
        private Button button2;
        private TextBox textBox2;
        private Button button1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private TabPage tabPage3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private ProgressBar progressBar1;
        private Label label3;
        private CheckBox checkBox1;
        private Button button4;
    }
}