using System.ComponentModel.DataAnnotations;

namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class BaseModel
    {
		[Required]
		public Guid Id { get; set; }
    }
}
