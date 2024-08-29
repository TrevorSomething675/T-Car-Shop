namespace T_Car_Shop.Core.Models.DataAccess
{
    public class ImageEntity : BaseImageEntity
    {
		public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}