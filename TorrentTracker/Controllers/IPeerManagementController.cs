

namespace TorrentTracker.Controllers
{
    public interface IPeerManagementController
    {
        public string CreatePeer(string ip);

        public string DestroyPeer(string ip);

        public List<Peer> ListPeers();
    }
}
