using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Filters;

namespace T_Car_Shop.Core.Specification.Models
{
	public class CarSpecification : BaseSpecification<CarEntity>
	{
		public CarSpecification(GetCarFilterModel filter) 
		{
			AddIncludes(filter.Includes);
			AddOrderBy(filter.SortFiled);
		}
	}
}