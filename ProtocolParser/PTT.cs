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
            return $"{_command}|{_size}|{_payload}";
        }
    }

    public class PTT
    {
        public static PTTBlock ParseToBlock(NetworkStream networkStream)
        {
            byte[] command = new byte[1];
            byte[] size = new byte[4];

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

            byte[] temp = new byte[1];

            for (int i = 0; i <= 5; i++)
            {
                networkStream.Read(temp, 0, 1);

                if (i == 0)
                {
                    continue;
                }

                if (temp[0] == 124)
                {
                    break;
                }

                size[i-1] = temp[0];
            }

            int.TryParse(Encoding.ASCII.GetString(size), out int blockSize);

            byte[]? payload = new byte[blockSize];

            if (blockCommand == 52)
            {
                return new PTTBlock(blockCommand, blockSize, "");
            }

            bytesRead = networkStream.Read(payload, 0, blockSize);

            if (bytesRead != blockSize)
            {
                throw new Exception("Failed to read payload byte.");
            }

            string blockPayload = Encoding.ASCII.GetString(payload);

            return new PTTBlock(blockCommand, blockSize ,blockPayload);
        }

        public static string ParseToString(PTTBlock block)
        {
            return block.ToString();
        }

        public static bool IsValidCommand(byte command) 
        {
            switch (command)
            {
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                    return true;
                default:
                    return false;
            }
        }
    }
}
