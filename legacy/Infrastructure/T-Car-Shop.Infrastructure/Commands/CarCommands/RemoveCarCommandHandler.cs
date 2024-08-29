using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand, Result<Car>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public RemoveCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<Car>> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var car = _mapper.Map<Car>(await _carRepository.RemoveAsync(request.Id, cancellationToken));

                if (car != null)
                    return new Result<Car>(car).Success();
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