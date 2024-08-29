using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.UserQueries
{
	public class GetUserQuery(Guid id) : IRequest<Result<User>>
	{
		public Guid Id { get; set; } = id;
	}
}