namespace T_Car_Shop.DataAccess.Entities
{
    public class CarEntitiy : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;

        public List<UserEntity> Users { get; set; }
        public List<ImageEntity> Images { get; set; }

        public Guid BrandId { get; set; }
        public BrandEntity Brand { get; set; }
    }
}