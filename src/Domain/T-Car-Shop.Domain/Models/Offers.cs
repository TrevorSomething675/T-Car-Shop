namespace T_Car_Shop.Domain.Models
{
	public class OffersEntity : BaseModel
	{
		public bool IsSale { get; set; }
		public bool IsSell { get; set; }
		public bool IsHit { get; set; }

		public Guid CarId { get; set; }
		public Car Car { get; set; }
	}
}