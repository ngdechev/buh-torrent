using PeerSoftware;

namespace BuhTorrentTestProject.PeerSoftwareTests
{
    [TestFixture]
    public class Form1Tests
    {
        private Form1 form; // Your Form1 class instance

        [SetUp]
        public void SetUp()
        {
            // Initialize your Form1 instance or any necessary setup
            form = new Form1();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up or dispose of resources if needed
        }

        /*[Test]
        public void TestSplitIpAndPort_ValidInput()
        {
            // Arrange
            //form.SetTrackerIp("127.0.0.1");

            // Act
            var result = form.SplitIpAndPort();

            // Assert
            Assert.AreEqual(("192.168.1.1", 8080), result);
        }

        [Test]
        public void TestSplitIpAndPort_InvalidInput()
        {
            // Arrange
            //form.SetTrackerIp("127.0.0.1."); // Set an invalid input

            // Act
            var result = form.SplitIpAndPort();

            // Assert
            Assert.AreEqual((string.Empty, 0), result);
        }*/

        // Add more test methods for other functionality in your Form1 class
    }
}
