using T_Car_Shop.Web.Models.Brand;

namespace T_Car_Shop.Web.Models.Manufacturer
{
    public class ManufacturerRequest
    {
        public string? Name { get; set; }
        public List<BrandRequest>? Brands { get; set; }
    }
}
