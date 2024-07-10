using T_Car_Shop.Core.Models.Presentation.Brand;

namespace T_Car_Shop.Core.Models.Presentation.Manufacturer
{
    public class ManufacturerResponse
    {
        public string? Name { get; set; }
        public List<BrandResponse>? Brands { get; set; }
    }
}