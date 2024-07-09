using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result<Car>>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;
        public UpdateCarCommandHandler(ICarService carService, IMapper mapper)
        {
            _mapper = mapper;
            _carService = carService;
        }
        public async Task<Result<Car>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var updatedCar = await _carService.Update(request.Car);
            return updatedCar.Ok();
        }
    }
}
