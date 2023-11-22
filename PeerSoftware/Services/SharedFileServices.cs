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
        public Dictionary<string, string> _newPeersAndBlocks = new Dictionary<string, string>();

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
        public Dictionary<string, string> ReCalculateParticions(List<string> peersIpPlusPort, int sizeOfSharedFile,List<int> downloadBlocks)
        {
            List<int> blocksForDownload=new List<int>();
            List<string> listWithFinalyBlocks = new List<string>();
            _peersAndBlocks.Clear();
            _peersAndBlocks=CalculateParticions(peersIpPlusPort,sizeOfSharedFile);

            foreach (var pair in _peersAndBlocks)
            {
                //Split blocks first and last from string
                string[] blocks = pair.Value.Split("-", 2);
                int firstBlocks = int.Parse(blocks[0]);
                int LastBlocks = int.Parse(blocks[1]);
                //Add Every block between first and last block and add first and last blocks
                for (int i = firstBlocks; i < LastBlocks; i++)
                {
                    blocksForDownload.Add(i);
                }
                //Delete blocks we have
                foreach (int delBlocks in downloadBlocks)
                {
                    for (int i = 0; i < blocksForDownload.Count; i++)
                    {
                        if (blocksForDownload[i] == delBlocks)
                        {
                            blocksForDownload.RemoveAt(i);
                        }
                    }
                }
                //Split blocks and make new blocks from to
                listWithFinalyBlocks = SplitBlocks(blocksForDownload);
                //Add in new dictionary 
                foreach (var block in listWithFinalyBlocks)
                {
                    _newPeersAndBlocks.Add(pair.Key, block);
                }
            }
            return _newPeersAndBlocks;
        }
        public List<string> SplitBlocks(List<int> inputList)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> sublist = new List<int> { inputList[0] };
            List<string>list = new List<string>();
            for (int i = 1; i < inputList.Count; i++)
            {
                if (inputList[i] - inputList[i - 1] > 1)
                {
                    result.Add(sublist);
                    sublist = new List<int> { inputList[i] };
                }
                else
                {
                    sublist.Add(inputList[i]);
                }
            }
            result.Add(sublist);
            foreach (List<int> listWithBlocks in result)
            {
                string blocks = $"{listWithBlocks.First()}-{listWithBlocks.Last()}";
                list.Add(blocks);
            }
            return list;
        }
    }
}
