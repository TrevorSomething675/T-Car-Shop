using T_Car_Shop.Core.Models.Presentation.User;

namespace T_Car_Shop.Core.Models.Presentation.Role
{
    public class RoleRequest
    {
        public string Name { get; set; }
        public List<UserRequest> Users { get; set; }
    }
}