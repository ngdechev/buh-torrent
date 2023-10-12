

using PeerSoftware;

namespace TorrentTracker.Controllers
{
    public class DictionaryController
    {
        private Dictionary<Peer, List<TorrentFile>> _torrentDictionary = new Dictionary<Peer, List<TorrentFile>>();
        object _lock = new object();
        public DictionaryController()
        {
            _torrentDictionary = new Dictionary<Peer, List<TorrentFile>>();
        }

        public Dictionary<Peer, List<TorrentFile>> GetDictionary()
        {
            return _torrentDictionary;
        }
        public void SetDictionary(Dictionary<Peer, List<TorrentFile>> torrentDictionary)
        { 
            _torrentDictionary=torrentDictionary;
        }
        public object GetLock()
        {
            return this._lock;
        }
    }
}
