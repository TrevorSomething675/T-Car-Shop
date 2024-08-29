namespace T_Car_Shop.Core.Models.DataAccess
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
