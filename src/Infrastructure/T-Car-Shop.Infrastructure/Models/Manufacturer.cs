namespace T_Car_Shop.Infrastructure.Models
{
    public class Manufacturer : BaseModel
    {
        public string? Name { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}