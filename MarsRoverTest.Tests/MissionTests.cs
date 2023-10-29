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

namespace MarsRoverTest.Tests
{
    [TestClass]
    public class MissionTests
    {
        public Mission mission { get; set; }
        public MissionTests()
        {
            Grid grid = new Grid(5, 5);
            List<Rover> rovers = new List<Rover>();
            this.mission = new Mission(rovers, grid);
        }

        [TestMethod]
        public void TestMissionCreation()
        {
            //arrange
            var classToReadFile = new SanitizeFile { fileName = "../../../testData.txt" };
            string[] fileContents = new string[0];
            fileContents = classToReadFile.SanitizeFileContents(classToReadFile.fileName);
            Mission mission = new Mission(fileContents);
            int roverCount = mission.Rovers.Count;

            Assert.AreEqual(roverCount, 1);
            Assert.AreEqual(mission.grid.latitude, 5);
            Assert.AreEqual(mission.grid.longitude, 5);
        }

        [TestMethod]
        public void TestCompleteMissionOneRover()
        {
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover("1 2 N", "LMLMLMLMM"));
            Grid grid = new Grid(5, 5);
            Mission newMission = new Mission(rovers, grid);
            newMission.ConductMission();

            //compare outcome
            var expectedOutcome = "Rover is currently at: (1, 3), heading N";
            var actualOutcome = rovers[0].CurrentPosition();

            //assert
            Assert.AreEqual(expectedOutcome, actualOutcome);


        }

        [TestMethod]
        public void TestCompleteMissionMultipleRover()
        {
            List<Rover> rovers = new List<Rover>();
            rovers.Add(new Rover("1 2 N", "LMLMLMLMM"));
            rovers.Add(new Rover("3 3 E", "MMRM"));
            Grid grid = new Grid(5, 5);
            Mission newMission = new Mission(rovers, grid);
            newMission.ConductMission();

            //compare outcome
            var expectedOutcomeRover1 = "Rover is currently at: (1, 3), heading N";
            var actualOutcomeRover1 = rovers[0].CurrentPosition();
            var expectedOutcomeRover2 = "Rover is currently at: (5, 2), heading S";
            var actualOutcomeRover2 = rovers[1].CurrentPosition();

            //assert
            Assert.AreEqual(expectedOutcomeRover1, actualOutcomeRover1);
            Assert.AreEqual(expectedOutcomeRover2 , actualOutcomeRover2);
        }

    }
}
