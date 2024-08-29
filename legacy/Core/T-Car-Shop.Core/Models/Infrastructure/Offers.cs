using System.Text.Json.Serialization;

namespace T_Car_Shop.Core.Models.Infrastructure
{
	public class Offers
	{
		public bool IsSale { get; set; } = false;
		public bool IsSell { get; set; } = false;
		public bool IsHit { get; set; } = false;
		public Guid CarId { get; set; }
		[JsonIgnore]
		public Car Car { get; set; }
	}
}