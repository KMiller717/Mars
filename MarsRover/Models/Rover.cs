using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace MarsRover.Models
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CompassType heading { get; set; }
        public string CommandStr { get; set; }

        List<Rover> rover = new List<Rover>(0);
        public Rover(string locationStr, string commandStr)
        {
            locationStr.Replace(" ", "");
            Regex regex = new Regex(@"\w");
            int numberOfCharacters = regex.Matches(locationStr).Count;
            if (numberOfCharacters == 3)
            {
                var startingInstructions = regex.Matches(locationStr);
                X = int.Parse(startingInstructions[0].Value);
                Y = int.Parse(startingInstructions[1].Value);
                heading = (CompassType)Enum.Parse(typeof(CompassType), startingInstructions[2].Value);
                CommandStr = commandStr;
            }
            else
            {
                Console.WriteLine("Hm, please provide starting coordinates and heading direction.");
                Environment.Exit(0);
            }
        }

        public void CompleteMission(Grid grid)
        {
            foreach(var command in CommandStr)
            {
                ExecuteCommand(grid, command.ToString());
            }
        }
        public string CurrentPosition()
        {
            Console.WriteLine("Rover is currently at: ({0}, {1}), heading {2}", X, Y, heading);
            return $"Rover is currently at: ({X}, {Y}), heading {heading}";
        }

        private void ExecuteCommand(Grid grid, string command)
        {
            foreach (var c in command)
            {
               
                switch (c)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        MoveForward();
                        break;
                    default:
                        throw new Exception(string.Format("Invalid command, {0}, given.  Please verify directions and re-try.", command));
                }
                if (X < 0 || X > grid.latitude || Y < 0 || Y > grid.longitude)
                {
                    Console.WriteLine("Oops, silly NASA instructions - you fell off the map!");
                    Environment.Exit(0);
                }
            }
        }


        public void TurnLeft()
        {
            heading = (heading - 1) < CompassType.N ? CompassType.W : heading - 1;
        }

        public void TurnRight()
        {
            heading = (heading + 1) > CompassType.W ? CompassType.N : heading + 1;
        }

        public void MoveForward()
        {
            if (heading == CompassType.N)
            {
                Y++;
            }
            else if (heading == CompassType.E)
            {
                X++;
            }
            else if (heading == CompassType.S)
            {
                Y--;
            }
            else if (heading == CompassType.W)
            {
                X--;
            }
        }

    }
}
