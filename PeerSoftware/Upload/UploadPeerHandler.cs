using PeerSoftware.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PTP_Parser;

namespace PeerSoftware.Upload
{
    internal class UploadPeerHandler
    {
        ITorrentStorage _storage;
        TcpClient _tcpClient;
        bool _isRunning;
        List<PTPBlock> _blocks;
        UploadPeerServer _server;

        public UploadPeerHandler(ITorrentStorage storage, TcpClient client, UploadPeerServer server) 
        {
            _isRunning = true;
            _storage = storage;
            _tcpClient = client;
            _server = server;
        }


        public void Handle()
        {
           /* while (_isRunning)
            {*/
                NetworkStream stream = _tcpClient.GetStream();
                PTPBlock block = PTPParser.ParseToBlock(stream);
                if (block.IsType("StartPackage"))
                {
                    string[] data = block.GetData().Split('/',3);
                    Disasemble(data[1], data[2]);
                    foreach(PTPBlock pTPBlock in _blocks)
                    {
                        stream.Write(PTPParser.ParseToPackage(pTPBlock));
                    }
                _server.Disconect(this);
                    //stream.Write(PTPParser.UnavailablePackage());
                }
            /*}*/
        }

        public void Disasemble(string cheksum, string blocks)
        {
            TorrentFile torrentFile = _storage.GetAllTorrentFiles().Find(r => r.info.checksum == cheksum);
            if (torrentFile != null)
            {
                _blocks = new List<PTPBlock>();

                string filePath = torrentFile.info.fileName; // Replace with the path to your file
                string[] idBlocks = blocks.Split('-', 2);

                int.TryParse(idBlocks[0], out int firstBlock);
                int.TryParse(idBlocks[1], out int lastBlock);

                int startPosition = (firstBlock - 1) * 1016; // Start position in the file

                int lengthToRead = 0;
                bool isFull = false;

                int sizeOfFullBlocks = (lastBlock - 1) * 1016;
                int sizeOfLastBlock = (int)(torrentFile.info.length - sizeOfFullBlocks);

                if (((lastBlock - firstBlock) * 1016 + startPosition) >= torrentFile.info.length)
                {
                    lengthToRead = (lastBlock - firstBlock + 1) * 1016; // Number of bytes to read
                    isFull = true;
                }
                else
                {
                    lengthToRead = sizeOfFullBlocks - startPosition + sizeOfLastBlock;
                    isFull = false;
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fs.Seek(startPosition, SeekOrigin.Begin);

                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] buffer = br.ReadBytes(lengthToRead);
                        _blocks.Clear();

                        if (isFull)
                        {
                            for (int i = 1; i <= (lastBlock - firstBlock); i++)
                            {
                                byte[] bytes = new byte[1016];
                                Array.Copy(buffer, (i - 1) * 1016, bytes, 0, 1016);
                                _blocks.Add(new PTPBlock(i, bytes.Length, bytes));
                            }
                        }
                        else
                        {
                            for (int i = 1; i <= (lastBlock - firstBlock - 1); i++)
                            {
                                byte[] bytes = new byte[1016];
                                Array.Copy(buffer, (i - 1) * 1016, bytes, 0, 1016);
                                _blocks.Add(new PTPBlock(i, bytes.Length, bytes));
                            }

                            //int size = buffer.Length - ((lastBlock - firstBlock) * 1016);
                            byte[] lastBytes = new byte[sizeOfLastBlock];
                            Array.Copy(buffer, (lastBlock - firstBlock) * 1016, lastBytes, 0, sizeOfLastBlock);
                            _blocks.Add(new PTPBlock(lastBlock, lastBytes.Length, lastBytes));
                        }
                    }
                }

            }
        }
    }
}
