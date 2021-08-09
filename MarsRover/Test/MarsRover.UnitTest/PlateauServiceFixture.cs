using MarsRover.Application.Contract.Models;
using MarsRover.Application.Contract.ServiceInterfaces;
using MarsRover.Application.Service.Services;
using MarsRover.UnitTest.PoCo;
using MarsRover.UnitTest.Theory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.UnitTest
{
    public class PlateauServiceFixture
    {
        private Mock<IPlateauService> _plateauServiceMock;
        private IPlateauService _plateauService;
        public Plateau _plateau;

        public PlateauServiceFixture()
        {
            _plateauServiceMock = new Mock<IPlateauService>();
            _plateauService = new PlateauService();

            _plateau = new Plateau { PlateauSize = new Size { Width = 5, Height = 5 } };

            _plateauService.CreatePlateau(_plateau);
        }

        [Theory, MemberData(nameof(PlateauServiceTestTheoryData.IsValidSize), MemberType = typeof(PlateauServiceTestTheoryData))]
        public void IsValidSize_Should_Return_As_Expected(Size size, bool expected)
        {
            if (expected)
            {
                _plateauService.IsValidSize(size);
                Assert.True(expected);
            }
            else
            {
                Assert.Throws<Exception>(() => _plateauService.IsValidSize(size));
            }
        }
    }
}
