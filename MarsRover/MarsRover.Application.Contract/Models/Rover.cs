using System;

namespace MarsRover.Application.Contract.Models
{
    public class Rover
    {
        public Guid Id = Guid.NewGuid();

        public RoverPosition RoverPosition { get; set; }

        public string Instructions { get; set; }

        public RoverPosition FirstRoverPosition { get; set; }
    }
}
