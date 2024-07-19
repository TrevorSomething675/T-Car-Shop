using System.Text.Json.Serialization;

namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class Image : BaseModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
		public string Base64String { get; set; }

		public Guid CarId { get; set; }
        [JsonIgnore]
        public Car Car { get; set; }
    }
}