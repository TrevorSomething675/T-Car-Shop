using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
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
            try
            {
                var cars = _mapper.Map<PagedData<Car>>(await _carRepository.GetAllAsync(cancellationToken));
                return new Result<PagedData<Car>>(cars);
            }
            catch (Exception ex)
            {
                return new Result<PagedData<Car>>().BadRequest(ex.Message);
            }
        }
    }
}