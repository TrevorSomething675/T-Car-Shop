using T_Car_Shop.Core.Models.DataAccess;
using System.Text.Json.Serialization;

namespace T_Car_Shop.Core.Models.Infrastructure
{
	public class ManufacturerImage : BaseImageEntity
	{
		public Guid ManufacturerId { get; set; }
		[JsonIgnore]
		public Manufacturer Manufacturer { get; set; }
	}
}