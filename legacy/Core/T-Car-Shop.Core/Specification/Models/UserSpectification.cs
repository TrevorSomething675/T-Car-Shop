using T_Car_Shop.Core.Models.DataAccess;
using System.Linq.Expressions;

namespace T_Car_Shop.Core.Specification.Models
{
	public class UserSpectification : BaseSpecification<UserEntity>
	{
		public UserSpectification Include(List<string> includes)
		{
			AddIncludes(includes);
			return this;
		}

		public UserSpectification Where(Expression<Func<UserEntity, bool>> filter)
		{
			AddFilter(filter);
			return this;
		}
		public UserSpectification OrderBy(string sortFiled)
		{
			AddOrderBy(sortFiled);
			return this;
		}
	}
}