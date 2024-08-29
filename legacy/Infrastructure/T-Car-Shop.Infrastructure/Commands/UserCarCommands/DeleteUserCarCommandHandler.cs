using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.UserCar;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.UserCarCommands
{
	public class DeleteUserCarCommandHandler : IRequestHandler<DeleteUserCarCommand, Result<UserCarResponse>>
	{
		private readonly IUserCarService _userCarService;
		private readonly IMapper _mapper;
		public DeleteUserCarCommandHandler(IUserCarService userCarService, IMapper mapper)
		{
			_userCarService = userCarService;
			_mapper = mapper;
		}
		public async Task<Result<UserCarResponse>> Handle(DeleteUserCarCommand request, CancellationToken cancellationToken)
		{
			var userCar = _mapper.Map<UserCar>(request.User);

			var deletedUserCar = _mapper.Map<UserCarResponse>(await _userCarService.DeleteAsync(userCar, cancellationToken));

			return new Result<UserCarResponse>(deletedUserCar).Success();
		}
	}
}