using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result<Car>>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public CreateCarCommandHandler(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public async Task<Result<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var createdCar = await _carService.Create(request.Car);

            return createdCar;
        }
    }
}