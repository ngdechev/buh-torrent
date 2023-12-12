using PeerSoftware.Storage;
using PeerSoftware.Utils;
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
    public class UploadPeerServer
    {
        TcpListener _listener;
        bool _isRunning;
        List<UploadPeerHandler> _handlers;
        ITorrentStorage _storage;
        public UploadPeerServer(ITorrentStorage storage)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            _handlers = new List<UploadPeerHandler>();
            _listener = new(IPAddress.Any, 12346);
            _isRunning = true;
            _storage = storage;
        }

        public void Start()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            _listener.Start();

            while (_isRunning)
            {
                if (_listener.Pending())
                {
                    if (_handlers.Count < 2)
                    {
                        TcpClient clientSocket = _listener.AcceptTcpClient();

                        UploadPeerHandler uploadHandler = new UploadPeerHandler(_storage, clientSocket, this);
                        _handlers.Add(uploadHandler);
                        Thread peerThread = new Thread(uploadHandler.Handle);

                        peerThread.Start();
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void Disconect(UploadPeerHandler upload)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            _handlers.Remove(upload);
        }

        public void Stop()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (_listener != null)
            {
                _listener?.Stop();
            }
            _isRunning = false;
        }
    }
}

