using T_Car_Shop.Domain.Enums;

namespace T_Car_Shop.Infrastructure.Entities
{
    public class CarEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;
        public decimal Price { get; set; }
		public decimal OldPrice { get; set; }
		public CurrencyType CurrencyType { get; set; }

        public List<ImageEntity> Images { get; set; } = new List<ImageEntity>();
        public List<ColorEntity> Colors { get; set; } = new List<ColorEntity>();

		public List<UserCarEntity>? UserCar { get; set; }

		public DescriptionEntity Description { get; set; }

        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; } = null!;

        public OffersEntity Offers { get; set; }
    }
}