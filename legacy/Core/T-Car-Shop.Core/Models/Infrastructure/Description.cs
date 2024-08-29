namespace T_Car_Shop.Core.Models.Infrastructure
{
	public class Description
	{
		public Guid Id { get; set; }
		public string LongDescription { get; set; } = string.Empty;
		public string Color { get; set; } = string.Empty;

		public Guid CarId { get; set; }
		public Car Car { get; set; }
	}
}