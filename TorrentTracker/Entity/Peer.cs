
  public class Peer
  {
    public int peerID { get; set; }
    public string IPAddress { get; set; }
    public int Port { get; set; }
    public DateTime Date { get; set; }

    public Peer(int peerId, string ipAddress, int port, DateTime date)
    {
        peerID = peerId;
        IPAddress = ipAddress;
        Port = port;
        Date = date;
    }
    public Peer()
    {
        peerID = 1;
        IPAddress = "1";
        Port = 12345;
    }
    public string ToString()
    {
         return peerID+" "+IPAddress+" "+Port+" "+Date;
    }
    public string StringIPAndPort()
    {
         return IPAddress + ":" + Port;
    }
  }
