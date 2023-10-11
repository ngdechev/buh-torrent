

namespace TorrentTracker.Controllers
{
    public interface ITorrentManagementController
    {
        public void CreateTorrent(string ip, string torrentFile);

        public void DeleteTorrent(string checksum);

        public List<TorrentFile> ListTorrents();


        public TorrentFile SearchTorrent(string torrentName);

        public void ReadTorrentFileFromFoulder();
    }
}
