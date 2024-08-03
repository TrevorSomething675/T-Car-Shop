using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.ManufacturerQueries
{
	public class GetManufacturersQueryHandler : IRequestHandler<GetManufacturersQuery, Result<PagedData<Manufacturer>>>
	{
		private readonly IManufacturerService _manufacturerService;

		public GetManufacturersQueryHandler(IManufacturerService manufacturerService)
		{
			_manufacturerService = manufacturerService;
		}

		public async Task<Result<PagedData<Manufacturer>>> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var specification = new ManufacturerSpecification(request.Filter);
				var manufacturers = await _manufacturerService.GetManufacturersAsync(specification, cancellationToken);
				return new Result<PagedData<Manufacturer>>(manufacturers).Success();
			}
			catch (Exception ex)
			{
				return new Result<PagedData<Manufacturer>>().BadRequest(ex.Message);
			}
		}
	}
}