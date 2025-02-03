namespace T_Car_Shop.Domain.Models
{
    public class Description : BaseModel
	{
        public string LongDescription { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}