using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PeerSoftware.Services
{
    public class SharedFileServices
    {
        public Dictionary<string, string> _peersAndBlocks = new Dictionary<string, string>();

        public Dictionary<string, string> CalculateParticions(List<string> peersIpPlusPort, int sizeOfSharedFile)
        {
            int numberOfPeers = peersIpPlusPort.Count();

            if (numberOfPeers == 0)
            {
                throw new Exception("There are no active peers.");
            }

            if (numberOfPeers > 5) 
            {
                numberOfPeers = 5;
            }

            for (int i = 0; i < numberOfPeers; i++)
            {
                _peersAndBlocks.Add(peersIpPlusPort[i], "");
            }

            int numberOfBlocks = (int)Math.Ceiling((double)sizeOfSharedFile / 1016);

            int sortBlocks = numberOfBlocks / _peersAndBlocks.Count();
            int remainderBlocks = numberOfBlocks % _peersAndBlocks.Count();

            int startBlock = 1;
            int endBlock = sortBlocks;

            foreach (string peer in _peersAndBlocks.Keys)
            {
                if (peer == _peersAndBlocks.Keys.Last())
                {
                    endBlock += remainderBlocks;
                    _peersAndBlocks[peer] = startBlock + "-" + endBlock;
                    break;
                }

                _peersAndBlocks[peer] = startBlock + "-" + endBlock;

                startBlock = endBlock + 1;
                endBlock += sortBlocks;
            }

            return _peersAndBlocks;
        }
    }
}
