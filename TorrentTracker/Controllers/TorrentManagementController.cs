using PeerSoftware;
using System.Data;
using System.Text.Json;

namespace TorrentTracker.Controllers
{
    public class TorrentManagementController : ITorrentManagementController
    {
        private DictionaryController _dictionaryController;
        private List<TorrentFile> _AllTorrents = new List<TorrentFile>();
        private string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "TorrentFile");
        public TorrentManagementController(DictionaryController dictionaryController)
        {
            _dictionaryController = dictionaryController;
        }
        public TorrentManagementController(string folderPath)
        {
            this.folderPath = folderPath;
            _AllTorrents = new List<TorrentFile>();
        }
        public List<TorrentFile> GetAllTorrents()
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
        
        public List<TorrentFile> ListTorrents()
        {
            _AllTorrents.Clear();

            foreach (var pair in _dictionaryController.GetDictionary())
            {
                List<TorrentFile> TorrentsList = pair.Value;
                foreach (TorrentFile torrent in TorrentsList)
                {
                    _AllTorrents.Add(torrent);
                }
            }

            return _AllTorrents;
        }

        public TorrentFile SearchTorrent(string torrentName)
        {
            TorrentFile foundTorrent = _AllTorrents.Find(torrent => torrent.info.torrentName == torrentName);

            if (foundTorrent == null)
            {
                throw new Exception("Torrent file cannot be found.");
            }

            return foundTorrent;
        }

        public void ReadTorrentFileFromFoulder()
        {
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath, "*.json");

                foreach (string file in files)
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {
                            string jsonText = reader.ReadToEnd();
                            TorrentFile torrent = JsonSerializer.Deserialize<TorrentFile>(jsonText);
                            _AllTorrents.Add(torrent);
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("Error: " + exception);
                    }
                }
            }
            else
            {
                throw new Exception("Missing folder");
            }
        }
    }
}
