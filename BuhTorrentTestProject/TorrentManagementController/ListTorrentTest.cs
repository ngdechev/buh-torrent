

namespace TorrentTracker.Controllers.Tests
{
    [TestFixture]
    public class TorrentManagementControllerTests
    {
        private DictionaryController _dictionaryController;
        private TorrentManagementController _torrentController;

        [SetUp]
        public void Setup()
        {
            _dictionaryController = new DictionaryController();
            _torrentController = new TorrentManagementController(_dictionaryController);
        }

        [Test]
        public void ListTorrents_Should_Return_All_Torrents_From_DictionaryController()
        {
            var peer = new Peer();
            var torrent1 = new Torrent();
            var torrent2 = new Torrent();
            var torrent3 = new Torrent();

            var sampleDictionary = new Dictionary<Peer, List<Torrent>>
            {
             { peer, new List<Torrent> { torrent1, torrent2 } },
             { new Peer(), new List<Torrent> { torrent3 } }
            };

            _dictionaryController.SetDictionary(sampleDictionary);

            var result = _torrentController.ListTorrents();
 
            CollectionAssert.AreEquivalent(new List<Torrent> { torrent1, torrent2, torrent3 }, result);
        }
    }
}
