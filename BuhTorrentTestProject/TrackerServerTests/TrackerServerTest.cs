using System.Net.Sockets;
using TorrentTracker;
using Moq;
using TorrentTracker.Server;

namespace BuhTorrentTestProject
{
    [TestFixture]
    public class TrackerServerTests
    {
        //[Test]
        //public void Start_ListeningOnPort_ServerStarted()
        //{
        //    // Arrange
        //    int serverPort = 12345;
        //    var server = new TrackerServer();

        //    // Mock the TcpListener to avoid real network operations
        //    var tcpListenerMock = new Mock<TcpListener>(It.IsAny<System.Net.IPAddress>(), serverPort);

        //    // Act
        //    server.Start(serverPort);

        //    // Assert
        //    Assert.IsTrue(server._isRunning);
        //}

        //[Test]
        //public void Stop_ServerIsRunning_ServerStopped()
        //{
        //    // Arrange
        //    var server = new TrackerServer();
        //    server.Start(12345);

        //    // Act
        //    server.Stop();

        //    // Assert
        //    Assert.IsFalse(server._isRunning);
        //}

        
    }
}
