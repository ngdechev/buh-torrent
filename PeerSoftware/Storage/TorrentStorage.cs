﻿
namespace PeerSoftware.Storage
{
    public class TorrentStorage : ITorrentStorage
    {
        private List<TorrentFile> _downloadingTorrents = new List<TorrentFile>();
        private List<TorrentFile> _allTorrentFiles = new List<TorrentFile>();
        private List<TorrentFile> _myTorrents = new List<TorrentFile>();
        private List<TorrentFile> _resultTorrentFiles = new List<TorrentFile>();
        private List<string>_peerWithMyFaile=new List<string>();
        private List<TorrentFile> _downloadTorrentFiles = new List<TorrentFile>();


        public List<string> GetPeerWithMyFaile()
        {
            return _peerWithMyFaile;
        }
        public List<TorrentFile> GetAllTorrentFiles()
        {
            return _allTorrentFiles;
        }

        public List<TorrentFile> GetMyTorrentFiles()
        {
            return _myTorrents;
        }

        public List<TorrentFile> GetResultTorrentFiles()
        {
            return _resultTorrentFiles;
        }
        public List<TorrentFile> GetDownlodTorrentFiles()
        {
            return _downloadTorrentFiles;
        }
    }
}