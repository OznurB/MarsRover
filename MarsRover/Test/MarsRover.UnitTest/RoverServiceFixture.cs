using MarsRover.Application.Contract.Models;
using MarsRover.Application.Contract.ServiceInterfaces;
using MarsRover.Application.Service.Services;
using MarsRover.UnitTest.PoCo;
using MarsRover.UnitTest.Theory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace MarsRover.UnitTest
{
    public class RoverServiceFixture
    {
        private Mock<IPlateauService> _plateauServiceMock;
        private IRoverService _roverService;

        public Plateau _plateau;


        public RoverServiceFixture()
        {
            _plateauServiceMock = new Mock<IPlateauService>();
            _roverService = new RoverService();

            _plateau = new Plateau { PlateauSize = new Size { Width = 5, Height = 5 } };
        }

        [Theory, ClassData(typeof(RoverServiceTestTheoryData))]
        public void ExecuteCommand_Should_Return_As_Expected(RoverServiceTestParameter parameter)
        {
            _roverService.ExecuteCommand(parameter.Plateau);

            Assert.Equal(parameter.Expected.ToString(), parameter.Plateau.RoverList.FirstOrDefault().RoverPosition.ToString());
        }
    }
}
