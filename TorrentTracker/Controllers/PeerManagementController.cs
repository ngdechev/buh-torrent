

using System.Text.Json;

namespace TorrentTracker.Controllers
{
    public class PeerManagementController : IPeerManagementController
    {
        private DictionaryController _dictionaryController;
        private TorrentManagementController _torrentController;
        private List<string> _peerWithTorrentFile = new();
        public PeerManagementController(DictionaryController dictionaryController)
        {
            _dictionaryController = dictionaryController;
            _torrentController = new TorrentManagementController(_dictionaryController);
        }

        public void CreatePeer(string ip, int port)
        {
            bool flag = true;
            if (_dictionaryController.GetDictionary().Count() == 0)
            {
                Peer peer = new Peer(_dictionaryController.GetDictionary().Count() + 1, ip, port, DateTime.UtcNow);
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
                         Peer peer = new Peer(_dictionaryController.GetDictionary().Count() + 1, ip, port, DateTime.UtcNow);
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

        public List<string> ListPeersWithTorrentFile(string checksum)
        {
            string torrernt="";
            foreach (TorrentFile torrentFile in _torrentController.GetAllTorrents())
            {
                if (torrentFile.info.checksum == checksum)
                {
                    torrernt = torrentFile.info.torrentName;
                }
            }

            foreach (var pair in _dictionaryController.GetDictionary())
            {
                foreach (string torrentName in pair.Value)
                {
                    if (torrernt == torrentName)
                    {
                        DateTime currentTime = DateTime.Now;
                        DateTime targetDate = pair.Key.Date;

                        TimeSpan timeDifference = currentTime - targetDate;
                        TimeSpan twentySeconds = TimeSpan.FromSeconds(20);

                        //TimeSpan lastActive = pair.Key.Date - DateTime.Now;
                        //double secendLastActive = lastActive.TotalSeconds;

                        if (timeDifference < twentySeconds)
                        {
                            
                            _peerWithTorrentFile.Add(pair.Key.StringIPAndPort());
                            //break;
                        }
                        
                    }
                }
            }
            return _peerWithTorrentFile;
        }
    }
}
