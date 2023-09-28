namespace PeerSoftware
{
    public partial class Form1 : Form
    {
        private List<Control> titleControls = new List<Control>();
        private List<Control> sizeControls = new List<Control>();
        private List<Control> descriptionControls = new List<Control>();
        private List<Control> downloadControls = new List<Control>();
        private List<TorrentFile> torrentFiles = new List<TorrentFile>();
        int page = 0;
        int maxpage = 0;
        public Form1()
        {
            InitializeComponent();
            torrentFiles = new List<TorrentFile>();
            for (int i = 0; i < 5; i++)
            {
                Label titleLabel = new Label();
                Label sizeLabel = new Label();
                Label descriptionLabel = new Label(); // Corrected the variable name
                Button button = new Button();
                button.Text = "Download";
                tableLayoutPanel2.Controls.Add(titleLabel, 0, i);
                tableLayoutPanel2.Controls.Add(sizeLabel, 1, i);
                tableLayoutPanel2.Controls.Add(descriptionLabel, 2, i); // Corrected the index
                tableLayoutPanel2.Controls.Add(button, 3, i);
                titleControls.Add(titleLabel);
                sizeControls.Add(sizeLabel);
                descriptionControls.Add(descriptionLabel);
                downloadControls.Add(button);
            }
        }

        /* public PTTBlock ReceivePTTMessage()
         {
             return PTT.ParseToBlock(_stream);
         }

         public void CloseConnection()
         {
             _stream.Close();
             _client.Close();

             _currentIpAddress = _trackerIpField;
             _isConnected = false;
         }

         public (string, int) SplitIpAndPort()
         {
             if (_trackerIpField == null)
             {
                 return (string.Empty, 0);
             }

             string[] parts = _trackerIpField.Split(':');

             string ipAddressString = null;
             int port = 0;

             if (parts.Length == 2)
             {
                 ipAddressString = parts[0];

                 if (int.TryParse(parts[1], out int parsedPort))
                 {
                     port = parsedPort;
                 }
                 else
                 {
                     port = 12345;
                 }
             }

             return (ipAddressString, port);
         }
 */
        // For Unit Tests


        private void search_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\zlati\source\repos\buh-torrent\PeerSoftware\TestData";

            try
            {
                // Get an array of file names in the folder
                string[] fileNames = Directory.GetFiles(folderPath);

                // Clear the previous torrentFiles list
                torrentFiles.Clear();

                // Iterate through the file names and display them
                foreach (string fileName in fileNames)
                {
                    TorrentFile torrentFile = TorrentReader.ReadFromJSON(fileName);
                    if (torrentFile != null)
                    {
                        torrentFiles.Add(torrentFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            maxpage = torrentFiles.Count/5;
            Show(page);
        }


        private void refresh_Click(object sender, EventArgs e)
        {
            // Your refresh logic here
        }

        public void SetTrackerIp(string ip)
        {
            trackerIP.Text = ip;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(page > 0)
            {
                page--;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page < maxpage)
            {
                page++;
            }
        }
        void Show(int i)
        {

            int row = i;
            foreach (Control control in titleControls)
            {
                control.Text = /*row.ToString();*/row < torrentFiles.Count ? torrentFiles[row].Info.FileName : "";
                row++;
            }

            row = i;
            foreach (Control control in sizeControls)
            {
                control.Text = /*row.ToString();*/row < torrentFiles.Count ? torrentFiles[row].Info.Length.ToString() : "";
                row++;
            }

            row = i;
            foreach (Control control in descriptionControls)
            {
                control.Text = /*row.ToString();*/row < torrentFiles.Count ? torrentFiles[row].Info.Description : "";
                row++;
            }
        }
    }
}