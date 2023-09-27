public class Torrent
{
	public string trackerIp {get; set;}
	public string checkSum { get; set; }
	public string fileName { get; set; }
	public string torrentName { get; set; }
	public string description { get; set; }
	public float sharedFileLength { get; set; }

    public Torrent(string trackerIp, string checkSum, string fileName, string torrentName, string description, float sharedFileLength)
    {
        trackerIp = trackerIp;
		checkSum = checkSum;
		fileName = fileName;
		torrentName = torrentName;
		description = description;
		sharedFileLength = sharedFileLength;
    }
    public Torrent()
    {
        trackerIp = "udp://tracker.openbittorrent.com";
        checkSum = "bba9950a917398a665cf86c3d820e3d6";
        fileName = "Pictures";
        torrentName = "Pictures";
        description = "filesld4:attr1:h6:lengthi380e4:pathl11:desktop.inieee4:name8:Pictures12:piece lengthi16384e6";
        sharedFileLength = 16384;
    }
}
