using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorrentTracker.Controllers;

namespace BuhTorrentTestProject.TorrentManagementControllerTest
{
    [TestFixture]
    public class ReadTorrentFileFromFoulderTest
    {
        [Test]
        public void ReadTorrentFileFromFolder_ValidJsonFile_ParsesSuccessfully()
        {
             string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "TorrentFile");
             var reader = new TorrentManagementController(folderPath); 
             reader.ReadTorrentFileFromFoulder();
             Assert.That(reader.GetAllTorrents, Is.Not.Null);
        }
    }
}
