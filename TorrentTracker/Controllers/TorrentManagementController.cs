namespace TorrentTracker.Controllers
{
    public class TorrentManagementController : ITorrentManagementController
    {
        private Dictionary<Peer, List<Torrent>> _torrentDictionary;
        private List<Torrent> _AllTorrents = new List<Torrent>();

        public void SetD(Dictionary<Peer, List<Torrent>> torrentDictionary)
        {
            _torrentDictionary = torrentDictionary;
        }
        public List<Torrent> GetAllTorrents()
        {
            return _AllTorrents;
        }
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

        public List<Torrent> ListTorrents(Dictionary<Peer, List<Torrent>> _torrentDictionary)
        {
            _AllTorrents.Clear();
            foreach (var pair in _torrentDictionary)
            {
                List<Torrent> TorrentsList = pair.Value;
                foreach (Torrent torrent in TorrentsList)
                {
                    _AllTorrents.Add(torrent);
                }
            }
            return _AllTorrents;
        }

        public string SearchTorrent(string torrentName)
        {
            throw new NotImplementedException();
        }
    }
}
