using T_Car_Shop.Domain.Enums;

namespace T_Car_Shop.Domain.Models
{
    public class Car : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;
        public decimal Price { get; set; }
		public decimal OldPrice { get; set; }
		public CurrencyType CurrencyType { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();
        public List<Color> Colors { get; set; } = new List<Color>();

		public List<UserCar>? UserCar { get; set; }

		public Description Description { get; set; }

        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;

        public OffersEntity Offers { get; set; }
    }
}