namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class Manufacturer : BaseModel
    {
        public string? Name { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}