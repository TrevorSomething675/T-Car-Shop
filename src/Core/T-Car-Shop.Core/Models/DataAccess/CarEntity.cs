using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.Core.Models.DataAccess
{
    public class CarEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;
        public decimal Price { get; set; }
		public decimal OldPrice { get; set; }
		public CurrencyType CurrencyType { get; set; }

        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
        public List<ImageEntity> Images { get; set; } = new List<ImageEntity>();
        public List<ColorEntity> Colors { get; set; } = new List<ColorEntity>();

        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; } = null!;
    }
}