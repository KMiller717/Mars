using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Utility
{
    public class SanitizeFile
    {
        public string fileName { get; set; }
        public string[] SanitizeFileContents(string fileName) 
        {
            //Grab file at root of project
            string projectRootPath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(projectRootPath, fileName);
            string[] fileContents = File.ReadAllLines(filePath);
            // Remove all empty lines from the file.
            fileContents = fileContents.Where(line => !string.IsNullOrEmpty(line)).ToArray();
            return fileContents;
        }
    }
}
