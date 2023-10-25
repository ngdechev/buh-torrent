

namespace TorrentTracker.Controllers
{
    public interface ITorrentManagementController
    {
        public void CreateTorrent(string ip, string torrentFile);

        public void DeleteTorrent(string ip, string checksum);


        public List<TorrentFile> GetAllTorrents();

        public void RemoveTorrentFromDictionary(string checksum);

        public TorrentFile SearchTorrent(string torrentName);


        public void ReadTorrentFileFromFoulder();
    }
}
