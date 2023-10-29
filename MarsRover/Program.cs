// See https://aka.ms/new-console-template for more information
using MarsRover.Models;
using MarsRover.Enums;
using static MarsRover.Program;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Text.RegularExpressions;
using MarsRover.Utility;
using System.Linq.Expressions;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read and santize file
            var classToReadFile = new SanitizeFile { fileName = "../../../sample.txt" };
            string[] fileContents = new string[0];

            try
            {
                fileContents = classToReadFile.SanitizeFileContents(classToReadFile.fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured when trying to read the file: {ex.Message}");
            }

            //Create Grid
            Grid grid = new Grid();
            try
            {
                grid = grid.CreateViaFileContents(fileContents);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured when trying to read the file: {ex.Message}");
            }

            //Remove grid instructions now that grid is created
            List<string> newFileContents = fileContents.ToList();
            newFileContents.RemoveAt(0);

            //Empty rover list to start. 
            List<Rover> rovers = new List<Rover>();

            //Mission is a Go! Let's do this.
            try
            {
                Mission mission = new Mission(rovers, grid);
                mission.StartMission(newFileContents); //Create Rovers
                mission.ConductMission(mission);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured when trying to conduct your dangerous mission: {ex.Message}");
            }
        }
    }
}
