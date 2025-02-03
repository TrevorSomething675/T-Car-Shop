namespace T_Car_Shop.Infrastructure.Entities
{
	public class ManufacturerImageEntity : BaseImageEntity
	{
		public Guid ManufacturerId { get; set; }
		public ManufacturerEntity Manufacturer { get; set; }
	}
}