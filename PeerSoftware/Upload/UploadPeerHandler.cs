using PeerSoftware.Storage;
using PTP_Parser;
using System.Net.Sockets;

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
            NetworkStream stream = _tcpClient.GetStream();
            PTPBlock block = PTPParser.ParseToBlock(stream);

            if (block.IsType("StartPackage"))
            {
                string[] data = block.GetData().Split('/', 3);
                Disasemble(data[1], data[2]);

                foreach (PTPBlock pTPBlock in _blocks)
                {
                    Thread.Sleep(10);
                    stream.Write(PTPParser.ParseToPackage(pTPBlock));
                }

                _server.Disconect(this);
            }
        }
            
        public void Disasemble(string cheksum, string blocks)
        {
            bool lastBlockOfAll = false, isFull = false;
            int lengthToRead = 0, sizeOfLastBlock = 0, sizeOfFullBlocks = 0;

            _blocks = new List<PTPBlock>();

            TorrentFile torrentFile = _storage.GetAllTorrentFiles().Find(r => r.info.checksum == cheksum);

            if (torrentFile == null)
            {
                return;
            }

            string filePath = torrentFile.info.fileName; 

            string[] idBlocks = blocks.Split('-', 2);
            int.TryParse(idBlocks[0], out int firstBlock);
            int.TryParse(idBlocks[1], out int lastBlock);

            int startPosition = (firstBlock - 1) * 1016;
            int allBlocksFile = (int)Math.Ceiling((double)torrentFile.info.length / 1016);

            sizeOfFullBlocks = lastBlock * 1016;
            sizeOfLastBlock = (int)(torrentFile.info.length - sizeOfFullBlocks);

            if (firstBlock == 1 && sizeOfLastBlock < 1016)
            {
                startPosition = (firstBlock - 1) * 1016; 
                lengthToRead = 0;
                isFull = false;

                sizeOfFullBlocks = (lastBlock - 1) * 1016;

                if (((lastBlock - firstBlock) * 1016 + startPosition) >= torrentFile.info.length)
                {
                    lengthToRead = (lastBlock - firstBlock + 1) * 1016;
                    isFull = true;
                }
                else
                {
                    lengthToRead = sizeOfFullBlocks - startPosition + sizeOfLastBlock;
                    isFull = false;
                }
            }
            else if (allBlocksFile == lastBlock) 
            {
                lastBlockOfAll = false;
                sizeOfFullBlocks = (lastBlock - 1) * (int)(torrentFile.info.length - (lastBlock - firstBlock) * 1016);
                sizeOfLastBlock = (int)(torrentFile.info.length - ((lastBlock - 1) * 1016));

                if (((lastBlock - firstBlock) * 1016 + startPosition) >= sizeOfFullBlocks)
                {
                    lengthToRead = (lastBlock - firstBlock + 1) * 1016; 
                    isFull = true;
                }
                else
                {
                    lengthToRead = (sizeOfFullBlocks - startPosition) - sizeOfLastBlock;
                    isFull = false;
                }
            }
            else
            {
                sizeOfFullBlocks = (lastBlock - 1) * 1016 - startPosition;
                lengthToRead = (lastBlock - firstBlock + 1) * 1016;
                lastBlockOfAll = true;
                isFull = true;
            }

            UploadFilePackets(filePath, startPosition, lengthToRead, firstBlock, lastBlock, sizeOfLastBlock, lastBlockOfAll, isFull);
        }

        public void UploadFilePackets(string filePath, int startPosition, int lengthToRead, int firstBlock, int lastBlock, int sizeOfLastBlock, bool lastBlockOfAll, bool isFull)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(startPosition, SeekOrigin.Begin);

                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] buffer = br.ReadBytes(lengthToRead);
                    _blocks.Clear();

                    if (lastBlockOfAll && isFull)
                    {
                        for (int i = 0; i <= (lastBlock - firstBlock); i++)
                        {
                            byte[] bytes = new byte[1016];
                            Array.Copy(buffer, i * 1016, bytes, 0, 1016);
                            _blocks.Add(new PTPBlock(i, bytes.Length, bytes));
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= (lastBlock - firstBlock - 1); i++)
                        {
                            byte[] bytes = new byte[1016];
                            Array.Copy(buffer, i * 1016, bytes, 0, 1016);
                            _blocks.Add(new PTPBlock(i, bytes.Length, bytes));
                        }

                        byte[] lastBytes = new byte[sizeOfLastBlock];
                        Array.Copy(buffer, (lastBlock - firstBlock) * 1016, lastBytes, 0, sizeOfLastBlock);
                        _blocks.Add(new PTPBlock(lastBlock, lastBytes.Length, lastBytes));
                    }
                }
            }
        }

        /*public void Disasemble(string cheksum, string blocks)
        {
            TorrentFile torrentFile = _storage.GetAllTorrentFiles().Find(r => r.info.checksum == cheksum);
            if (torrentFile != null)
            {
                _blocks = new List<PTPBlock>();

                string filePath = torrentFile.info.fileName; // Replace with the path to your file

                string[] idBlocks = blocks.Split('-', 2);
                int.TryParse(idBlocks[0], out int firstBlock);
                int.TryParse(idBlocks[1], out int lastBlock);

                long startPos = (firstBlock - 1) * 1016;
                long lastPos = (lastBlock - 1) * 1016;

                if (torrentFile.info.length > lastPos)
                {
                    int startIndex = firstBlock;
                    
                    while (startIndex <= lastBlock)
                    {

                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {

                            fs.Seek(startPos, SeekOrigin.Begin);
                            byte[] bytes = new byte[1016];
                            fs.Read(bytes, 0, 1016);
                            _blocks.Add(new PTPBlock(startIndex, bytes.Length, bytes));

                            startIndex++;
                            startPos = startPos + 1016;

                        }
                    }
                }
                else
                {
                    int startIndex = firstBlock;

                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        while (startIndex <= lastBlock - 1)
                        {

                            fs.Seek(startPos, SeekOrigin.Begin);
                            byte[] bytes = new byte[1016];
                            fs.Read(bytes, 0, 1016);
                            _blocks.Add(new PTPBlock(startIndex, bytes.Length, bytes));

                            startIndex++;
                            startPos = startPos + 1016;

                        }

                        int lastBlockSize = (int)(torrentFile.info.length - (lastPos - 1016));

                        byte[] lastBytes = new byte[lastBlockSize];
                        fs.Read(lastBytes, 0, lastBlockSize);
                        _blocks.Add(new PTPBlock(startIndex, lastBytes.Length, lastBytes));
                    }

                }
            }
        }*/

    }
}

