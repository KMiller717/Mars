using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover.Utility
{
    public class SanitizeFile
    {
        public List<Rover> Rovers { get; set; }
        public Grid Grid { get; set; }
        
        public SanitizeFile(string fileName) 
        {
            //Grab file at root of project
            string projectRootPath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectRootPath, fileName);
            string[] fileContents = File.ReadAllLines(filePath);
            // Remove all empty lines from the file.
            fileContents = fileContents.Where(line => !string.IsNullOrEmpty(line)).ToArray();

            //create Grid 
            CreateGrid(fileContents[0]);
            //create Rovers
            CreateRovers(fileContents);
        }

        public static bool CheckOnlyLRM(string str)
        {
            // Create a regular expression to match the letters L, R, or M
            var regex = new Regex(@"^[LRM]+$");

            // Check if the regex matches the entire string
            return regex.IsMatch(str);
        }

        public Grid CreateGrid(string gridInstructions)
        {
            Regex regex = new Regex(@"\d+"); //verify first line contains numbers
            MatchCollection matches = regex.Matches(gridInstructions);
            if (matches.Count != 2)
            {
                Console.WriteLine("Hm, please check grid boundaries provided and try again.");
                Environment.Exit(0);
            }
            (string X, string Y) = (matches[0].Value, matches[1].Value); //Set X and Y coordinates for grid
            return Grid = new Grid(int.Parse(Y), int.Parse(X));

        }

        public List<Rover> CreateRovers(string[] fileContents)
        {
            List<Rover> rovers = new List<Rover>();
            List<string> newFileContents = fileContents.ToList();
            newFileContents.RemoveAt(0);
            while (true)
            {
                bool commandStr = CheckOnlyLRM(newFileContents[1]);
                if (commandStr)
                {
                    Rover rover = new Rover(newFileContents[0], newFileContents[1]);
                    rovers.Add(rover);
                    newFileContents.RemoveAt(0);
                    newFileContents.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("Check command instructions given. Need to be L, R, or M only, please.");
                    Environment.Exit(0);
                }
                if (newFileContents.Count == 0) { break; }
            }
            return Rovers = rovers;

        }
    }
}
