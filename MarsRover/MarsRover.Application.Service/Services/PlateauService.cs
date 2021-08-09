using System;
using MarsRover.Application.Contract.Models;
using MarsRover.Application.Contract.ServiceInterfaces;

namespace MarsRover.Application.Service.Services
{
    public class PlateauService : IPlateauService
    {
        private Plateau _plateau { get; set; }

        public void CreatePlateau(Plateau plateau)
        {
            _plateau = new Plateau { PlateauSize = plateau.PlateauSize, RoverList = plateau.RoverList };
        }

        public void IsValidSize(Size size)
        {
            if (size == null || size.Width <= 1 || size.Height <= 1)
            {
                throw new Exception("Invalid Plateau Size");
            }
        }
    }

}
