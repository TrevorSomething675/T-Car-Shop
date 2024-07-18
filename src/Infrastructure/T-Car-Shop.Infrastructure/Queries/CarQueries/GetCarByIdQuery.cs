using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarByIdQuery(Guid id) : IRequest<Result<Car>>
    {
        public Guid Id { get; set; } = id;
    }
}