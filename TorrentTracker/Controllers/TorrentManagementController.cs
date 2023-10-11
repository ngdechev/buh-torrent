

using System;
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

        public void CreateTorrent(string ip,string torrentFile)
        {
            Torrent NewTorrent = JsonSerializer.Deserialize<Torrent>(torrentFile);
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
                foreach (Torrent torrent in pair.Value)
                {
                    if (checksum == torrent.checkSum)
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


        public Torrent SearchTorrent(string torrentName)

        {
            Torrent foundTorrent = _AllTorrents.Find(torrent => torrent.torrentName == torrentName);

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
