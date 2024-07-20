using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Result<PagedData<Car>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;
        public GetCarsQueryHandler(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }
        public async Task<Result<PagedData<Car>>> Handle(GetCarsQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
                var cars = await _carService.GetAllAsync(request.Filter, cancellationToken);
                return new Result<PagedData<Car>>(cars);
            }
            catch (Exception ex)
            {
                return new Result<PagedData<Car>>().BadRequest(ex.Message);
            }
        }
    }
}