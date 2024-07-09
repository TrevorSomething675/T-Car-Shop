namespace T_Car_Shop.DataAccess.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<CarEntity>? Cars { get; set; }
    }
}