using System.ComponentModel.DataAnnotations;

namespace T_Car_Shop.Domain.Models
{
	public class BaseModel
	{
		[Required]
		public Guid Id { get; set; } = Guid.NewGuid();
	}
}