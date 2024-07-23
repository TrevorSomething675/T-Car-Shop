namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class Manufacturer : BaseModel
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string OfficialWebsite { get; set; }

		public List<Car>? Cars { get; set; }
		public List<ManufacturerImage> Images { get; set; }
	}
}