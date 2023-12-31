﻿// See https://aka.ms/new-console-template for more information
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
            //grab file from Root of project
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            SanitizeFile postSanitizationMissionObjects = new SanitizeFile($"{projectDirectory}/sample.txt" );

            //create the Mission from file info
            Mission mission = new Mission(postSanitizationMissionObjects.Rovers, postSanitizationMissionObjects.Grid);

            try
            {
                //Let's do this!
                mission.ConductMission();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured when trying to conduct your dangerous mission: {ex.Message}");
            }
        }
    }
}
