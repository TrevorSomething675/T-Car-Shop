namespace T_Car_Shop.Infrastructure.Entities
{
	public class BaseImageEntity: BaseEntity
	{
		public string Path { get; set; }
		public string Name { get; set; }
		public string Base64String { get; set; }
	}
}