namespace T_Car_Shop.Core.Models.DataAccess
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<CarEntity>? Cars { get; set; }
    }
}