
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
        
                foreach (var pair in _dictionaryController.GetDictionary())
                {
                    if (addres[0] == pair.Key.IPAddress)
                    {
                        pair.Value.Add(NewTorrent.info.torrentName);
                        string filePath = Path.Combine(folderPath, NewTorrent.info.torrentName + ".json");
                        File.WriteAllText(filePath, torrentFile);
                    }
                   
                }
        } 

        public void DeleteTorrent(string ip, string checksum)
        {
            TorrentFile torrent = _AllTorrents.Find(t => t.info.checksum == checksum);
            foreach (var pair in _dictionaryController.GetDictionary())
            {
                foreach (string torrentNane in pair.Value)
                {
                    if (torrentNane == torrent.info.torrentName)
                    {
                        pair.Value.Remove(torrentNane);
                        RemoveTorrentFromDictionary(ip, torrent.info.torrentName);

                        return;
                    }
                }
            }
        }
        public void RemoveTorrentFromDictionary(string ip, string torrentNameToDelete)
        {
            foreach(var pair in _dictionaryController.GetDictionary())
            {
               if(ip == pair.Key.IPAddress)
               {
                    foreach (var torrentName in pair.Value)
                    {
                        if(torrentName == torrentNameToDelete)
                        {
                            pair.Value.Remove(torrentNameToDelete);
                            break;
                        }
                    }
                    break;
               }
            }
            _dictionaryController.WriteDictionaryToFile();
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
