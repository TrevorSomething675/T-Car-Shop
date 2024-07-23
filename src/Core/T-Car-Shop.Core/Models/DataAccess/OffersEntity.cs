namespace T_Car_Shop.Core.Models.DataAccess
{
	public class OffersEntity : BaseEntity
	{
		public bool IsSale { get; set; }
		public bool IsSell { get; set; }

		public Guid CarId { get; set; }
		public CarEntity Car { get; set; }
	}
}