using T_Car_Shop.Core.Models.Presentation.Car;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Result<PagedData<CarResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public GetCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<PagedData<CarResponse>>> Handle(GetCarsQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
                var pagedCars = _mapper.Map<Car>(await _carRepository.GetAllAsync(cancellationToken));
                return _mapper.Map<Result<PagedData<CarResponse>>>(pagedCars).Success();
            }
            catch (Exception ex)
            {
                return new Result<PagedData<CarResponse>>().BadRequest(ex.Message);
            }
        }
    }
}