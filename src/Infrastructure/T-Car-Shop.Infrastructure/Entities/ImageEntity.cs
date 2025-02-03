namespace T_Car_Shop.Infrastructure.Entities
{
    public class ImageEntity : BaseImageEntity
    {
		public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}