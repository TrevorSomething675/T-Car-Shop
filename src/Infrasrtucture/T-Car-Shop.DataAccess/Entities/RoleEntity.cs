namespace T_Car_Shop.DataAccess.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}