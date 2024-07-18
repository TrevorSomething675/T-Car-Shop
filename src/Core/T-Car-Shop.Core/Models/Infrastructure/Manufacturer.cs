namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class Manufacturer : BaseModel
    {
        public string? Name { get; set; }
        public List<Car>? Cars { get; set; }
    }
}