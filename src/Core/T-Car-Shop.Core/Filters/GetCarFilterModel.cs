using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Core.Filters
{
	public class GetCarFilterModel : BaseFilter 
	{
        public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public ImagesFillingType ImagesFillingType { get; set; }
	}
}