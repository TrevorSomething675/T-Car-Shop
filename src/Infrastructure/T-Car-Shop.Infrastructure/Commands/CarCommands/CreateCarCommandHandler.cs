using T_Car_Shop.Core.Models.Presentation.Car;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Result<CarResponse>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var createdCar = await _carRepository.CreateAsync(_mapper.Map<Car>(request.Car));
                return _mapper.Map<Result<CarResponse>>(createdCar);
            }
            catch (Exception ex)
            {
                return new Result<CarResponse>().BadRequest(ex.Message);
            }
        }
    }
}