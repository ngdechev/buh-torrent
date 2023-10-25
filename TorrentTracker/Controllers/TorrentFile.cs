namespace TorrentTracker.Controllers
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

}