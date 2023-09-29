namespace PeerSoftware
{
    public partial class Form1 : Form
    {
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
        }
    }
}