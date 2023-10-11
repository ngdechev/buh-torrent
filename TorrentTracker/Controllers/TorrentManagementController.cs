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

        public void CreateTorrent(string ip,string torrentFile)
        {
            TorrentFile NewTorrent = JsonSerializer.Deserialize<TorrentFile>(torrentFile);
            _AllTorrents.Add(NewTorrent);
            foreach (var pair in _dictionaryController.GetDictionary())
            {
                if (ip == pair.Key.ipAddress)
                {
                    pair.Value.Add(NewTorrent);
                }
                else
                {
                    break;
                }
            }
        }

        public void DeleteTorrent(string checksum)
        {
            foreach (var pair in _dictionaryController.GetDictionary())
            {
                foreach (TorrentFile torrent in pair.Value)
                {
                    if (checksum == torrent.info.checksum)
                    {
                        pair.Value.Remove(torrent);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public List<TorrentFile> ListTorrents()
        {
            //_AllTorrents.Clear();

            /*foreach (var pair in _dictionaryController.GetDictionary())
            {
                List<Torrent> TorrentsList = pair.Value;
                foreach (Torrent torrent in TorrentsList)
                {
                    _AllTorrents.Add(torrent);
                }
            }*/
            ReadTorrentFileFromFoulder();
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
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    try
                    {
                        string jsonText = File.ReadAllText(file);

                        TorrentFile? torrent = JsonSerializer.Deserialize<TorrentFile>(jsonText);

                        if (torrent != null)
                        {
                            _AllTorrents.Add(torrent);
                        }
                        /*using (StreamReader reader = new StreamReader(file))
                        {
                            string jsonText = reader.ReadToEnd();
                            TorrentFile torrent = JsonSerializer.Deserialize<TorrentFile>(jsonText);
                            _AllTorrents.Add(torrent);
                        }*/
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
