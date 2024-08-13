using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Application.Services;
using AutoMapper;
using T_Car_Shop.Core.Models.Web.Auth;

namespace T_Car_Shop.Infrastructure.Services
{
    public class UserService : IUserService
	{
		private readonly IMapper _mapper;
		private readonly ITokenService _tokenService;
		private readonly IUserRepository _userRepository;
		private readonly IRoleRepository _rolesRepository;
		public UserService(IUserRepository userRepository, IRoleRepository rolesRepository, 
			IMapper mapper, ITokenService tokenService)
		{
			_rolesRepository = rolesRepository;
			_userRepository = userRepository;
			_tokenService = tokenService;
			_mapper = mapper;
		}
		public async Task<AuthModel> Login(User user, CancellationToken cancellationToken = default)
		{
			var dbUser = _mapper.Map<User>(await _userRepository.GetByNameAsync(user.Name));
			if (dbUser == null)
				throw new NotFoundException("User not found");

			if (dbUser.Password == user.Password)
			{
				var accessToken = await _tokenService.CreateAccessToken(dbUser.Id, dbUser.Role.Name);
				var refreshToken = await _tokenService.CreateRefreshToken();

				return new AuthModel(accessToken, refreshToken, dbUser);
			}
			throw new Exception("Wrong password");
        }
		public async Task<AuthModel> Register(User user, CancellationToken cancellationToken = default)
		{
			var role = _mapper.Map<Role>(await _rolesRepository.GetRoleByName("User"));
			user.Role = role;
			var userEntity = _mapper.Map<UserEntity>(user);
			var createdUser = _mapper.Map<User>(await _userRepository.CreateAsync(userEntity, cancellationToken));

			var accessToken = await _tokenService.CreateAccessToken(createdUser.Id, user.Role.Name);
			var refreshToken = await _tokenService.CreateRefreshToken();

			return new AuthModel(accessToken, refreshToken, createdUser);
		}
	}
}