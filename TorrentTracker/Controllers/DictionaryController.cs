

using Newtonsoft.Json;

namespace TorrentTracker.Controllers
{
    public class DictionaryController
    {
        public Dictionary<Peer, List<TorrentFile>> _torrentDictionary = new Dictionary<Peer, List<TorrentFile>>();
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
                Dictionary<Peer, List<TorrentFile>>_dictionaryFromFile = JsonConvert.DeserializeObject<Dictionary<Peer, List<TorrentFile>>>(json);
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
            File.WriteAllText(filename, string.Empty);
            string json = JsonConvert.SerializeObject(_torrentDictionary);
            File.WriteAllText(filename, json);
        }
    }
}
