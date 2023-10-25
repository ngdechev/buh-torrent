using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeerSoftware.Utils
{
    public class CommonUtils
    {
        public string FormatFileSize(long sizeInBytes)
        {
            double sizeInKB = (double)sizeInBytes / 1024;
            double sizeInMB = sizeInKB / 1024;
            double sizeInGB = sizeInMB / 1024;

            if (sizeInGB >= 1)
            {
                return $"{sizeInGB:0.00} GB";
            }
            else if (sizeInMB >= 1)
            {
                return $"{sizeInMB:0.00} MB";
            }
            else
            {
                return $"{sizeInKB:0.00} KB";
            }
        }
    }
}
