using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Core.Filters
{
	public class GetManufacturersFilterModel
	{
		public int PageNumber { get; set; } = 1;
		public ImagesFillingType ImagesFillingType { get; set; } = ImagesFillingType.WithAllImages;
	}
}