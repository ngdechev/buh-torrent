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
        public Dictionary<string, List<int>> _peersAndBlocks = new Dictionary<string, List<int>>();

        public Dictionary<string, List<int>> CalculateParticions(List<string> peersIpPlusPort, int sizeOfSharedFile)
        {
            int numberOfPeers = peersIpPlusPort.Count();
            int helperForFor = 0;
            if (numberOfPeers == 0)
            {
                throw new Exception("There are no active peers.");
            }
            if (numberOfPeers < 5)
            {
                helperForFor = numberOfPeers;
            }
            else
            {
                helperForFor = 5;
            }

            for (int i = 0; i < helperForFor; i++)
            {
                _peersAndBlocks.Add(peersIpPlusPort[i], new List<int>());
            }

            int numberOfBlocks = (int)Math.Ceiling((double)sizeOfSharedFile / 1016);

            int sortBlocks = numberOfBlocks / _peersAndBlocks.Count();
            int remainderBlocks = numberOfBlocks % _peersAndBlocks.Count();

            int counter = 1;
            List<int> tempList = new List<int>();

            foreach (string peers in _peersAndBlocks.Keys)
            {
                tempList.Clear();

                for (int j = 1; j <= sortBlocks; j++)
                {
                    tempList.Add(counter);
                    counter++;
                }

                _peersAndBlocks[peers] = tempList;
            }

            if (remainderBlocks > 0) 
            {
                for(int i = 0; i < remainderBlocks; i++)
                {
                    _peersAndBlocks.First().Value.Add(counter);
                }
            }

            return _peersAndBlocks;
        }
    }
}
