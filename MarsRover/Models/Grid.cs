using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Grid
    {
        public int longitude {get; set;} //length of grid's y-axis
        public int latitude { get; set; }  //length of grid's x-axis
        public Grid() { }
        public Grid(int longitudeY, int latitudeX)
        {
            longitude = longitudeY;
            latitude = latitudeX;
        }

        public Grid CreateViaFileContents(string[] fileContents)
        {
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
            return grid;
        }

    }
    
}
