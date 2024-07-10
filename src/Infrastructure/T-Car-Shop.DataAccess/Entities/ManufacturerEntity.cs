namespace T_Car_Shop.DataAccess.Entities
{
    public class ManufacturerEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<BrandEntity> Brands { get; set; }
    }
}