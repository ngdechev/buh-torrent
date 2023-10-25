using System.Text.Json;

namespace PeerSoftware
{

    public class Info
    {
        public string checksum { get; set; }
        public string fileName { get; set; }
        public string torrentName { get; set; }
        public long length { get; set; }
        public string description { get; set; }
    }

    public class TorrentFile
    {
        public string announce { get; set; }
        public Info info { get; set; }
        
    }


    static class TorrentReader
    {
        public static TorrentFile ReadFromJSON(string filename)
        {
            string jsonText = File.ReadAllText(filename);

            TorrentFile ?torrent = JsonSerializer.Deserialize<TorrentFile>(jsonText);

            return torrent;
        }
       

        public static void WriteJSON(string finaleFolder, TorrentFile torrent)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentDirectory, finaleFolder, torrent.info.torrentName + ".json");
            string json = JsonSerializer.Serialize(torrent);
            File.WriteAllText(folderPath, json);
        }
    }
}



