using T_Car_Shop.Infrastructure.Abstractions.Services;
using T_Car_Shop.Core.Models.WebModels.Car;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Result<PagedData<CarResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;
        public GetCarsQueryHandler(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }
        public async Task<Result<PagedData<CarResponse>>> Handle(GetCarsQuery request, CancellationToken cancellationToken = default)
        {
            var pagedCars = await _carService.GetAllAsync(cancellationToken);

            return _mapper.Map<Result<PagedData<CarResponse>>>(pagedCars).Ok();
        }
    }
}