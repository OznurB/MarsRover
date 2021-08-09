using MarsRover.Application.Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.UnitTest.PoCo
{
    public class RoverServiceTestParameter
    {
        public Plateau Plateau { get; set; }
        public RoverPosition Expected { get; set; }
    }
}
