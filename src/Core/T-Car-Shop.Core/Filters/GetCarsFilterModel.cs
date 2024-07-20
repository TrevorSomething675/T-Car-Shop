using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Core.Filters
{
	public class GetCarsFilterModel
	{
		public ImagesFillingType ImagesFillingType { get; set; } = ImagesFillingType.WithFirstImage;
	}
}