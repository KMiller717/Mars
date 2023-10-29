using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Utility;
using MarsRoverTest.Tests;

namespace MarsRoverTest.Tests
{
    [TestClass]
    public class SanitizeFileTests
    {
        [TestMethod]
        public void TestFileCanCreateMissionRequirements()
        {
            SanitizeFile sanitizeFile = new SanitizeFile("../../../testData.txt");
            //Grid
            var expectedGridLongitude = 5;
            var expectedGridLatitude = 5;
            var actualGridLongitude = sanitizeFile.Grid.YAxisLength;
            var actualGridLatitude  = sanitizeFile.Grid.XAxisLength;

            
            //Rover
            var expectedRoverX = 1;
            var expectedRoverY = 2;
            var actualRoverX = sanitizeFile.Rovers[0].X;
            var actualRoverY = sanitizeFile.Rovers[0].Y;

            var expectedRoverHeader = DirectionType.N;
            var actualRoverHeader = sanitizeFile.Rovers[0].Heading;

            var expectedCommandStr = "LMLMLMLMM";
            var actualCommandStr = sanitizeFile.Rovers[0].CommandStr;

            Assert.AreEqual(expectedGridLongitude, actualGridLongitude);
            Assert.AreEqual(actualGridLatitude, expectedGridLatitude);
            Assert.AreEqual(expectedRoverY, actualRoverY);
            Assert.AreEqual(expectedRoverX, actualRoverX);
            Assert.AreEqual(expectedRoverHeader, actualRoverHeader);
            Assert.AreEqual(expectedCommandStr, actualCommandStr);

        }
    }
}

