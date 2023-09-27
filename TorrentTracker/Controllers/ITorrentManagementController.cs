namespace TorrentTracker.Controllers
{
    internal interface ITorrentManagementController
    {

        public string CreateTorrent();

        public string DeleteTorrent();

        public List<Torrent> ListTorrents(Dictionary<Peer, List<Torrent>> _torrentDictionary);

        public string SearchTorrent(string torrentName);
    }
}
