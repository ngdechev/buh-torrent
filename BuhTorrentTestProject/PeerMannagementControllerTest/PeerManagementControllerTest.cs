using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorrentTracker.Controllers;

namespace BuhTorrentTestProject.PeerMannagementControllerTest
{
    public class PeerManagementControllerTest
    {
        private PeerManagementController _peerManagementController;
        private DictionaryController _dictionaryController;
        private TorrentManagementController _torrentController;

        [SetUp]
        public void Setup()
        {
            _dictionaryController = new DictionaryController();
           _peerManagementController = new PeerManagementController(_dictionaryController);
            _torrentController = new TorrentManagementController(_dictionaryController);
        }

        [Test]
        public void CreatePeer_AddsPeerToDictionary()
        {
            string ip = "127.0.0.1";
            int initialPeerCount = _dictionaryController.GetDictionary().Count;

            _peerManagementController.CreatePeer(ip);

            int updatedPeerCount = _dictionaryController.GetDictionary().Count;
            Assert.AreEqual(initialPeerCount + 1, updatedPeerCount);
        }

        [Test]
        public void DestroyPeer_RemovesPeerFromDictionary()
        {
          
            string ip = "127.0.0.1";
          
            _peerManagementController.DestroyPeer(ip);


            Assert.IsFalse(_dictionaryController.GetDictionary().Any(pair => pair.Key.ipAddress == ip));
        }
       

    }
}
