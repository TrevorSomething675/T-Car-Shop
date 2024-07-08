namespace T_Car_Shop.Core.DomainModels
{
    public class Car
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;

        public List<User> Users { get; set; }
        public List<Image> Images { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
