using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.DomainModels;
using T_Car_Shop.Core.Entities;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand, Result<Car>>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        public RemoveCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<Car>> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var carEntity = new CarEntity();
            try
            {
                carEntity = await _carRepository.Remove(request.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                return _mapper.Map<Result<Car>>(new Result<CarEntity>(carEntity));
            }

            if (carEntity == null)
                return _mapper.Map<Result<Car>>(new Result<CarEntity>(carEntity)).NotFound();

            return _mapper.Map<Result<Car>>(carEntity);
        }
    }
}