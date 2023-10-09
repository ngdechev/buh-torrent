using System.Net.Sockets;
using System.Text;

namespace PTT_Parser
{
    public class PTTBlock
    {
        private string _command;
        private string _payload;

        public PTTBlock(string command, string payload)
        {
            _command = command;
            _payload = payload;
        }

        public string GetCommand()
        {
            return _command;
        }

        public string GetPayload()
        {
            return _payload;
        }

        public string ToString()
        {
            return _command + _payload;
        }
    }

    public class PTT
    {
        public static PTTBlock ParseToBlock(NetworkStream networkStream)
        {
            
            byte[] command = new byte[4];

            int bytesRead = networkStream.Read(command, 0, 4);


            if (bytesRead != 4)


            {
                throw new Exception("Failed to read command byte.");
            }

            string blockCommand = Encoding.ASCII.GetString(command);

            if (!IsValidCommand(blockCommand))
            {
                throw new Exception("Invalid command.");
            }


            if (blockCommand == "0x05")

            {
                byte[] lengthIndicator = new byte[4];
                bytesRead = networkStream.Read(lengthIndicator, 0, 4);

                if (bytesRead != 4)
                {
                    throw new Exception("Failed to read length indicator.");
                }

                int totalLength = BitConverter.ToInt32(lengthIndicator, 0);

                List<byte[]> payloadChunks = new List<byte[]>();
                int totalBytesRead = 0;
                int chunkSize = 1020;

                while (totalBytesRead < totalLength)
                {
                    int remainingBytes = totalLength - totalBytesRead;
                    int bytesToRead = Math.Min(chunkSize, remainingBytes);

                    byte[] chunk = new byte[bytesToRead];
                    bytesRead = networkStream.Read(chunk, 0, bytesToRead);

                    if (bytesRead <= 0)
                    {
                        throw new Exception("Failed to read payload data.");
                    }

                    payloadChunks.Add(chunk);
                    totalBytesRead += bytesRead;
                }

                byte[] payload = payloadChunks.SelectMany(chunk => chunk).ToArray();
                string payloadCommand = Encoding.ASCII.GetString(payload);

                return new PTTBlock(blockCommand, payloadCommand);
            }
            else
            {
                byte[] payload = new byte[1020];
                bytesRead = networkStream.Read(payload, 0, 1020);

                if (bytesRead <= 0)
                {
                    throw new Exception("Failed to read payload data.");
                }

                string payloadCommand = Encoding.ASCII.GetString(payload);

                return new PTTBlock(blockCommand, payloadCommand);
            }
        }

        public static string ParseToString(PTTBlock block)
        {
            return block.ToString();
        }

        public static bool IsValidCommand(string command) 
        {
            switch (command)
            {
                case "0x00":
                case "0x01":
                case "0x02":
                case "0x03":
                case "0x04":
                case "0x05":
                case "0x06":
                case "0x07":
                case "0x08":
                case "0x09":
                    return true;
                default:
                    return false;
            }
        }
    }
}
