using T_Car_Shop.Core.Models.Presentation.Car;

namespace T_Car_Shop.Core.Models.Presentation.Image
{
    public class ImageRequest
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public CarRequest Car { get; set; }
    }
}