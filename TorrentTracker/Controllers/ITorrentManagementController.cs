

using PeerSoftware;

namespace TorrentTracker.Controllers
{
    public interface ITorrentManagementController
    {
        public string CreateTorrent(string ip, string torrentFile);

        public string DeleteTorrent(string ip, string checksum);

        public List<TorrentFile> ListTorrents();

        public TorrentFile SearchTorrent(string torrentName);
        public void ReadTorrentFileFromFoulder();
    }
}
