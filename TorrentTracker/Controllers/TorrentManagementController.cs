namespace TorrentTracker.Controllers
{
    public class TorrentManagementController : ITorrentManagementController
    {
        private Dictionary<Peer, List<Torrent>> _torrentDictionary;

        public TorrentManagementController()
        {
            _torrentDictionary = new Dictionary<Peer, List<Torrent>>();
        }

        public string CreateTorrent()
        {
            throw new NotImplementedException();
        }

        public string DeleteTorrent()
        {
            throw new NotImplementedException();
        }

        public string ListTorrents()
        {
            throw new NotImplementedException();
        }

        public string SearchTorrent(string torrentName)
        {
            throw new NotImplementedException();
        }
    }
}
