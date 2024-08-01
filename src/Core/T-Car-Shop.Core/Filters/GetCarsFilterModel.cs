using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Core.Filters
{
	public class GetCarsFilterModel : BaseFilter
	{
		public int PageNumber { get; set; } = 1;
		public SampleType SampleType { get; set; } = SampleType.None;
		public ImagesFillingType ImagesFillingType { get; set; } = ImagesFillingType.WithFirstImage;
	}
}