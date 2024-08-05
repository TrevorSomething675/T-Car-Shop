using T_Car_Shop.Core.Models.Web.UserCar;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.UserCarCommand
{
	public class ChangeFavoriteCarCommandHandler : IRequestHandler<ChangeFavoriteCarCommand, Result<UserCarResponse>>
	{

		public ChangeFavoriteCarCommandHandler()
		{

		}
		public async Task<Result<UserCarResponse>> Handle(ChangeFavoriteCarCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}