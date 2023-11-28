﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeerSoftware.Storage
{
    public interface ITorrentStorage
    {
        public List<TorrentFile> GetDownloadTorrentFiles();
        public List<TorrentFile> GetAllTorrentFiles();
        public List<TorrentFile> GetResultTorrentFiles();
        public List<TorrentFile> GetMyTorrentFiles();
        public List<string> GetPeerWithMyFaile();

        public Dictionary<int,bool> GetDownloadTorrentStatus();
    }
}
