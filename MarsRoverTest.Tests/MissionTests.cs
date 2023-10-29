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

namespace MarsRoverTest.Tests
{
    [TestClass]
    public class MissionTests
    {
        public Mission mission { get; set; }
        public List<string> fileContents { get; set; }
        public MissionTests()
        {
            Grid grid = new Grid(5, 5);
            List<Rover> rovers = new List<Rover>();
            this.mission = new Mission(rovers, grid);
        }

        [TestMethod]
        public void VerifyMissionCreation()
        {
            //arrange
            List<string> newFileContents = new List<string>();
            newFileContents.Add("1 2 N");
            newFileContents.Add("LMLMLMLMM");
            
            mission.StartMission(newFileContents);
            int roverCount = mission.Rovers.Count;
            Grid grid = mission.grid;           
            Assert.AreEqual(roverCount, 1);
            Assert.AreEqual(grid.latitude, 5);
            Assert.AreEqual(grid.longitude, 5);
        }

        [TestMethod]
        public void TestCompleteMissionSingleCoordinates()
        {
            List<string> newFileContents = new List<string>();
            newFileContents.Add("1 2 N");
            newFileContents.Add("LMLMLMLMM");
            

        }


    }
}
