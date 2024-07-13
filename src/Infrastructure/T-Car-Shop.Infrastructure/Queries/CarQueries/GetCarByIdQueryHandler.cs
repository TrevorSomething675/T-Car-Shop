using T_Car_Shop.Core.Models.Presentation.Car;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Result<CarResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper) 
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<CarResponse>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var car = await _carRepository.GetByIdAsync(request.Id);
                if (car != null)
                    return _mapper.Map<Result<CarResponse>>(car);
                else
                    return new Result<CarResponse>().NotFound();
            }
            catch (Exception ex)
            {
                return new Result<CarResponse>().BadRequest(ex.Message);
            }
        }
    }
}