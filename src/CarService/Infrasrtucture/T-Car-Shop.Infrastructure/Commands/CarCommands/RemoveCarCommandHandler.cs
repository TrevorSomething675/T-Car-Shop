using T_Car_Shop.Infrastructure.Abstractions.Services;
using T_Car_Shop.Core.Models.WebModels.Car;
using T_Car_Shop.Core.Models.DomainModels;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;
        public RemoveCarCommandHandler(ICarService carRepository, IMapper mapper)
        {
            _carService = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<CarResponse>> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var carEntity = new Result<Car>();
            try
            {
                carEntity = await _carService.RemoveAsync(request.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                return _mapper.Map<Result<CarResponse>>(carEntity).BadRequest();
            }

            if (carEntity == null)
                return _mapper.Map<Result<CarResponse>>(carEntity).NotFound();

            return _mapper.Map<Result<CarResponse>>(carEntity);
        }
    }
}