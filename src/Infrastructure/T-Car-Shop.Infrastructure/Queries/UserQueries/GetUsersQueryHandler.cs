using T_Car_Shop.Core.Models.Presentation.User;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.UserQueries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<PagedData<UserResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Result<PagedData<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GelAllAsync(cancellationToken);
                return new Result<PagedData<UserResponse>>(_mapper.Map<PagedData<UserResponse>>(users)).Success();
            }
            catch (Exception ex) 
            {
                return new Result<PagedData<UserResponse>>().BadRequest(ex.Message);
            }
        }
    }
}