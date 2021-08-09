using MarsRover.Application.Contract.Models;

namespace MarsRover.Application.Contract.ServiceInterfaces
{
    public interface IRoverService
    {
        void ExecuteCommand(Plateau plateau);
    }
}
