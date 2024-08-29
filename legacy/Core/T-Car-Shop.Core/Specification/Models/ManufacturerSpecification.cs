using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Core.Specification.Models
{
	public class ManufacturerSpecification : BaseSpecification<ManufacturerEntity>
	{
		public ImagesFillingType ImagesFillingType = ImagesFillingType.WithFirstImage;
		public ManufacturerSpecification(GetManufacturersFilterModel filter)
		{
			ImagesFillingType = filter.ImagesFillingType;
			PageNumber = filter.PageNumber;
			AddIncludes(filter.Includes);
			AddOrderBy(filter.SortField);
		}
	}
}