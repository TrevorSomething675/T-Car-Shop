using T_Car_Shop.Core.Models.Presentation.Car;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQuery : IRequest<Result<PagedData<CarResponse>>>;
}