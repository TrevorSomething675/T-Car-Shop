using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Result<PagedData<Car>>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public GetCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<PagedData<Car>>> Handle(GetCarsQuery request, CancellationToken cancellationToken = default)
        {
            var pagedCars = await _carRepository.GetAll(cancellationToken);
            var cars = _mapper.Map<PagedData<Car>>(pagedCars);

            return new Result<PagedData<Car>>(cars).Ok();
        }
    }
}