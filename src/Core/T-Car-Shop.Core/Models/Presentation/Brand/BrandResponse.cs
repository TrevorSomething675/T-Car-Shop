using T_Car_Shop.Core.Models.Presentation.Manufacturer;
using T_Car_Shop.Core.Models.Presentation.Car;

namespace T_Car_Shop.Core.Models.Presentation.Brand
{
    public class BrandResponse
    {
        public string? Name { get; set; }

        public Guid ManufacturerId { get; set; }
        public ManufacturerResponse? Manufacturer { get; set; }

        public List<CarResponse>? Cars { get; set; }
    }
}