using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Filters;

namespace T_Car_Shop.Core.Specification.Models
{
	public class CarsSpecification : BaseSpecification<CarEntity>
	{
		public CarsSpecification(GetCarsFilterModel filter) 
		{
			AddFilter(c => c.Offers.IsHit, filter.SampleType == Enums.SampleType.Hit);
			AddFilter(c => c.Offers.IsSale, filter.SampleType == Enums.SampleType.Sale);
			AddIncludes(filter.Includes);
			AddOrderBy(filter.SortFiled);
		}
	}
}