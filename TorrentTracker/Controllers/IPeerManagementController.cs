

namespace TorrentTracker.Controllers
{
    public interface IPeerManagementController
    {
        public void CreatePeer(string ip,int port);

        public void DestroyPeer(string ip);

        public List<Peer> ListPeersWithTorrentFile(string checksum);
    }
}
