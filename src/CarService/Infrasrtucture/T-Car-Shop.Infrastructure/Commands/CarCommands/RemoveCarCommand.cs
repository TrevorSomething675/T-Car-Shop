using T_Car_Shop.Core.Models.WebModels.Car;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class RemoveCarCommand(Guid id) : IRequest<Result<CarResponse>>
    {
        public Guid Id { get; set; } = id;
    }
}