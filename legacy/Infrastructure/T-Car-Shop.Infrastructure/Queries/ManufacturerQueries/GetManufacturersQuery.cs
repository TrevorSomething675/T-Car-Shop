using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.ManufacturerQueries
{
	public class GetManufacturersQuery(GetManufacturersFilterModel filter) : IRequest<Result<PagedData<Manufacturer>>>
	{
		public GetManufacturersFilterModel Filter { get; set; } = filter;
	}
}