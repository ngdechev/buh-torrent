

namespace TorrentTracker.Controllers
{
    public class PeerManagementController : IPeerManagementController
    {
        private DictionaryController _dictionaryController;
        private List<Peer> _AllPeers = new List<Peer>();

        public PeerManagementController(DictionaryController dictionaryController)
        {
            _dictionaryController = dictionaryController;
        }

        public string CreatePeer(string ip)
        {
            throw new NotImplementedException();
        }

        public string DestroyPeer(string ip)
        {
            throw new NotImplementedException();
        }

        public List<Peer> ListPeers()
        {
            throw new NotImplementedException();
        }
    }
}
