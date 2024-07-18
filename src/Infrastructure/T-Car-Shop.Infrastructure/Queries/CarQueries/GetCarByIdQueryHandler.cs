using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Result<Car>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper) 
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<Car>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var car = _mapper.Map<Car>(await _carRepository.GetByIdAsync(request.Id));
                if (car != null)
                    return new Result<Car>(car).Success();
                else
                    return new Result<Car>().NotFound();
            }
            catch (Exception ex)
            {
                return new Result<Car>().BadRequest(ex.Message);
            }
        }
    }
}