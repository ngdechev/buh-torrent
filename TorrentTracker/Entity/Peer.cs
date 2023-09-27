public class Peer
{
    public string peerId { get; set; }
    public string ipAddress { get; set; }
    public int port { get; set; }
    
    public Peer(string peerId, string ipAddress, int port)
    {
        peerId = peerId;
        ipAddress = ipAddress;
        port = port;
    }
    public Peer()
    {
        peerId = "1";
        ipAddress = "1";
        port = 12345;
    }
}