using ProtocolParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuhTorrentTestProject
{
    [TestFixture]
    public class PTPTests
    {
        [Test]
        public void ToPackage_ReturnsCorrectString()
        {
            //// Arrange
            //PTP_Block block = new PTP_Block(1, 5, "hello");

            //// Act
            //string result = block.ToPackage();

            //// Assert
            //Assert.AreEqual("105hello", result);
        }

        [Test]
        public void IsType_ReturnsTrueForAvailable()
        {
            //// Arrange
            //PTP_Block block = new PTP_Block(0, 10, "available");

            //// Act
            //bool result = block.IsType("available");

            //// Assert
            //Assert.IsTrue(result);
        }
    }
}
