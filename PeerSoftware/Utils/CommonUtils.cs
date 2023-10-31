using PeerSoftware.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PeerSoftware.Utils
{
    public class CommonUtils
    {
        public string FormatFileSize(long sizeInBytes)
        {
            double sizeInKB = (double)sizeInBytes / 1024;
            double sizeInMB = sizeInKB / 1024;
            double sizeInGB = sizeInMB / 1024;

            if (sizeInGB >= 1)
            {
                return $"{sizeInGB:0.00} GB";
            }
            else if (sizeInMB >= 1)
            {
                return $"{sizeInMB:0.00} MB";
            }
            else
            {
                return $"{sizeInKB:0.00} KB";
            }
        }

        public void ReceateTorrentFileForDownloadedFile(ITorrentStorage torrentStorage,  string checksum, Form1 mainForm)
        {
            TorrentFile newTorrent =new TorrentFile();
            if(torrentStorage.GetDownlodTorrentFiles() == null )
            {
                return ;
            }
            foreach (TorrentFile item in torrentStorage.GetDownlodTorrentFiles())
            {
                if (item.info.checksum == checksum)
                {
                    newTorrent = item;
                    
                    //MessageBox.Show("in");
                    
                    string fileExtension = Path.GetExtension(item.info.fileName);

                    if (!string.IsNullOrEmpty(fileExtension))
                    {
                        fileExtension = fileExtension.TrimStart('.');
                    }
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string folderPath = Path.Combine(currentDirectory, "Download", newTorrent.info.torrentName + "." + fileExtension);
                    newTorrent.info.fileName = folderPath;
                    TorrentReader.WriteJSON("MyTorrent", newTorrent);

                    string trackerIpField;
                    int trackerPortField;

                    (trackerIpField, trackerPortField) = new NetworkUtils().SplitIpAndPort(mainForm);

                    new Connections().AnnounceNewPeer(trackerIpField, trackerPortField);
                    TcpClient client = new TcpClient(trackerIpField,trackerPortField);
                    string? myip = new NetworkUtils().GetLocalIPAddress() + ":" + new NetworkUtils().GetLocalPort().ToString();

                    string ipPlusJson = myip + ";" + JsonSerializer.Serialize(newTorrent);
                    new Connections().SendPTTMessage(client, 0x02,ipPlusJson);
                }
            }

        }
    }
}
