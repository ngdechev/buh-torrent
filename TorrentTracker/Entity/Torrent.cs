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
}
