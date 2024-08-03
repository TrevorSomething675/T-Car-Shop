using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, Result<Car>>
    {
        private readonly ICarService _carService;
        public GetCarQueryHandler(ICarService carService)
        {
            _carService = carService;
        }
        public async Task<Result<Car>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specification = new CarSpecification(request?.Filter);
                var car = await _carService.GetAsync(specification, cancellationToken);
                
                return new Result<Car>(car).Success();
            }
            catch (NotFoundException ex)
            {
                return new Result<Car>().NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return new Result<Car>().BadRequest(ex.Message);
            }
        }
    }
}