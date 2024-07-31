using T_Car_Shop.Core.Exceptions.DomainExceptions;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Models.Auth;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.AuthCommands
{
	public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthModel>>
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		public LoginCommandHandler(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}
		public async Task<Result<AuthModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var user = await _userService.GetByNameAsync(request.FormData.Name);
				var authModel = await _userService.Login(_mapper.Map<User>(request.FormData), cancellationToken);
				return new Result<AuthModel>(authModel).Success();
			}
			catch(NotFoundException ex)
			{
				return new Result<AuthModel>().NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return new Result<AuthModel>().BadRequest(ex.Message);
			}
		}
	}
}