namespace T_Car_Shop.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<CarEntitiy> Cars { get; set; }
    }
}