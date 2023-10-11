

namespace TorrentTracker.Controllers
{
    public interface IPeerManagementController
    {
        public void CreatePeer(string ip);

        public void DestroyPeer(string ip);

        public List<Peer> ListPeersWithTorrentFile(string checksum);
    }
}
