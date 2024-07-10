using T_Car_Shop.Web.Models.Brand;
using T_Car_Shop.Web.Models.Image;
using T_Car_Shop.Web.Models.User;

namespace T_Car_Shop.Web.Models.Car
{
    public class CarRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;

        public List<UserRequest>? Users { get; set; }
        public List<ImageRequest>? Images { get; set; }

        public Guid BrandId { get; set; }
        public BrandRequest? Brand { get; set; }
    }
}
