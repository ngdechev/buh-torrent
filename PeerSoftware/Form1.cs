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

        private List<Control> _titleControls = new List<Control>();
        private List<Control> _sizeControls = new List<Control>();
        private List<Control> _descriptionControls = new List<Control>();
        private List<Control> _downloadControls = new List<Control>();
        
        private List<TorrentFile> _allTorrentFiles = new List<TorrentFile>();
        private int _allPage = 0;
        private int _allMaxPage = 0;
        
        private List<TorrentFile> _resultTorrentFiles = new List<TorrentFile>();
        private int _resultPage = 0;
        private int _resultMaxPage = 0;
        private bool _searchOnFlag = false;

        public Form1()
        {
            InitializeComponent();
            SplitIpAndPort();

            _trackerIpField = trackerIP.Text;
            _allTorrentFiles = new List<TorrentFile>();

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

                _titleControls.Add(titleLabel);
                _sizeControls.Add(sizeLabel);
                _descriptionControls.Add(descriptionLabel);
                _downloadControls.Add(button);

            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            _resultTorrentFiles = SearchTorrentFiles(searchBar.Text);
            Show(_resultPage, _resultTorrentFiles);
        }


        private void refresh_Click(object sender, EventArgs e)
        {
            _searchOnFlag = false;
            Show(_allPage, _allTorrentFiles);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!_searchOnFlag)
            {
                if (_allPage - 1 >= 0)
                {
                    _allPage--;
                    pagelabel.Text = "Page Number " + _allPage.ToString();
                }
                Show(_allPage, _allTorrentFiles);
            }
            else
            {
                if (_resultPage - 1 >= 0)
                {
                    _resultPage--;
                    pagelabel.Text = "Page Number " + _resultPage.ToString();
                }
                Show(_resultPage, _resultTorrentFiles);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!_searchOnFlag)
            {
                if (_allPage + 1 < _allMaxPage)
                {
                    _allPage++;
                    pagelabel.Text = "Page Number " + _allPage.ToString();
                }
                Show(_allPage, _allTorrentFiles);
            }
            else
            {
                if (_resultPage + 1 < _resultMaxPage)
                {
                    _resultPage++;
                    pagelabel.Text = "Page Number " + _resultPage.ToString();
                }
                Show(_resultPage, _resultTorrentFiles);
            }

        }
        void Show(int i, List<TorrentFile> torrentFiles)
        {
            int row = i * 5;
            for (int index = 0; index < _titleControls.Count; index++)
            {
                if (index + row < torrentFiles.Count)
                {
                    Control titleControl = _titleControls[index];
                    Control sizeControl = _sizeControls[index];
                    Control descriptionControl = _descriptionControls[index];

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
                    Control titleControl = _titleControls[index];
                    Control sizeControl = _sizeControls[index];
                    Control descriptionControl = _descriptionControls[index];

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
                _allTorrentFiles.Clear();

                // Iterate through the file names and display them
                foreach (string fileName in fileNames)
                {
                    TorrentFile torrentFile = TorrentReader.ReadFromJSON(fileName);
                    if (torrentFile != null)
                    {
                        _allTorrentFiles.Add(torrentFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _allMaxPage = _allTorrentFiles.Count / 5;
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
            List<TorrentFile> searchResults = _allTorrentFiles
                .Where(file =>
                    file.info.fileName.ToLower().Contains(searchTerm) ||
                    file.info.description.ToLower().Contains(searchTerm))
                .ToList();
            _resultMaxPage = searchResults.Count / 5;
            _searchOnFlag = true;
            return searchResults;
        }
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

        private void createNewTorrent_Click(object sender, EventArgs e)
        {
            FormNewTorrent formNewTorrent = new FormNewTorrent(this);
            formNewTorrent.ShowDialog();
        }

        public string TextForAnnoncer()
        {
            return trackerIP.Text;
        }
    }

}

