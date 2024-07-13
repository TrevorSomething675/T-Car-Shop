using T_Car_Shop.Core.Models.Presentation.Car;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result<CarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }
        public async Task<Result<CarResponse>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedCar = await _carRepository.UpdateAsync(_mapper.Map<Car>(request.Car), cancellationToken);

                if (updatedCar != null)
                    return new Result<CarResponse>(_mapper.Map<CarResponse>(updatedCar)).Success();
                else
                    return new Result<CarResponse>(_mapper.Map<CarResponse>(updatedCar)).NotFound();
            }
            catch (Exception ex)
            {
                return new Result<CarResponse>().BadRequest(ex.Message);
            }
        }
    }
}