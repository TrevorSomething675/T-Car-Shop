using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Application.Services;
using AutoMapper;
using T_Car_Shop.Core.Models.Auth;
using T_Car_Shop.Core.Exceptions.DomainExceptions;

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
		public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
		{
			var createdUser = await _userRepository.CreateAsync(_mapper.Map<UserEntity>(user), cancellationToken);
			return _mapper.Map<User>(createdUser);
		}

		public async Task<JwtTokensModel> Login(User user, CancellationToken cancellationToken = default)
		{
			var dbUser = await _userRepository.GetByNameAsync(user.Name);
			if (dbUser == null)
				throw new NotFoundException("User not found");

			if(dbUser.Password == user.Password)
			{
				var accessToken = await _tokenService.CreateAccessToken(dbUser.Id, dbUser.Role.Name);
				var refreshToken = await _tokenService.CreateRefreshToken();

				return new JwtTokensModel(accessToken, refreshToken);
			}
			throw new Exception("Wrong password");
        }

		public async Task<JwtTokensModel> Register(User user, CancellationToken cancellationToken = default)
		{
			var role = _mapper.Map<Role>(await _rolesRepository.GetRoleByName("User"));
			user.Role = role;
			var userEntity = _mapper.Map<UserEntity>(user);
			var createdUser = await _userRepository.CreateAsync(userEntity, cancellationToken);

			var accessToken = await _tokenService.CreateAccessToken(createdUser.Id, user.Role.Name);
			var refreshToken = await _tokenService.CreateRefreshToken();

			return new JwtTokensModel(accessToken, refreshToken);
		}
	}
}