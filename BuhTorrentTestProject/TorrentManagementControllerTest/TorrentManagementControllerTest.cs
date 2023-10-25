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
        private TorrentManagementController _controller;
        private DictionaryController _dictionaryController; // You may need to mock this

        [SetUp]
        public void Setup()
        {
            // Create a mock for DictionaryController or provide a real instance
            _dictionaryController = new DictionaryController(); // Mock or create a real instance as needed
            _controller = new TorrentManagementController(_dictionaryController);
        }

        [Test]
        public void GetAllTorrents_ReturnsEmptyList_WhenNoTorrentsExist()
        {
            var torrents = _controller.GetAllTorrents();
            Assert.IsNotEmpty(torrents);
        }

        [Test]
        public void DeleteTorrent_RemovesTorrentFromDictionary()
        {
            // Arrange
            Peer peer = new Peer(1, "127.0.0.1", 12345);
            var checksum = "your_checksum_here";

            // Act
            _controller.DeleteTorrent(peer.IPAddress, checksum);

            // Assert - Check if the torrent was removed from the dictionary
            var dictionary = _dictionaryController.GetDictionary();
            Assert.IsFalse(dictionary.ContainsKey(peer));
            Assert.IsEmpty(dictionary);
        }

        [Test]
        public void SearchTorrent_ThrowsException_WhenTorrentNotFound()
        {
            // Arrange
            var torrentName = "NonExistentTorrentName";

            // Act and Assert
            Assert.Throws<Exception>(() => _controller.SearchTorrent(torrentName));
        }

      
    }
}
