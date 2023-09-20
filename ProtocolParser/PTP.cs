using System.Net.Sockets;

namespace PTP_Parser
{
    public class PTPBlock
    {
        private int _id;
        private int _size;
        private string _data;

        public PTPBlock(int id, int size, string data)
        {
            _data = data;
            _id = id;
            _size = size;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetSize()
        {
            return _size;
        }

        public string GetData()
        {
            return _data;
        }

        public string ToPackage()
        {
            return _id.ToString() + _size.ToString() + _data;
        }

        public bool IsType(string type)
        {
            if (_id != 0)
            {
                return false;
            }
            switch (type)
            {
                case "available":
                    {
                        return true;
                    }
                case "unavailable":
                    {
                        return true;
                    }
                case "StartPackage":
                    {
                        return true;
                    }
            }
            return false;
        }

    }
    public static class PTP
    {
        public static PTPBlock ParseToBlock(NetworkStream networkStream)
        {
            byte[]? id = null;
            byte[]? data = null;
            byte[]? size = null;

            networkStream.Read(id, 0, 4);
            int.TryParse(id.ToString(), out int block_id);
            networkStream.Read(size, 4, 4);
            int.TryParse(size.ToString(), out int block_size);
            networkStream.Read(data, 8, block_size);

            return new PTPBlock(block_id, block_size, data.ToString());
        }

        public static string ParseToPackage(PTPBlock block)
        {
            return block.ToPackage();
        }

        public static string AvailablePackage()
        {
            string msg = "available";
            PTPBlock response = new PTPBlock(0, msg.Length, msg);

            return response.ToPackage();
        }

        public static string UnavailablePackage()
        {
            string msg = "unavailable";
            PTPBlock response = new PTPBlock(0, msg.Length, msg);
            return response.ToPackage();
        }

        public static string StartPackage()
        {
            string msg = "StartPackage";
            PTPBlock response = new PTPBlock(0, msg.Length, msg);
            return response.ToPackage();
        }

    }

}