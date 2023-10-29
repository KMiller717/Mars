using MarsRover.Models;
using MarsRover.Utility;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Models;
using MarsRover.Utility;
using MarsRoverTest.Tests;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace MarsRoverTest.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void TestGridCreation()
        {
            var classToReadFile = new SanitizeFile { fileName = "../../../testData.txt" };
            string[] fileContents = new string[0];
            fileContents = classToReadFile.SanitizeFileContents(classToReadFile.fileName);

            
            //arrange
            string grabFirstLineInstructions = fileContents[0];
            Regex regex = new Regex(@"\d+"); //verify first line contains numbers
            MatchCollection matches = regex.Matches(grabFirstLineInstructions);
            if (matches.Count != 2)
            {
                Console.WriteLine("Hm, please check grid boundaries provided and try again.");
                Environment.Exit(0);
            }
            (string X, string Y) = (matches[0].Value, matches[1].Value); //Set X and Y coordinates for grid
            Grid grid = new Grid(int.Parse(X), int.Parse(Y));
            Assert.AreEqual(5, grid.latitude);
            Assert.AreEqual(5, grid.longitude);
        }
    }
    
}
