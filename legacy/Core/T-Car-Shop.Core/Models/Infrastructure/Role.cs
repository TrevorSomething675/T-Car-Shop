using System.Text.Json.Serialization;

namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; }
    }
}
