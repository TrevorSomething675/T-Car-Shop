using T_Car_Shop.Core.Models.Presentation.Brand;

namespace T_Car_Shop.Core.Models.Presentation.Manufacturer
{
    public class ManufacturerRequest
    {
        public string? Name { get; set; }
        public List<BrandRequest>? Brands { get; set; }
    }
}
