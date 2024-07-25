using T_Car_Shop.Core.Models.DataAccess;
using System.Linq.Expressions;

namespace T_Car_Shop.Core.Specification.Models
{
	public class CarSpecification : BaseSpecification<CarEntity>
	{
		public CarSpecification Include(List<string> includes)
		{
			AddIncludes(includes);
			return this;
		}

		public CarSpecification Where(Expression<Func<CarEntity, bool>> filter, bool condition = false)
		{
			if (condition)
				AddFilter(filter);

			return this;
		}

		public CarSpecification OrderBy(string sortFiled)
		{
			AddOrderBy(sortFiled);
			return this;
		}
	}
}