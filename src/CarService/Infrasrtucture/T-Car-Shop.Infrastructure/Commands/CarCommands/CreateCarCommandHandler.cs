using T_Car_Shop.Infrastructure.Abstractions.Services;
using T_Car_Shop.Core.Models.WebModels.Car;
using T_Car_Shop.Core.Models.DomainModels;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public CreateCarCommandHandler(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public async Task<Result<CarResponse>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var createdCar = await _carService.CreateAsync(_mapper.Map<Car>(request.Car));

            return _mapper.Map<Result<CarResponse>>(createdCar);
        }
    }
}