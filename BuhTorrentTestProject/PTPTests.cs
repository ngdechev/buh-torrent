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
       /* [Test]
        public void ToPackageReturnsCorrectString()
        {
            // Arrange
            PTPBlock block = new PTPBlock(1, 5, "hello");

            // Act
            string result = block.ToPackage();

            // Assert
            Assert.AreEqual("15hello", result);
        }

        [Test]
        public void IsTypeReturnsTrueForAvailable()
        {
            // Arrange
            PTPBlock block = new PTPBlock(0, 10, "available");

            // Act
            bool result = block.IsType("available");

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void UnavailablePackageReturnsCorrectString()
        {
            // Act
            string result = PTP.UnavailablePackage();

            // Assert
            Assert.AreEqual("011unavailable", result);
        }
        [Test]
        public void AvailablePackageReturnsCorrectString()
        {
            // Act
            string result = PTP.AvailablePackage();

            // Assert
            Assert.AreEqual("09available", result);
        }
        [Test]
        public void StartPackageReturnsCorrectString()
        {
            // Act
            string result = PTP.StartPackage();

            // Assert
            Assert.AreEqual("012StartPackage", result);
        }

        [Test]
        public void GetSizeReturnsCorrectValue()
        {
            // Arrange
            PTPBlock block = new PTPBlock(1, 5, "hello");

            // Act
            int size = block.GetSize();
            string data = block.GetData();
            int id = block.GetId();

            // Assert
            Assert.AreEqual(5, size);
            Assert.AreEqual("hello", data);
            Assert.AreEqual(1, id);
        }
        [Test]
        public void IsTypeAvailableTypeReturnsTrue()
        {
            // Arrange
            PTPBlock block = new PTPBlock(0, 5, "hello");

            // Act
            bool isAvailable = block.IsType("available");

            // Assert
            Assert.IsTrue(isAvailable);
        }

        [Test]
        public void IsTypeUnavailableTypeReturnsTrue()
        {
            // Arrange
            PTPBlock block = new PTPBlock(0, 5, "hello");

            // Act
            bool isUnavailable = block.IsType("unavailable");

            // Assert
            Assert.IsTrue(isUnavailable);
        }

        [Test]
        public void IsTypeStartPackageTypeReturnsTrue()
        {
            // Arrange
            PTPBlock block = new PTPBlock(0, 5, "hello");

            // Act
            bool isStartPackage = block.IsType("StartPackage");

            // Assert
            Assert.IsTrue(isStartPackage);
        }

        [Test]
        public void IsTypeNonMatchingTypeReturnsFalse()
        {
            // Arrange
            PTPBlock block = new PTPBlock(0, 5, "hello");

            // Act
            bool isNonMatching = block.IsType("non_matching");

            // Assert
            Assert.IsFalse(isNonMatching);
        }

        [Test]
        public void IsTypeNonZeroIdReturnsFalse()
        {
            // Arrange
            PTPBlock block = new PTPBlock(1, 5, "hello");

            // Act
            bool isAnyType = block.IsType("available");

            // Assert
            Assert.IsFalse(isAnyType);
        }

        [Test]
        public void ParseToPackageReturnsCorrectPackage()
        {
            // Arrange
            PTPBlock block = new PTPBlock(1, 5, "hello");

            // Act
            string result = PTP.ParseToPackage(block);

            // Assert
            Assert.AreEqual("15hello", result);
        }*/
    }
}
