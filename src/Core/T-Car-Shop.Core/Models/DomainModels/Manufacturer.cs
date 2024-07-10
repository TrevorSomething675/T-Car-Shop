namespace T_Car_Shop.Core.Models.DomainModels
{
    public class Manufacturer : BaseModel
    {
        public string? Name { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}