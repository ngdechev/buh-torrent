using System.Net.Sockets;
using System.Text;

namespace PTT_Parser
{
    public class PTTBlock
    {
        private byte _command;
        private int _size;
        private string _payload;

        public PTTBlock(byte command, int size, string payload)
        {
            _command = command;
            _size = size;
            _payload = payload;
        }

        public byte GetCommand()
        {
            return _command;
        }

        public int GetSize()
        {
            return _size;
        }

        public string GetPayload()
        {
            return _payload;
        }

        public override string ToString()
        {
            return $"{_command}{_size}{_payload}";
        }
    }

    public class PTT
    {
        public static PTTBlock ParseToBlock(NetworkStream networkStream)
        {
            byte[]? command = null;
            byte[]? size = null;
            byte[]? payload = null;

            int bytesRead = networkStream.Read(command, 0, 1);

            if (bytesRead != 1)
            {
                throw new Exception("Failed to read command byte.");
            }

            byte blockCommand = command[0];

            if (!IsValidCommand(blockCommand))
            {
                throw new Exception("Incorrect command.");
            }

            bytesRead = networkStream.Read(size, 1, 4);

            if (bytesRead != 4)
            {
                throw new Exception("Failed to read size byte.");
            }

            int.TryParse(Encoding.ASCII.GetString(size), out int blockSize);

            bytesRead = networkStream.Read(payload, 4, blockSize);

            if (bytesRead != blockSize)
            {
                throw new Exception("Failed to read payload byte.");
            }

            string blockPayload = Encoding.ASCII.GetString(payload);

            return new PTTBlock(blockCommand, blockSize, blockPayload);
        }

        public static string ParseToString(PTTBlock block)
        {
            return block.ToString();
        }

        public static bool IsValidCommand(byte command) 
        {
            switch (command)
            {
                case 0x00:
                case 0x01:
                case 0x02:
                case 0x03:
                case 0x04:
                case 0x05:
                case 0x06:
                case 0x07:
                case 0x08:
                case 0x09:
                    return true;
                default:
                    return false;
            }
        }
    }
}
