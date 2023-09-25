namespace TorrentTracker.Controllers
{
    internal interface ITorrentManagementController
    {

        public string CreateTorrent();

        public string DeleteTorrent();
        
        public string ListTorrents();
        
        public string SearchTorrent(string fileName);
    }
}
