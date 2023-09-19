using System.Net.Sockets;

namespace PTP_Parser
{
    internal class PTP_Block
    {
        private int _id;
        private int _size;
        private string _data;

        public PTP_Block(int id, int size, string data)
        {
            _data = data;
            _id = id;
            _size = size;
        }

        public int Get_Id()
        {
            return _id;
        }

        public int Get_Size()
        {
            return _size;
        }

        public string Get_Data()
        {
            return _data;
        }

        public string ToPackage()
        {
            return _id.ToString() + _size.ToString() + _data;
        }

    }
    internal class PTP
    {
        public static PTP_Block Parse_To_Block(NetworkStream networkStream)
        {
            byte[]? id = null;
            byte[]? data = null;
            byte[]? size = null;

            networkStream.Read(id, 0, 4);
            int.TryParse(id.ToString(), out int block_id);
            networkStream.Read(size, 4, 4);
            int.TryParse(size.ToString(), out int block_size);
            networkStream.Read(data, 8, block_size);

            return new PTP_Block(block_id, block_size, data.ToString());
        }

        public static string Parse_To_Package(PTP_Block block)
        {
            return block.ToPackage();
        }

        public static string Available_Package()
        {
            string msg = "available";
            PTP_Block response = new PTP_Block(0, msg.Length, msg);

            return response.ToPackage();
        }

        public static string Unavailable_Package()
        {
            string msg = "unavailable";
            PTP_Block response = new PTP_Block(0, msg.Length, msg);
            return response.ToPackage();
        }

        public static string Start_Package()
        {
            string msg = "start_package";
            PTP_Block response = new PTP_Block(0, msg.Length, msg);
            return response.ToPackage();
        }

    }

}
