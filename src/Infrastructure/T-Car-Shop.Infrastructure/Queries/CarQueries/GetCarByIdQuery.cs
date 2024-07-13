using T_Car_Shop.Core.Models.Presentation.Car;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarByIdQuery(Guid id) : IRequest<Result<CarResponse>>
    {
        public Guid Id { get; set; } = id;
    }
}