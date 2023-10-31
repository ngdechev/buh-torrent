using NUnit.Framework;
using PeerSoftware.Services;
using System;
using System.Collections.Generic;

[TestFixture]
public class SharedFileServicesTests
{
    [Test]
    public void CalculateParticions_NoPeers_ThrowsException()
    {
        SharedFileServices sharedFileServices = new SharedFileServices();
        List<string> peersIpPlusPort = new List<string>();
        int sizeOfSharedFile = 1024;

        Assert.Throws<Exception>(() => sharedFileServices.CalculateParticions(peersIpPlusPort, sizeOfSharedFile));
    }

    [Test]
    public void CalculateParticions_LessThanFivePeers_ShouldDistributeBlocksToAll()
    {
        SharedFileServices sharedFileServices = new SharedFileServices();
        List<string> peersIpPlusPort = new List<string> { "Peer1", "Peer2", "Peer3" };
        int sizeOfSharedFile = 2080768;

        Dictionary<string, string> result = sharedFileServices.CalculateParticions(peersIpPlusPort, sizeOfSharedFile);

        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("1-682", result["Peer1"]);
        Assert.AreEqual("683-1364", result["Peer2"]);
        Assert.AreEqual("1365-2048", result["Peer3"]);
    }

    [Test]
    public void CalculateParticions_MoreThanFivePeers_ShouldDistributeBlocksToFivePeers()
    {
        SharedFileServices sharedFileServices = new SharedFileServices();
        List<string> peersIpPlusPort = new List<string> { "Peer1", "Peer2", "Peer3", "Peer4", "Peer5", "Peer6" };
        int sizeOfSharedFile = 19300;

        Dictionary<string, string> result = sharedFileServices.CalculateParticions(peersIpPlusPort, sizeOfSharedFile);

        Assert.AreEqual(5, result.Count);
        Assert.AreEqual("1-3", result["Peer1"]);
        Assert.AreEqual("4-6", result["Peer2"]);
        Assert.AreEqual("7-9", result["Peer3"]);
        Assert.AreEqual("10-12", result["Peer4"]);
        Assert.AreEqual("13-19", result["Peer5"]);
    }

    [Test]
    public void CalculateParticions_EmptyPeersList_ThrowsException()
    {
        SharedFileServices sharedFileServices = new SharedFileServices();
        List<string> peersIpPlusPort = new List<string>();
        int sizeOfSharedFile = 0;

        Assert.Throws<Exception>(() => sharedFileServices.CalculateParticions(peersIpPlusPort, sizeOfSharedFile));
    }
}
