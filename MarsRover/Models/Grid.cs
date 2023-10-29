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
        public int longitude {get; } //length of grid's y-axis
        public int latitude { get; }  //length of grid's x-axis
        public Grid(int longitudeY, int latitudeX)
        {
            longitude = longitudeY;
            latitude = latitudeX;
        }

    }
    
}
