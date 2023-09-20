using PTP_Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BuhTorrentTestProject
{
    [TestFixture]
    public class PTPTests
    {
        [Test]
        public void ToPackage_ReturnsCorrectString()
        {
            // Arrange
            PTP_Block block = new PTP_Block(1, 5, "hello");

            // Act
            string result = block.ToPackage();

            // Assert
            Assert.AreEqual("15hello", result);
        }

        [Test]
        public void IsType_ReturnsTrueForAvailable()
        {
            // Arrange
            PTP_Block block = new PTP_Block(0, 10, "available");

            // Act
            bool result = block.IsType("available");

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void UnavailablePackage_ReturnsCorrectString()
        {
            // Act
            string result = PTP.Unavailable_Package();

            // Assert
            Assert.AreEqual("011unavailable", result);
        }
        [Test]
        public void AvailablePackage_ReturnsCorrectString()
        {
            // Act
            string result = PTP.Available_Package();

            // Assert
            Assert.AreEqual("09available", result);
        }
        [Test]
        public void StartPackage_ReturnsCorrectString()
        {
            // Act
            string result = PTP.Start_Package();

            // Assert
            Assert.AreEqual("013start_package", result);
        }

        [Test]
        public void Get_Size_ReturnsCorrectValue()
        {
            // Arrange
            PTP_Block block = new PTP_Block(1, 5, "hello");

            // Act
            int size = block.Get_Size();
            string data = block.Get_Data();
            int id = block.Get_Id();

            // Assert
            Assert.AreEqual(5, size);
            Assert.AreEqual("hello", data);
            Assert.AreEqual(1, id);
        }
        [Test]
        public void IsType_AvailableType_ReturnsTrue()
        {
            // Arrange
            PTP_Block block = new PTP_Block(0, 5, "hello");

            // Act
            bool isAvailable = block.IsType("available");

            // Assert
            Assert.IsTrue(isAvailable);
        }

        [Test]
        public void IsType_UnavailableType_ReturnsTrue()
        {
            // Arrange
            PTP_Block block = new PTP_Block(0, 5, "hello");

            // Act
            bool isUnavailable = block.IsType("unavailable");

            // Assert
            Assert.IsTrue(isUnavailable);
        }

        [Test]
        public void IsType_StartPackageType_ReturnsTrue()
        {
            // Arrange
            PTP_Block block = new PTP_Block(0, 5, "hello");

            // Act
            bool isStartPackage = block.IsType("start_package");

            // Assert
            Assert.IsTrue(isStartPackage);
        }

        [Test]
        public void IsType_NonMatchingType_ReturnsFalse()
        {
            // Arrange
            PTP_Block block = new PTP_Block(0, 5, "hello");

            // Act
            bool isNonMatching = block.IsType("non_matching");

            // Assert
            Assert.IsFalse(isNonMatching);
        }

        [Test]
        public void IsType_NonZeroId_ReturnsFalse()
        {
            // Arrange
            PTP_Block block = new PTP_Block(1, 5, "hello");

            // Act
            bool isAnyType = block.IsType("available");

            // Assert
            Assert.IsFalse(isAnyType);
        }

        [Test]
        public void ParseToPackage_ReturnsCorrectPackage()
        {
            // Arrange
            PTP_Block block = new PTP_Block(1, 5, "hello");

            // Act
            string result = PTP.Parse_To_Package(block);

            // Assert
            Assert.AreEqual("15hello", result);
        }
    }
}
