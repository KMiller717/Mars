using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Mission
    {
        public List<Rover> Rovers { get; set; }
        public Grid grid { get; set; }

        public Mission(List<Rover> rovers, Grid gridProvided)
        {
            Rovers = rovers;
            grid = gridProvided;
        }

        public Mission StartMission(List<string> newFileContents)
        {
            List<Rover> rovers = new List<Rover>();

            while (true)
            {
                Rover rover = new Rover(newFileContents[0], newFileContents[1]);
                rovers.Add(rover);
                newFileContents.RemoveAt(0);
                newFileContents.RemoveAt(0);

                if (newFileContents.Count == 0) { break; }
            }
            Rovers = rovers;
            Mission mission = new Mission(rovers, grid);
            return mission;
        }

        public void ConductMission(Mission mission)
        {
            foreach(Rover rover in Rovers)
            {
                rover.CompleteMission(mission.grid);
                rover.CurrentPosition();
            }
        }
    }
}
