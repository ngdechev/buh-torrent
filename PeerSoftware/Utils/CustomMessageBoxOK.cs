using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeerSoftware.Utils
{
    public partial class CustomMessageBoxOK : MaterialForm
    {
        public CustomMessageBoxOK()
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
