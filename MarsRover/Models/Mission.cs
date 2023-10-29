using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public interface IMission
    {
        void ConductMission();
    }
    public class Mission : IMission
    {
        public List<Rover> Rovers { get; set; }
        public Grid grid { get; set; }

        public Mission(List<Rover> rovers, Grid gridProvided)
        {
            Rovers = rovers;
            grid = gridProvided;
        }

        public void ConductMission()
        {
            foreach(Rover rover in Rovers)
            {
                rover.CompleteMission(grid);
                rover.CurrentPosition();
            }
        }
    }
}
