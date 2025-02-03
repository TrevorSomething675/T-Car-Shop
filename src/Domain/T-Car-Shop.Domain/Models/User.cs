namespace T_Car_Shop.Domain.Models
{
    public class User : BaseModel
	{
		public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
        public List<UserCar>? UserCar { get; set; }

        public List<UserNotification> UserNotification { get; set; } = null!;
    }
}