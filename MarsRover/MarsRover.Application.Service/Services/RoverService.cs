using System;
using System.Linq;
using MarsRover.Application.Contract.Constants;
using MarsRover.Application.Contract.Enums;
using MarsRover.Application.Contract.Models;
using MarsRover.Application.Contract.ServiceInterfaces;

namespace MarsRover.Application.Service.Services
{
    public class RoverService : IRoverService
    {
        private Size _plateauSize { get; set; }

        public void ExecuteCommand(Plateau plateau)
        {
            _plateauSize = plateau.PlateauSize;

            foreach (Rover rover in plateau.RoverList)
            {
                if (!ValidationRoverPosition(plateau, rover))
                {
                    throw new Exception("Invalid Rover Position");
                }

                rover.FirstRoverPosition = new RoverPosition() { X = rover.RoverPosition.X, Y = rover.RoverPosition.Y, Orientation = rover.RoverPosition.Orientation };

                char[] roverInstruction = rover.Instructions.ToCharArray();

                foreach (var instruction in roverInstruction)
                {
                    switch (instruction.ToString())
                    {
                        case Movement.Left:

                            TurnLeft(rover);

                            break;

                        case Movement.Right:

                            TurnRight(rover);

                            break;

                        case Movement.Move:

                            Move(rover);

                            if (!ValidationRoverPosition(plateau, rover))
                            {
                                rover.RoverPosition = rover.FirstRoverPosition;
                                continue;
                            }

                            break;

                        default:
                            throw new Exception("Invalid Instruction");
                    }
                }
            }
        }

        private void TurnLeft(Rover rover)
        {
            switch (rover.RoverPosition.Orientation)
            {
                case Orientation.North:
                    rover.RoverPosition.Orientation = Orientation.West;
                    break;
                case Orientation.South:
                    rover.RoverPosition.Orientation = Orientation.East;
                    break;
                case Orientation.East:
                    rover.RoverPosition.Orientation = Orientation.North;
                    break;
                case Orientation.West:
                    rover.RoverPosition.Orientation = Orientation.South;
                    break;
                default:
                    throw new Exception("Invalid Orientation Type");
            }
        }

        private void TurnRight(Rover rover)
        {
            switch (rover.RoverPosition.Orientation)
            {
                case Orientation.North:
                    rover.RoverPosition.Orientation = Orientation.East;
                    break;
                case Orientation.South:
                    rover.RoverPosition.Orientation = Orientation.West;
                    break;
                case Orientation.East:
                    rover.RoverPosition.Orientation = Orientation.South;
                    break;
                case Orientation.West:
                    rover.RoverPosition.Orientation = Orientation.North;
                    break;
                default:
                    throw new Exception("Invalid Orientation Type");
            }
        }

        private void Move(Rover rover)
        {
            switch (rover.RoverPosition.Orientation)
            {
                case Orientation.North:
                    rover.RoverPosition.Y += 1;
                    break;
                case Orientation.South:
                    rover.RoverPosition.Y -= 1;
                    break;
                case Orientation.East:
                    rover.RoverPosition.X += 1;
                    break;
                case Orientation.West:
                    rover.RoverPosition.X -= 1;
                    break;
                default:
                    throw new Exception("Invalid Orientation Type");
            }
        }

        private bool ValidationRoverPosition(Plateau plateau, Rover rover)
        {
            if (rover.RoverPosition.X < 0 || rover.RoverPosition.Y < 0 || _plateauSize.Width < rover.RoverPosition.X || _plateauSize.Height < rover.RoverPosition.Y)
            {
                return false;
            }

            if (plateau.RoverList.Any(x => x.Id != rover.Id &&
                                          x.RoverPosition.X == rover.RoverPosition.X &&
                                          x.RoverPosition.Y == rover.RoverPosition.Y))
            {
                return false;
            }

            return true;
        }
    }
}
