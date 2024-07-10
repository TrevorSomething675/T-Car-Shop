namespace T_Car_Shop.Infrastructure.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}