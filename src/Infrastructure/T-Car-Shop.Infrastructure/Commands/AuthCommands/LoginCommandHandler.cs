using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Models.Auth;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
	public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<JwtTokensModel>>
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		public LoginCommandHandler(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}
		public async Task<Result<JwtTokensModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var tokens = await _userService.Login(_mapper.Map<User>(request.FormData), cancellationToken);
				return new Result<JwtTokensModel>(tokens).Success();
			}
			catch(NotFoundException ex)
			{
				return new Result<JwtTokensModel>().NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return new Result<JwtTokensModel>().BadRequest(ex.Message);
			}
		}
	}
}