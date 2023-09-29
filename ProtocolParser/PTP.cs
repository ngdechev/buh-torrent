using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace PTP_Parser
{
    public class PTPBlock
    {
        private int _id;
        private int _size;
        private byte[] _data;

        public PTPBlock(int id, int size, byte[] data)
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
            return Encoding.ASCII.GetString(_data);
        }

        public byte[] ToPackage()
        {
            return  ConcatenateByteArrays(BitConverter.GetBytes(_id), BitConverter.GetBytes(_size), _data);
        }
        public byte[] ConcatenateByteArrays(params byte[][] arrays)
        {
            int totalLength = 0;

            // Calculate the total length of the concatenated array.
            foreach (byte[] array in arrays)
            {
                totalLength += array.Length;
            }

            // Create a new byte array with the calculated length.
            byte[] result = new byte[totalLength];

            int offset = 0;

            // Copy each array into the result array.
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, result, offset, array.Length);
                offset += array.Length;
            }

            return result;
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
    public static class PTPParser
    {
        public static PTPBlock ParseToBlock(NetworkStream networkStream)
        {
            byte[]? id = null;
            byte[]? data = null;
            byte[]? size = null;

            networkStream.Read(id, 0, 4);
            int.TryParse(Encoding.ASCII.GetString(id), out int block_id);
            networkStream.Read(size, 4, 4);
            int.TryParse(Encoding.ASCII.GetString(size), out int block_size);
            networkStream.Read(data, 8, block_size);
            
            return new PTPBlock(block_id, block_size, data);
        }

        public static byte[] ParseToPackage(PTPBlock block)
        {
            return block.ToPackage();
        }

        public static byte[] AvailablePackage()
        {
            string msg = "available";
            PTPBlock response = new PTPBlock(0, msg.Length, Encoding.ASCII.GetBytes( msg));

            return response.ToPackage();
        }

        public static byte[] UnavailablePackage()
        {
            string msg = "unavailable";
            PTPBlock response = new PTPBlock(0, msg.Length, Encoding.ASCII.GetBytes(msg));
            return response.ToPackage();
        }

        public static byte[] StartPackage()
        {
            string msg = "StartPackage";
            PTPBlock response = new PTPBlock(0, msg.Length, Encoding.ASCII.GetBytes(msg));
            return response.ToPackage();
        }

    }
    

}