namespace T_Car_Shop.Infrastructure.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<Car> Cars { get; set; }
    }
}