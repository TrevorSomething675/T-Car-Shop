using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.CarQueries
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Result<Car>>
    {
        private readonly ICarService _carService;
        public GetCarByIdQueryHandler(ICarService carService) 
        {
            _carService = carService;
        }
        public async Task<Result<Car>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var car = await _carService.GetByIdAsync(request.Id);
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