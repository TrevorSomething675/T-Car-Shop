using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<Car>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Result<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var carToCreate = _mapper.Map<CarEntity>(request.Car);
                var createdCar = _mapper.Map<Car>(await _carRepository.CreateAsync(carToCreate));
                return new Result<Car>(createdCar).Success();
            }
            catch (Exception ex)
            {
                return new Result<Car>().BadRequest(ex.Message);
            }
        }
    }
}