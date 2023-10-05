

namespace TorrentTracker.Controllers
{
    public interface ITorrentManagementController
    {
        public string CreateTorrent(string ip, string torrentFile);

        public string DeleteTorrent(string ip, string checksum);

        public List<Torrent> ListTorrents();

        public string SearchTorrent(string torrentName);
        public void ReadTorrentFileFromFoulder();
    }
}
