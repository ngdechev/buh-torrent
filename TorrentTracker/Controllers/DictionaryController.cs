

using Newtonsoft.Json;

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
            _torrentDictionary = torrentDictionary;
        }
 
        public object GetLock()
        {
            return this._lock;
        }

        public void ReadDictionaryFromFile()
        {
            string filename = "Dictionary.json";
            if (File.Exists(filename))
            {

                string json = File.ReadAllText(filename);
                Dictionary<Peer, List<Torrent>>_dictionaryFromFile = JsonConvert.DeserializeObject<Dictionary<Peer, List<Torrent>>>(json);
                foreach (var pair in _dictionaryFromFile)
                {
                    _torrentDictionary.Add(pair.Key, pair.Value);
                }
            }
            else
            {
                throw new Exception("File does not exist.");
            }
        }

        public void WriteDictionaryToFile() 
        {
            string filename = "Dictionary.json";
            string json = JsonConvert.SerializeObject(_torrentDictionary);
            File.WriteAllText(filename, json);
        }
    }
}
