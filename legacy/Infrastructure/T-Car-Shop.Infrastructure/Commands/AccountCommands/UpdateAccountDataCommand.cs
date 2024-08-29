using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.Web.Account;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.AccountCommands
{
	public class UpdateAccountDataCommand(AccountUserRequest accountUserData) : IRequest<Result<User>>
	{
		public AccountUserRequest AccountUserData { get; set; } = accountUserData;
	}
}
