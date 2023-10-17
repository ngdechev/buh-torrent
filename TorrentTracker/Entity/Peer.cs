public class Peer
{
    public int peerID { get; set; }
    public string IPAddress { get; set; }
    public int Port { get; set; }
    
    public Peer(int peerId, string ipAddress, int port)
    {
        peerID = peerId;
        IPAddress = ipAddress;
        Port = port;
    }
    public Peer()
    {
        peerID = 1;
        IPAddress = "1";
        Port = 12345;
    }
}