using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Models.Auth;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<JwtTokensModel>>
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		public RegisterCommandHandler(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}
		public async Task<Result<JwtTokensModel>> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var tokens = await _userService.Register(_mapper.Map<User>(request.FormData));
				return new Result<JwtTokensModel>(tokens).Success();
			}
			catch (Exception ex) 
			{
				return new Result<JwtTokensModel>().BadRequest(ex.Message);
			}
		}
	}
}