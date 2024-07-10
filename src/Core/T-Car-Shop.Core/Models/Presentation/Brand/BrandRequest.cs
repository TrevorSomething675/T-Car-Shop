using T_Car_Shop.Core.Models.Presentation.Manufacturer;
using T_Car_Shop.Core.Models.Presentation.Car;

namespace T_Car_Shop.Core.Models.Presentation.Brand
{
    public class BrandRequest
    {
        public string? Name { get; set; }

        public Guid ManufacturerId { get; set; }
        public ManufacturerRequest? Manufacturer { get; set; }

        public List<CarRequest>? Cars { get; set; }
    }
}