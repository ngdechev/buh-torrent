

namespace TorrentTracker.Controllers
{
    public class DictionaryController
    {
        private Dictionary<Peer, List<Torrent>> _torrentDictionary = new Dictionary<Peer, List<Torrent>>();
        object _lock = new object();
        public DictionaryController()
        {
            _torrentDictionary = new Dictionary<Peer, List<Torrent>>();
        }

        public Dictionary<Peer, List<Torrent>> GetDictionary()
        {
            return _torrentDictionary;
        }
        public void SetDictionary(Dictionary<Peer, List<Torrent>> torrentDictionary)
        { 
            _torrentDictionary=torrentDictionary;
        }
        public object GetLock()
        {
            return this._lock;
        }
    }
}
