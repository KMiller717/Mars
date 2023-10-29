using MarsRover.Models;
using MarsRover.Utility;
using MarsRoverTest.Tests;

namespace MarsRoverTest.Tests
{
    [TestClass]
    public class SanitizeFileTests
    {
        [TestMethod]
        public void FileShouldHaveNoEmptyLines()
        {
            SanitizeFile sanitizeFile = new SanitizeFile { fileName = "../../../testData.txt" };
            string[] fileContents = sanitizeFile.SanitizeFileContents(sanitizeFile.fileName);
            var noEmptyLines = true;
            foreach (var line in fileContents)
            {
                if(String.IsNullOrEmpty(line))
                {
                    noEmptyLines = false;
                }
            }
            Assert.AreEqual(true, noEmptyLines);
        }
    }
}

