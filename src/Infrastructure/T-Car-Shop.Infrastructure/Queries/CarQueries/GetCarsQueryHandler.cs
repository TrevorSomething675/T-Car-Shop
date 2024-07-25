using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using MediatR;
using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Result<PagedData<Car>>>
    {
        private readonly ICarService _carService;
        public GetCarsQueryHandler(ICarService carService)
        {
            _carService = carService;
        }
        public async Task<Result<PagedData<Car>>> Handle(GetCarsQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
                var specification = new CarSpecification()
                    .Where(c => c.Offers.IsHit, request.Filter.SampleType == SampleType.Hit)
                    .Where(c => c.Offers.IsSale, request.Filter.SampleType == SampleType.Sale)
                    .Include(request.Filter.Includes)
                    .OrderBy(request.Filter.SortFiled);

				var cars = await _carService.GetAllAsync(specification, request.Filter, cancellationToken);
                return new Result<PagedData<Car>>(cars).Success();
            }
            catch (Exception ex)
            {
                return new Result<PagedData<Car>>().BadRequest(ex.Message);
            }
        }
    }
}