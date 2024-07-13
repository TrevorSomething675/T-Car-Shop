using T_Car_Shop.Core.Models.Presentation.Car;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.CarCommands
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand, Result<CarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public RemoveCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public async Task<Result<CarResponse>> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var car = await _carRepository.RemoveAsync(request.Id, cancellationToken);

                if (car != null)
                    return new Result<CarResponse>(_mapper.Map<CarResponse>(car)).Success();
                else
                    return new Result<CarResponse>().NotFound();
            }
            catch (Exception ex)
            {
                return new Result<CarResponse>().BadRequest(ex.Message);
            }
        }
    }
}