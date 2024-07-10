using T_Car_Shop.Web.Models.Car;

namespace T_Car_Shop.Web.Models.Image
{
    public class ImageRequest
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public CarRequest Car { get; set; }
    }
}