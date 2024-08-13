using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;
using T_Car_Shop.Core.Models.Web.Auth;
using T_Car_Shop.Application.Repositories;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthModel>>
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		private readonly IUserRepository _userRepository;
		public LoginCommandHandler(IUserRepository userRepository, IUserService userService, IMapper mapper)
		{
			_userRepository = userRepository;
			_userService = userService;
			_mapper = mapper;
		}
		public async Task<Result<AuthModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			var authModel = await _userService.Login(_mapper.Map<User>(request.FormData), cancellationToken);
			return new Result<AuthModel>(authModel).Success();
		}
	}
}