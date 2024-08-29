namespace T_Car_Shop.Core.Models.DataAccess
{
    public class UserEntity : BaseEntity
    {
		public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RoleEntity Role { get; set; }
        public List<UserCarEntity>? UserCar { get; set; }

        public List<UserNotificationEntity> UserNotification { get; set; } = null!;
    }
}