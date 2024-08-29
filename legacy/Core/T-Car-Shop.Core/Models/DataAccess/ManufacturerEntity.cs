namespace T_Car_Shop.Core.Models.DataAccess
{
    public class ManufacturerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficialWebsite { get; set; }

        public List<CarEntity> Cars { get; set; }
        public List<ManufacturerImageEntity> Images { get; set; }
    }
}