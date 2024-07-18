using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result<Car>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }
        public async Task<Result<Car>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var carToUpdate = _mapper.Map<CarEntity>(request.Car);
                var updatedCar = _mapper.Map<Car>(await _carRepository.UpdateAsync(carToUpdate, cancellationToken));
                if (updatedCar != null)
                    return new Result<Car>(updatedCar).Success();
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