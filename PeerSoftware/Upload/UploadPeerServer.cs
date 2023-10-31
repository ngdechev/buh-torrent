using PeerSoftware.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PeerSoftware.Upload
{
    internal class UploadPeerServer
    {
        TcpListener _listener;
        bool _isRunning;
        List<UploadPeerHandler> _handlers;
        ITorrentStorage _storage;
        public UploadPeerServer(ITorrentStorage storage)
        {
            _handlers = new List<UploadPeerHandler>();
            _listener = new(IPAddress.Any, 12346);
            _isRunning = true;
            _storage = storage;
        }

        public void Start()
        {
            _listener.Start();

            while (_isRunning)
            {
                if (_listener.Pending())
                {
                    if (_handlers.Count < 2)
                    {
                        TcpClient clientSocket = _listener.AcceptTcpClient();

                        UploadPeerHandler uploadHandler = new UploadPeerHandler(_storage, clientSocket);

                        Thread peerThread = new Thread(uploadHandler.Handle);

                        peerThread.Start();
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void Stop()
        {
            if (_listener != null)
            {
                _listener?.Stop();
            }
            _isRunning = false;
        }
    }
}

