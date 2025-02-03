namespace T_Car_Shop.Domain.Models
{
    public class Image : BaseImage
    {
		public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}