using T_Car_Shop.Web.Models.Manufacturer;
using T_Car_Shop.Web.Models.Car;

namespace T_Car_Shop.Web.Models.Brand
{
    public class BrandRequest
    {
        public string? Name { get; set; }

        public Guid ManufacturerId { get; set; }
        public ManufacturerRequest? Manufacturer { get; set; }

        public List<CarRequest>? Cars { get; set; }
    }
}