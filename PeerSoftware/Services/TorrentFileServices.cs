

using PeerSoftware.Storage;
using PeerSoftware.Utils;
using PTT_Parser;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Threading;
using System.Windows.Forms;

namespace PeerSoftware.Services
{
    public class TorrentFileServices
    {
        public List<TorrentFile> SearchTorrentFiles(string searchTerm, ref int resultMaxPage, ref bool searchOnFlag, List<TorrentFile> allTorrentFiles)
        {
            // Convert the search term to lowercase for case-insensitive search
            searchTerm = searchTerm.ToLower();

            // Use LINQ to filter torrentFiles based on the search term in filename or description
            List<TorrentFile> searchResults = allTorrentFiles
                .Where(file =>
                    file.info.fileName.ToLower().Contains(searchTerm) ||
                    file.info.description.ToLower().Contains(searchTerm))
                .ToList();
            resultMaxPage = (int)Math.Ceiling(searchResults.Count / 5.0);
            searchOnFlag = true;

            return searchResults;
        }

        public void LoadData(ITorrentStorage torrentStorage, Form1 form1, ref int allPageMax)
        {
            torrentStorage.GetAllTorrentFiles().Clear();

            try
            {
                PTTBlock block = new PTTBlock(0x04, 0, null);

                int maxPage = allPageMax; 

                Connections connections = new Connections(torrentStorage);
                Thread thread = new Thread(() => connections.SendAndRecieveData(block, form1, ref maxPage));

                thread.Start();

                allPageMax = maxPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
