namespace T_Car_Shop.Core.Models.DataAccess
{
	public class ManufacturerImageEntity : BaseImageEntity
	{
		public Guid ManufacturerId { get; set; }
		public ManufacturerEntity Manufacturer { get; set; }
	}
}