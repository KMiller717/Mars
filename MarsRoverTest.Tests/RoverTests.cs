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
    public class RoverTests
    {
        public Rover rover { get; set; }

        public RoverTests() 
        {
            this.rover = new Rover("1 2 N", "LMLMLMLMM");
        }

        [TestMethod]
        public void TestRoverCreation()
        {
            Assert.AreEqual(1, rover.X);
            Assert.AreEqual(2, rover.Y);
            Assert.AreEqual(MarsRover.Enums.DirectionType.N, rover.heading);
            Assert.AreEqual("LMLMLMLMM", rover.CommandStr);
        }
        [TestMethod]
        public void TestTurnLeft()
        {
            rover.TurnLeft();
            Assert.AreEqual(MarsRover.Enums.DirectionType.W, rover.heading);
        }

        [TestMethod]
        public void TestTurnRight()
        {
            rover.TurnRight();
            Assert.AreEqual(MarsRover.Enums.DirectionType.E, rover.heading);
        }
        
        [TestMethod]
        public void TestMoveForward()
        {
            rover.MoveForward();
            Assert.AreEqual(MarsRover.Enums.DirectionType.N, rover.heading);
            Assert.AreEqual(rover.Y, 3);
        }
    }
}
