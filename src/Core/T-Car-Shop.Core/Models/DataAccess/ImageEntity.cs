namespace T_Car_Shop.Core.Models.DataAccess
{
    public class ImageEntity : BaseEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
		public string Base64String { get; set; }

		public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}
