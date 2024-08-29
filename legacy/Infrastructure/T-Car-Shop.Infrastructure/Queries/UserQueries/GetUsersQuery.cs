using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Shared;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.UserQueries
{
    public class GetUsersQuery : IRequest<Result<PagedData<User>>>;
}