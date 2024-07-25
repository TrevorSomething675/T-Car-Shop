using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.UserQueries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<PagedData<User>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Result<PagedData<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specification = new UserSpectification();
				var users = _mapper.Map<PagedData<User>>(await _userRepository.GelAllAsync(specification, cancellationToken));
                return new Result<PagedData<User>>(users).Success();
            }
            catch (Exception ex) 
            {
                return new Result<PagedData<User>>().BadRequest(ex.Message);
            }
        }
    }
}