using T_Car_Shop.Core.Enums;

namespace T_Car_Shop.DataAccess.Entities
{
    public class CarEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;
        public decimal Price { get; set; }
        public CurrencyType CurrencyType { get; set; }

        public List<UserEntity> Users { get; set; } = new List<UserEntity>();
        public List<ImageEntity> Images { get; set; } = new List<ImageEntity>();
        public List<ColorEntity> Colors { get; set; } = new List<ColorEntity>();

        public Guid BrandId { get; set; }
        public BrandEntity Brand { get; set; } = null!;
    }
}