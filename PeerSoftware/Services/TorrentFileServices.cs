using PeerSoftware.Storage;
using PeerSoftware.Utils;
using PTP_Parser;
using PTT_Parser;
using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text.Json;
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
                    file.info.torrentName.ToLower().Contains(searchTerm) ||
                    file.info.description.ToLower().Contains(searchTerm))
                .ToList();
            resultMaxPage = (int)Math.Ceiling(searchResults.Count / 5.0);
            searchOnFlag = true;

            return searchResults;
        }

        public void LoadData(ITorrentStorage torrentStorage, NetworkUtils networkUtils, Form1 form1 )
        {
            torrentStorage.GetAllTorrentFiles().Clear();

            try
            {
                PTTBlock block = new PTTBlock(0x04, 0, null);

                Connections connections = new Connections(networkUtils);
                Thread thread = new Thread(() => connections.SendAndRecieveData(block, form1, torrentStorage));

                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
