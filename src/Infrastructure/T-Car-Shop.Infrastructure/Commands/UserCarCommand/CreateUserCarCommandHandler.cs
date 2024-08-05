using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.UserCar;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.UserCarCommand
{
	public class CreateUserCarCommandHandler : IRequestHandler<CreateUserCarCommand, Result<UserCarResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IUserCarService _userCarService;
		public CreateUserCarCommandHandler(IUserCarService userCarService, IMapper mapper)
		{
			_mapper = mapper;
			_userCarService = userCarService;
		}
		public async Task<Result<UserCarResponse>> Handle(CreateUserCarCommand request, CancellationToken cancellationToken)
		{
			var userCar = _mapper.Map<UserCar>(request.User);

			var createdUserCar = _mapper.Map<UserCarResponse>(await _userCarService.CreateAsync(userCar, cancellationToken));

			return new Result<UserCarResponse>(createdUserCar);
		}
	}
}