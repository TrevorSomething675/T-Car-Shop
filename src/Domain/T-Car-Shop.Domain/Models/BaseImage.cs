namespace T_Car_Shop.Domain.Models
{
	public class BaseImage: BaseModel
	{
		public string Path { get; set; }
		public string Name { get; set; }
		public string Base64String { get; set; }
	}
}