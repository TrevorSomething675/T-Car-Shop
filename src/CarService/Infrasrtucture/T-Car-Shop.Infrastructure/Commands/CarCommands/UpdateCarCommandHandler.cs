using T_Car_Shop.Infrastructure.Abstractions.Services;
using T_Car_Shop.Core.Models.WebModels.Car;
using T_Car_Shop.Core.Models.DomainModels;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;
        public UpdateCarCommandHandler(ICarService carService, IMapper mapper)
        {
            _mapper = mapper;
            _carService = carService;
        }
        public async Task<Result<CarResponse>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var updatedCar = await _carService.UpdateAsync(_mapper.Map<Car>(request.Car), cancellationToken);
            return _mapper.Map<Result<CarResponse>>(updatedCar).Ok();
        }
    }
}