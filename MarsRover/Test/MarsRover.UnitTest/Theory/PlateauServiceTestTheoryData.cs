using MarsRover.Application.Contract.Enums;
using MarsRover.Application.Contract.Models;
using MarsRover.UnitTest.PoCo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.UnitTest.Theory
{
    public class PlateauServiceTestTheoryData : TheoryData<PlateauServiceTestParameter>
    {
        public PlateauServiceTestTheoryData()
        {
            Add(new PlateauServiceTestParameter
            {
                Actual = new Size { Width = 5, Height = 5 },
                Rover = new Rover { RoverPosition = new RoverPosition { Orientation = Orientation.North, X = 1, Y = 2 } },
                Expected = true
            });
        }
        public static IEnumerable<object[]> IsValidSize
        {
            get
            {
                yield return new object[] { null, false };
                yield return new object[] { new Size { Width = 2, Height = 4 }, true };
                yield return new object[] { new Size { Width = -2, Height = 3 }, false };
            }
        }
    }
}
