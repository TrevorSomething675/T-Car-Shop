namespace T_Car_Shop.Domain.Models
{
    public class Color : BaseModel
	{
        public string Name { get; set; } = string.Empty;

        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
