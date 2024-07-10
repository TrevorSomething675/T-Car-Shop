using T_Car_Shop.Core.Models.Presentation.Brand;
using T_Car_Shop.Core.Models.Presentation.Image;
using T_Car_Shop.Core.Models.Presentation.User;

namespace T_Car_Shop.Core.Models.Presentation.Car
{
    public class CarResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;

        public List<UserResponse>? Users { get; set; }
        public List<ImageResponse>? Images { get; set; }

        public Guid BrandId { get; set; }
        public BrandResponse? Brand { get; set; }
    }
}
