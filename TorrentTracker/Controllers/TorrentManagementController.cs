

using System.Data;
using System.Text.Json;

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

        public void ReadTorrentFileFromFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentDirectory, "TorrentFile");

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    try
                    {
                        string jsonText = File.ReadAllText(file);
                        Torrent torrent = JsonSerializer.Deserialize<Torrent>(jsonText);
                        _AllTorrents.Add(torrent);
                    }
                    catch (Exception ecxeption)
                    {
                        throw new Exception("Error: " + ecxeption);
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
