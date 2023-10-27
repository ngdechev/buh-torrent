


using Newtonsoft.Json;


namespace TorrentTracker.Controllers
{
    public class DictionaryController
    {

        public Dictionary<Peer, List<string>> _torrentDictionary = new Dictionary<Peer, List<string>>();
        private string filename = "Dictionary.json";
        object _lock = new object();
       
        public DictionaryController()
        {
            _torrentDictionary = new Dictionary<Peer, List<string>>();
        }

        public Dictionary<Peer, List<string>> GetDictionary()
        {
            return _torrentDictionary;
        }
        
        public object GetLock()
        {
            return this._lock;
        }

        public void ReadDictionaryFromFile()
        {
            _torrentDictionary.Clear();
            if (File.Exists(filename))
            {
                if (new FileInfo(filename).Length == 0)
                {
                    Console.WriteLine("Load Dictionary");
                }
                else
                {
                    string json = File.ReadAllText(filename);
                    Dictionary<string, List<string>> dictionaryFromFile = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
                    foreach (var pair in dictionaryFromFile)
                    {
                        string key = pair.Key;
                        string[] addres = key.Split(' ', 3);
                        Peer peer = new Peer(int.Parse(addres[0]), addres[1], int.Parse(addres[2]), DateTime.UtcNow);
                        _torrentDictionary.Add(peer, pair.Value);
                    }
                }
            }
            else
            {
                throw new Exception("File does not exist.");
            }
        }

        public void WriteDictionaryToFile() 
        {
            File.WriteAllText(filename, string.Empty);
            Dictionary<string,List<string>>dictionaryForFale = new Dictionary<string,List<string>>();
            foreach (var pair in _torrentDictionary)
            {
                    dictionaryForFale.Add(pair.Key.ToString(), pair.Value);
            }
            string json = JsonConvert.SerializeObject(dictionaryForFale);
            File.WriteAllText(filename, json);
            dictionaryForFale.Clear();
            //_torrentDictionary.Clear();
        }   
    }
}
