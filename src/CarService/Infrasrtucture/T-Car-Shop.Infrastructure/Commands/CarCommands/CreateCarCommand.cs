using T_Car_Shop.Core.Models.WebModels.Car;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class CreateCarCommand(CarRequest car) : IRequest<Result<CarResponse>>
    {
        public CarRequest Car { get; set; } = car;
    }
}