using Newtonsoft.Json;
using System;

using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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


        public List<TorrentFile> GetAllTorrents()
        {
            _AllTorrents.Clear();
            ReadTorrentFileFromFoulder();
            return _AllTorrents;
        }

        public void CreateTorrent(string ip,string torrentFile)
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

                _dictionaryController.GetDictionary().Add(new Peer(1, addres[0], int_port, DateTime.Now), torrents);
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

        public void DeleteTorrent(string ip, string checksum)


        {
            foreach (var pair in _dictionaryController.GetDictionary())
            {
                foreach (TorrentFile torrent in pair.Value)

                {
                    if (checksum == torrent.info.checksum)
                    {
                        pair.Value.Remove(torrent);
                        RemoveTorrentFromDictionary(checksum);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public void RemoveTorrentFromDictionary(string checksum)
        {
                string jsonContent = File.ReadAllText("Dictionary.json");
                List<TorrentFile> torrents = JsonConvert.DeserializeObject<List<TorrentFile>>(jsonContent);
                TorrentFile torrentToRemove = torrents.FirstOrDefault(t => t.info.checksum == checksum);
                if (torrentToRemove != null)
                {
                    torrents.Remove(torrentToRemove);
                }
                string updatedJsonContent = JsonConvert.SerializeObject(torrents, Formatting.Indented);
                File.WriteAllText("Dictionary.json", updatedJsonContent);            
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
