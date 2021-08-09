using MarsRover.Application.Contract.Enums;

namespace MarsRover.Application.Contract.Models
{
    public class RoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Orientation.ToString().Substring(0, 1));
        }

    }
}
