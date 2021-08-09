using MarsRover.Application.Contract.Models;

namespace MarsRover.Application.Contract.ServiceInterfaces
{
    public interface IPlateauService
    {
        void CreatePlateau(Plateau plateau);
        void IsValidSize(Size size);
    }
}
