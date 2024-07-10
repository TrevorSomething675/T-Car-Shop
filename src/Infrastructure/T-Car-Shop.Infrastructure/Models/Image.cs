namespace T_Car_Shop.Infrastructure.Models
{
    public class Image : BaseModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}