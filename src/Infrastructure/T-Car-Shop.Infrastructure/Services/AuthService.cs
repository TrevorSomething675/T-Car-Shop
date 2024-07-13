using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper) 
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<Result<TokenResponse>> CreateToken(Guid id, string role, CancellationToken cancellationToken = default)
        {
            var user = _mapper.Map<User>(await _userRepository.GetByIdAsync(id, cancellationToken));
            if(user == null)
                return new Result<TokenResponse>().NotFound();

            var accessToken = await _tokenService.CreateAccessToken(id, user.Role.Name);
            var refreshToken = await _tokenService.CreateRefreshToken();

            return new Result<TokenResponse>(new TokenResponse(accessToken, refreshToken)).Success();
        }
    }
}