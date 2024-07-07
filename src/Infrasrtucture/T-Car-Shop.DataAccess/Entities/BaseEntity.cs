using System.ComponentModel.DataAnnotations;

namespace T_Car_Shop.DataAccess.Entities
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}