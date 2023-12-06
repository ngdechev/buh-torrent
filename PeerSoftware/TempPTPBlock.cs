using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeerSoftware
{
    internal class TempPTPBlock
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public byte[] Data { get; set; }

        public TempPTPBlock(int id, int size, byte[] data)
        {
            Data = data;
            Id = id;
            Size = size;
        }
    }
}
