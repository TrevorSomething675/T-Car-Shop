using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.UserQueries
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<User>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}
		public async Task<Result<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.Id);
			return new Result<User>(_mapper.Map<User>(user));
		}
	}
}