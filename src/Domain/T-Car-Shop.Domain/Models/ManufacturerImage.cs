namespace T_Car_Shop.Domain.Models
{
	public class ManufacturerImage : BaseImage
	{
		public Guid ManufacturerId { get; set; }
		public Manufacturer Manufacturer { get; set; }
	}
}