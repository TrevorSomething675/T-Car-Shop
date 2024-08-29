using T_Car_Shop.Core.Models.Web.UserCar;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.UserCarCommands
{
	public class DeleteUserCarCommand(UserCarRequest user) : IRequest<Result<UserCarResponse>>
	{
		public UserCarRequest User { get; set; } = user;
	}
}