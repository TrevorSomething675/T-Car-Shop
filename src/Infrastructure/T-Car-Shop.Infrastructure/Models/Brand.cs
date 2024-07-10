namespace T_Car_Shop.Infrastructure.Models
{
    public class Brand : BaseModel
    {
        public string? Name { get; set; }

        public Guid ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public List<Car>? Cars { get; set; }
    }
}
