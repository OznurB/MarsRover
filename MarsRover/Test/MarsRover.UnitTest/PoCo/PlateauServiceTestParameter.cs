using MarsRover.Application.Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.UnitTest.PoCo
{
    public class PlateauServiceTestParameter
    {
        public Size Actual { get; set; }
        public Rover Rover { get; set; }
        public bool Expected { get; set; }
    }
}
