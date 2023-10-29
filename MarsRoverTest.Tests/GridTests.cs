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
            var classToReadFile = new SanitizeFile("../../../testData.txt" );
        
            Grid grid = new Grid(classToReadFile.Grid.XAxisLength, classToReadFile.Grid.YAxisLength);
            Assert.AreEqual(5, grid.XAxisLength);
            Assert.AreEqual(5, grid.YAxisLength);
        }
    }
    
}
