using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class RemoveCarCommand(Guid id) : IRequest<Result<Car>>
    {
        public Guid Id { get; set; } = id;
    }
}