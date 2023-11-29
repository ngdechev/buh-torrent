using MaterialSkin.Controls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PeerSoftware.Utils
{
    public partial class CustomMessageBoxYesNo : MaterialForm
    {
        public CustomMessageBoxYesNo(Form1 form1)
        {
            InitializeComponent();


        }

        public void SetTitle(string title)
        {
            Text = title;
        }

        public void SetMessageText(string message)
        {
            msg.Text = message;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }

}
