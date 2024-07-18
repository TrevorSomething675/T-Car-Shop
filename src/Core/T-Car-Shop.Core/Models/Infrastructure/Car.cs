namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class Car : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;

        public List<User>? Users { get; set; }
        public List<Image>? Images { get; set; }

        public Guid ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}