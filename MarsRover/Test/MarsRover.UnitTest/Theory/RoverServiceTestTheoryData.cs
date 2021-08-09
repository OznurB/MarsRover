using MarsRover.Application.Contract.Enums;
using MarsRover.Application.Contract.Models;
using MarsRover.UnitTest.PoCo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.UnitTest.Theory
{
    public class RoverServiceTestTheoryData : TheoryData<RoverServiceTestParameter>
    {
        public RoverServiceTestTheoryData()
        {
            Add(new RoverServiceTestParameter
            {
                Plateau = new Plateau
                {
                    PlateauSize = new Size { Width = 5, Height = 5 },
                    RoverList = new List<Rover> {
                        new Rover {
                            RoverPosition = new RoverPosition{ X = 1, Y = 2, Orientation = Orientation.North},
                            Instructions = "LMLMLMLMM"
                        }
                    },

                },
                Expected = new RoverPosition { X = 1, Y = 3, Orientation = Orientation.North }
            });

            Add(new RoverServiceTestParameter
            {
                Plateau = new Plateau
                {
                    PlateauSize = new Size { Width = 5, Height = 5 },
                    RoverList = new List<Rover> {
                        new Rover {
                            RoverPosition = new RoverPosition{ X = 3, Y = 3, Orientation = Orientation.East},
                            Instructions = "MMRMMRMRRM"
                        }
                    },

                },
                Expected = new RoverPosition { X = 5, Y = 1, Orientation = Orientation.East }
            });
        }
    }
}
