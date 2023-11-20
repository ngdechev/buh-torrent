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
            if(torrentStorage.GetDownloadTorrentFiles() == null )
            {
                return ;
            }
            foreach (TorrentFile item in torrentStorage.GetDownloadTorrentFiles())
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
                   // TorrentReader.WriteJSON("MyTorrent", newTorrent);

                    /*string trackerIpField;
                    int trackerPortField;

                    (trackerIpField, trackerPortField) = new NetworkUtils().SplitIpAndPort(mainForm);

                    *//*new Connections().AnnounceNewPeer(trackerIpField, trackerPortField);*//*
                    TcpClient client = new TcpClient(trackerIpField,trackerPortField);
                    string? myip = new NetworkUtils().GetLocalIPAddress() + ":" + new NetworkUtils().GetLocalPort().ToString();

                    string ipPlusJson = myip + ";" + JsonSerializer.Serialize(newTorrent);
                    new Connections().SendPTTMessage(client, 0x02,ipPlusJson);*/
                }
            }

        }


        public List<TorrentFile> LoadMyTorrents(ITorrentStorage storage)
        {
            string folderPath = Directory.GetCurrentDirectory();
            folderPath = folderPath + "\\MyTorrent";
            List<TorrentFile> temp = new List<TorrentFile>();

            if (Directory.Exists(folderPath))
            {
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");
                
                storage.GetMyTorrentFiles().Clear();

                foreach (string jsonFile in jsonFiles)
                {
                    TorrentFile torrentFile = TorrentReader.ReadFromJSON(jsonFile);
                    temp.Add(torrentFile);
                    storage.GetMyTorrentFiles().Add(torrentFile);
                }
            }

            return temp;
        }

        public Dictionary<string, string> themeKeyMapping = new Dictionary<string, string>
        {
            { "Lime with Purple Accent", "limewithpurpleaccentscheme" },
            { "Blue-Grey with Light Blue Accent", "bluegreywithlightblueaccentscheme" },
            { "Indigo with Pink Accent", "indigowithpinkaccentscheme" },
            { "Teal with Amber Accent", "tealwithamberaccentscheme" },
            { "Deep Purple with Orange Accent", "deeppurplewithorangeaccentscheme" },
            { "Blue with Yellow Accent", "bluewithyellowaccentscheme" },
            { "Green with Lime Accent", "greenwithlimeaccentscheme" },
        };

        public MaterialSkin.ColorScheme LoadTheme(string themeName)
        {
            MaterialSkin.ColorScheme colorScheme = new MaterialSkin.ColorScheme();

            var limePurpleScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Green600,
                MaterialSkin.Primary.Green700,
                MaterialSkin.Primary.Blue900,
                MaterialSkin.Accent.Purple700,
                MaterialSkin.TextShade.WHITE);

            var blueGreyScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.BlueGrey900,
                MaterialSkin.Primary.BlueGrey900,
                MaterialSkin.Primary.BlueGrey900,
                MaterialSkin.Accent.LightBlue700,
                MaterialSkin.TextShade.WHITE);

            var indigoPinkScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Indigo500,
                MaterialSkin.Primary.Indigo500,
                MaterialSkin.Primary.Indigo500,
                MaterialSkin.Accent.Pink200,
                MaterialSkin.TextShade.WHITE);

            var tealAmberScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Teal500,
                MaterialSkin.Primary.Teal500,
                MaterialSkin.Primary.Teal500,
                MaterialSkin.Accent.Amber200,
                MaterialSkin.TextShade.WHITE);

            var deepPurpleOrangeScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.DeepPurple500,
                MaterialSkin.Primary.DeepPurple500,
                MaterialSkin.Primary.DeepPurple500,
                MaterialSkin.Accent.Orange200,
                MaterialSkin.TextShade.WHITE);

            var blueYellowScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Blue500,
                MaterialSkin.Primary.Blue500,
                MaterialSkin.Primary.Blue500,
                MaterialSkin.Accent.Yellow200,
                MaterialSkin.TextShade.WHITE);

            var greenLimeScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Green500,
                MaterialSkin.Primary.Green500,
                MaterialSkin.Primary.Green500,
                MaterialSkin.Accent.Lime200,
                MaterialSkin.TextShade.WHITE);

            switch (themeName)
            {
                case "limewithpurpleaccentscheme":
                    colorScheme = limePurpleScheme;
                    break;
                case "bluegreywithlightblueaccentscheme":
                    colorScheme = blueGreyScheme;
                    break;
                case "indigowithpinkaccentscheme":
                    colorScheme = indigoPinkScheme;
                    break;
                case "tealwithamberaccentscheme":
                    colorScheme = tealAmberScheme;
                    break;
                case "deeppurplewithorangeaccentscheme":
                    colorScheme = deepPurpleOrangeScheme;
                    break;
                case "bluewithyellowaccentscheme":
                    colorScheme = blueYellowScheme;
                    break;
                case "greenwithlimeaccentscheme":
                    colorScheme = greenLimeScheme;
                    break;
            }

            return colorScheme;
        }

    }
}
