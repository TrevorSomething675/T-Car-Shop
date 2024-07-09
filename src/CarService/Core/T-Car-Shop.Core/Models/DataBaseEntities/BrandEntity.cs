namespace T_Car_Shop.DataAccess.Entities
{
    public class BrandEntity : BaseEntity
    {
        public string Name { get; set; }

        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; }

        public List<CarEntity> Cars { get; set; }
    }
}