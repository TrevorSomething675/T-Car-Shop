namespace T_Car_Shop.Core.Models.DataAccess
{
    public class ManufacturerEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<BrandEntity> Brands { get; set; }
    }
}