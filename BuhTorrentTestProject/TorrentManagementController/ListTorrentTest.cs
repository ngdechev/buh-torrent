using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorrentTracker.Controllers;

namespace BuhTorrentTestProject.TorrentManagementControllerTest
{
    [TestFixture]
    public class ListTorrentTest
    {
        [Test]
        public void TestTorrentFile()
        {
            var torrentController = new TorrentManagementController();
            var peer = new Peer();
            var torrent1 = new Torrent();
            var torrent2 = new Torrent();
            var torrent3 = new Torrent();
            var dictionary = new Dictionary<Peer, List<Torrent>>
            {
                { peer, new List<Torrent> { torrent1, torrent2 } },
                { new Peer(), new List<Torrent> { torrent3 } }
            };

            torrentController.SetDictionary(dictionary);
            var result = torrentController.ListTorrents(dictionary);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<Torrent> { torrent1, torrent2, torrent3 }, result);
        }
    }
}
