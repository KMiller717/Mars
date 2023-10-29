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
            Mission mission = new Mission(fileContents);

            try
            {
                mission.ConductMission();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured when trying to conduct your dangerous mission: {ex.Message}");
            }
        }
    }
}
