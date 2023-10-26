

using System.Text.Json;

namespace TorrentTracker.Controllers
{
    public class PeerManagementController : IPeerManagementController
    {
        private DictionaryController _dictionaryController;
        private List<Peer> _peerWithTorrentFile;
        public PeerManagementController(DictionaryController dictionaryController)
        {
            _dictionaryController = dictionaryController;
        }

        public void CreatePeer(string ip, int port)
        {
            bool flag = true;
            if (_dictionaryController.GetDictionary().Count() == 0)
            {
                Peer peer = new Peer(_dictionaryController.GetDictionary().Count() + 1, ip, port);
                _dictionaryController.GetDictionary().Add(peer, new List<string>());
            }
            else
            {
                foreach (var pear in _dictionaryController.GetDictionary())
                {
                    if (pear.Key.IPAddress == ip)
                    {
                        flag = false;
                        pear.Key.Port= port;
                        break;
                    }
                   
                }
               
                if (flag == true)
                { 
                         Peer peer = new Peer(_dictionaryController.GetDictionary().Count() + 1, ip, port);
                        _dictionaryController.GetDictionary().Add(peer, new List<string>());
                }
                flag = true;
            }
        }

        public void DestroyPeer(string ip)
        {
            Peer PeerForRemove = new Peer();
            foreach (var pair in _dictionaryController.GetDictionary())
            {
                if (pair.Key.IPAddress == ip)
                {
                    PeerForRemove = pair.Key;
                    _dictionaryController.GetDictionary().Remove(PeerForRemove);

                }
                else
                {
                    throw new Exception("This peer does not exist");
                }
            }
        }

        public List<Peer> ListPeersWithTorrentFile(string checksum)
        {
            
            //foreach (var pair in _dictionaryController.GetDictionary())
            //{
            //    foreach (TorrentFile torrent in pair.Value)
            //    {
            //        if (checksum == torrent.info.checksum)
            //        {
            //            _peerWithTorrentFile.Add(pair.Key);
            //        }
            //    }
            //}
            return _peerWithTorrentFile;
        }
    }
}
