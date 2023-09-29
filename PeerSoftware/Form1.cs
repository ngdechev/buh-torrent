using PTT_Parser;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace PeerSoftware
{
    public partial class Form1 : Form
    {

        private TcpClient _client;
        private NetworkStream _stream;
        private string _currentIpAddress;
        private bool _isConnected;
        private string _trackerIpField;
        private int _trackerPortField;

        private List<Control> titleControls = new List<Control>();
        private List<Control> sizeControls = new List<Control>();
        private List<Control> descriptionControls = new List<Control>();
        private List<Control> downloadControls = new List<Control>();
        private List<TorrentFile> allTorrentFiles = new List<TorrentFile>();
        int allPage = 0;
        int allMaxPage = 0;
        private List<TorrentFile> resultTorrentFiles = new List<TorrentFile>();
        int resultPage = 0;
        int resultMaxPage = 0;
        bool searchOnFlag = false;
        public Form1()
        {
            InitializeComponent();
            SplitIpAndPort();

            _trackerIpField = trackerIP.Text;
            allTorrentFiles = new List<TorrentFile>();
          
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

        private void search_Click(object sender, EventArgs e)
        {
            resultTorrentFiles = SearchTorrentFiles(searchBar.Text);
            Show(allPage, resultTorrentFiles);
        }


        private void refresh_Click(object sender, EventArgs e)
        {
            searchOnFlag = false;
            Show(allPage, allTorrentFiles);
        }

        public void SetTrackerIp(string ip)
        {
            trackerIP.Text = ip;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(searchOnFlag)
            {
                if (allPage - 1 >= 0)
                {
                    allPage--;
                    pagelabel.Text = "Page Number " + allPage.ToString();
                }
                Show(allPage, allTorrentFiles);
            }
            else
            {
                if (resultPage - 1 >= 0)
                {
                    resultPage--;
                    pagelabel.Text = "Page Number " + resultPage.ToString();
                }
                Show(resultPage, resultTorrentFiles);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (searchOnFlag)
            {
                if (allPage + 1 < allMaxPage)
                {
                    allPage++;
                    pagelabel.Text = "Page Number " + allPage.ToString();
                }
                Show(allPage, allTorrentFiles);
            }
            else
            {
                if (resultPage + 1 < resultMaxPage)
                {
                    resultPage++;
                    pagelabel.Text = "Page Number " + resultPage.ToString();
                }
                Show(resultPage, resultTorrentFiles);
            }
            
        }
        void Show(int i , List<TorrentFile> torrentFiles)
        {
            int row = i * 5;
            for (int index = 0; index < titleControls.Count; index++)
            {
                if (index + row < torrentFiles.Count)
                {
                    Control titleControl = titleControls[index];
                    Control sizeControl = sizeControls[index];
                    Control descriptionControl = descriptionControls[index];

                    if (titleControl != null)
                    {
                        titleControl.Text = torrentFiles[index + row].info.fileName;
                    }

                    if (sizeControl != null)
                    {
                        sizeControl.Text = torrentFiles[index + row].info.length.ToString();
                    }

                    if (descriptionControl != null)
                    {
                        descriptionControl.Text = torrentFiles[index + row].info.description;
                    }
                }
                else
                {
                    // If there are no more items in torrentFiles, clear the text of the controls
                    Control titleControl = titleControls[index];
                    Control sizeControl = sizeControls[index];
                    Control descriptionControl = descriptionControls[index];

                    if (titleControl != null)
                    {
                        titleControl.Text = "";
                    }

                    if (sizeControl != null)
                    {
                        sizeControl.Text = "";
                    }

                    if (descriptionControl != null)
                    {
                        descriptionControl.Text = "";
                    }
                }
            }
        }

        void LoadData()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentDirectory, "TestData");

            try
            {
                // Get an array of file names in the folder
                string[] fileNames = Directory.GetFiles(folderPath);

                // Clear the previous torrentFiles list
                allTorrentFiles.Clear();

                // Iterate through the file names and display them
                foreach (string fileName in fileNames)
                {
                    TorrentFile torrentFile = TorrentReader.ReadFromJSON(fileName);
                    if (torrentFile != null)
                    {
                        allTorrentFiles.Add(torrentFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            allMaxPage = allTorrentFiles.Count / 5;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                LoadData();
            }

        }
        private List<TorrentFile> SearchTorrentFiles(string searchTerm)
        {
            // Convert the search term to lowercase for case-insensitive search
            searchTerm = searchTerm.ToLower();

            // Use LINQ to filter torrentFiles based on the search term in filename or description
            List<TorrentFile> searchResults = allTorrentFiles
                .Where(file =>
                    file.info.fileName.ToLower().Contains(searchTerm) ||
                    file.info.description.ToLower().Contains(searchTerm))
                .ToList();
            resultMaxPage = searchResults.Count / 5;
            searchOnFlag = true;
            return searchResults;

        public void SendPTTMessage(string command, string payload)
        {
            var pttBlock = new PTTBlock(command, payload);
            string pttMessage = PTT.ParseToString(pttBlock);

            byte[] messageBytes = Encoding.ASCII.GetBytes(pttMessage);
            _stream.Write(messageBytes, 0, messageBytes.Length);
        }

        

        public PTTBlock ReceivePTTMessage()
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

        // For Unit Tests
        public void SetTrackerIp(string ip)
        {
            trackerIP.Text = ip;
        }

        private void search_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            //tableLayoutPanel2.GetRow
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                CloseConnection();
            }

            (_trackerIpField, _trackerPortField) = SplitIpAndPort();

            if (IPAddress.TryParse(_trackerIpField, out IPAddress ipAddress))
            {
                try
                {
                    _client = new TcpClient(_trackerIpField, _trackerPortField);
                    _stream = _client.GetStream();

                    MessageBox.Show($"Connected to {_trackerIpField}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error connecting to {_trackerIpField}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid IP address or port. Please enter a valid IP address and port.");
            }
        }

    }

}