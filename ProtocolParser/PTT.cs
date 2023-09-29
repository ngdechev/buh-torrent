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
        public PTTBlock ParseToBlock(NetworkStream networkStream)
        {
            byte[] command = new byte[4];
            byte[] payload = new byte[1020];

            int bytesRead = networkStream.Read(command, 0, 1);

            if(bytesRead != 1)
            {
                throw new Exception("Failed to read command byte.");
            }

            string blockCommand = Encoding.ASCII.GetString(command);

            if(!IsValidCommand(blockCommand))
            {
                throw new Exception("Invalid command.");
            }

            bytesRead = networkStream.Read(payload, 4, 1020);

            if(bytesRead <= 1)
            {
                throw new Exception("Failed to read payload data.");
            }

            string payloadCommand = Encoding.ASCII.GetString(payload);

            if(payloadCommand == null && blockCommand != "0x04")
            {
                throw new Exception("Invalid payload.");
            }

            return new PTTBlock(blockCommand, payloadCommand);
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
                    return true;
                default:
                    return false;
            }
        }

    }
}
