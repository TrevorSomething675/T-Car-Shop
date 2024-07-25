using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarByIdQuery(GetCarFilterModel filter) : IRequest<Result<Car>>
    {
        public GetCarFilterModel Filter { get; set; } = filter;
    }
}