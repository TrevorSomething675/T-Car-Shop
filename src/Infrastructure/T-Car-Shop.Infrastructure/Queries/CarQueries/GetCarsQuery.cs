using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQuery(GetCarsFilterModel filter) : IRequest<Result<PagedData<Car>>>
    {
        public GetCarsFilterModel Filter { get; set; } = filter;
    }
}