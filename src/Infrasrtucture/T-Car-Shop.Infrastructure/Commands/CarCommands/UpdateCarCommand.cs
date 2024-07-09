using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class UpdateCarCommand(Car car) : IRequest<Result<Car>>
    {
        public Car Car { get; set; } = car;
    }
}