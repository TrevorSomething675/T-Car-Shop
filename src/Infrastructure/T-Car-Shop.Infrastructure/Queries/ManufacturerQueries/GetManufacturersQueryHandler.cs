using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.ManufacturerQueries
{
	public class GetManufacturersQueryHandler : IRequestHandler<GetManufacturersQuery, Result<PagedData<Manufacturer>>>
	{
		private readonly IMapper _mapper;
		private readonly IManufacturerRepository _manufacturerRepository;
		public GetManufacturersQueryHandler(IManufacturerRepository manufacturerRepository, IMapper mapper)
		{
			_manufacturerRepository = manufacturerRepository;
			_mapper = mapper;
		}

		public async Task<Result<PagedData<Manufacturer>>> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var specification = new ManufacturerSpecification(request.Filter);
				var manufacturers = _mapper.Map<PagedData<Manufacturer>>(await _manufacturerRepository.GetAllAsync(specification, cancellationToken);
				return new Result<PagedData<Manufacturer>>(manufacturers).Success();
			}
			catch (Exception ex)
			{
				return new Result<PagedData<Manufacturer>>().BadRequest(ex.Message);
			}
		}
	}
}