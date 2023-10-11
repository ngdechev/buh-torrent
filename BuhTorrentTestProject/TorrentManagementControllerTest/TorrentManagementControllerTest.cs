using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorrentTracker.Controllers;

namespace BuhTorrentTestProject.TorrentManagementControllerTest
{
    [TestFixture]
    public class TorrentManagementControllerTest
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

        [Test]
        public void ReadTorrentFileFromFolder_ValidJsonFile_ParsesSuccessfully()
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "TorrentFile");
            var reader = new TorrentManagementController(folderPath);
            reader.ReadTorrentFileFromFoulder();
            Assert.That(reader.GetAllTorrents, Is.Not.Null);
        }

        [Test]
        public void CreateTorrent_AddsTorrentToList()
        {
            string ip = "127.0.0.1";
            string torrentFile = "{\r\n  \"trackerIp\": \"udp://tracker.openbittorrent.com\",\r\n  \"checkSum\": \"bba9950a917398a665cf86c3d820e3d6\",\r\n  \"fileName\": \"Pictures\",\r\n  \"torrentName\": \"Pictures\",\r\n  \"description\": \"filesld4:attr1:h6:lengthi380e4:pathl11:desktop.inieee4:name8:Pictures12:piece lengthi16384e6\",\r\n  \"sharedFileLength\": 16384\r\n}";
            int initialTorrentCount = _torrentController.GetAllTorrents().Count;

            _torrentController.CreateTorrent(ip, torrentFile);

            int updatedTorrentCount = _torrentController.GetAllTorrents().Count;
            Assert.AreEqual(initialTorrentCount + 1, updatedTorrentCount);
        }

        [Test]
        public void DeleteTorrent_RemovesTorrentFromList()
        {
           
            string checksum = "bba9950a917398a665cf86c3d820e3d6";
            
            _torrentController.DeleteTorrent(checksum);

            Assert.IsFalse(_torrentController.GetAllTorrents().Any(t => t.checkSum == checksum));
        }
    }
}
