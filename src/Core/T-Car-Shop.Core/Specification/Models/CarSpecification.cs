using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Filters;
using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Core.Specification.Models
{
	public class CarSpecification : BaseSpecification<CarEntity>
	{
		public Guid UserId { get; set; }
		public ImagesFillingType ImagesFillingType { get; set; } = ImagesFillingType.WithFirstImage;
		public CarSpecification(GetCarsFilterModel filter) 
		{
			UserId = filter.UserId;
			PageNumber = filter.PageNumber;
			ImagesFillingType = filter.ImagesFillingType;
			AddFilter(c => c.Offers.IsHit, filter.SampleType == SampleType.Hit);
			AddFilter(c => c.Offers.IsSale, filter.SampleType == SampleType.Sale);
			AddFilter(c => c.UserCar.Select(u => u.UserId).Contains(filter.UserId), filter.SampleType == SampleType.Favorite);
			AddIncludes(filter.Includes);
			AddOrderBy(filter.SortField);
		}
		public CarSpecification(GetCarFilterModel filter)
		{
			AddFilter(c => c.Id == filter.Id);
			AddIncludes(filter.Includes);
			AddOrderBy(filter.SortField);
		}
	}
}