

using System.Data;
using System.Text.Json;

namespace TorrentTracker.Controllers
{
    public class TorrentManagementController : ITorrentManagementController
    {
        private DictionaryController _dictionaryController;
        private List<Torrent> _AllTorrents = new List<Torrent>();
        private string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "TorrentFile");
        public TorrentManagementController(DictionaryController dictionaryController)
        {
            _dictionaryController = dictionaryController;
        }
        public TorrentManagementController(string folderPath)
        {
            this.folderPath = folderPath;
            _AllTorrents = new List<Torrent>();
        }
        public List<Torrent> GetAllTorrents()
        {
            return _AllTorrents;
        }

        public string CreateTorrent(string ip, string torrentFile)
        {
            TorrentFile NewTorrent = JsonSerializer.Deserialize<TorrentFile>(torrentFile);
            string[] addres = ip.Split(':', 2);
            int.TryParse(addres[1], out int int_port);
            if (_dictionaryController.GetDictionary().Count == 0)
            {
                List<TorrentFile> torrents = new List<TorrentFile>
                {
                    NewTorrent
                };
                _dictionaryController.GetDictionary().Add(new Peer(1, addres[0], int_port), torrents);
                string filePath = Path.Combine(folderPath, NewTorrent.info.torrentName + ".json");
                File.WriteAllText(filePath, torrentFile);
                return;
            }
            foreach (var pair in _dictionaryController.GetDictionary())
            {
                if (ip == pair.Key.IPAddress)
                {
                    pair.Value.Add(NewTorrent);
                    string filePath = Path.Combine(folderPath, NewTorrent.info.torrentName+ ".json");
                    File.WriteAllText(filePath, torrentFile);
                }
                else
                {
                    break;
                }
            }

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
                            Torrent torrent = JsonSerializer.Deserialize<Torrent>(jsonText);
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
