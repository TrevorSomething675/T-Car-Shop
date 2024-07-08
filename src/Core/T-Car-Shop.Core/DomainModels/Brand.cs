using T_Car_Shop.Core.Entities;

namespace T_Car_Shop.Core.DomainModels
{
    public class Brand
    {
        public string Name { get; set; }

        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public List<Car> Cars { get; set; }
    }
}
