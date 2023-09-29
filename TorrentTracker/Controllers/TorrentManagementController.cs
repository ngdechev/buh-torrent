

namespace TorrentTracker.Controllers
{
    public class TorrentManagementController : ITorrentManagementController
    {
        private DictionaryController _dictionaryController;
        private List<Torrent> _AllTorrents = new List<Torrent>();

        public TorrentManagementController(DictionaryController dictionaryController)
        {
            _dictionaryController = dictionaryController;
        }

        public List<Torrent> GetAllTorrents()
        {
            return _AllTorrents;
        }

        public string CreateTorrent(string ip, string torrentFile)
        {
            throw new NotImplementedException();
        }

        public string DeleteTorrent(string ip, string checksum)
        {
            throw new NotImplementedException();
        }

        public List<Torrent> ListTorrents()
        {
            _AllTorrents.Clear();

            foreach (var pair in _dictionaryController.GetDictionary())
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
