namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
        public List<Car>? Cars { get; set; }

        public List<UserNotification> UserNotifications { get; set; }
    }
}