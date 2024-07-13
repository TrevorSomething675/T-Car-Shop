using T_Car_Shop.Core.Models.Presentation.Role;
using T_Car_Shop.Core.Models.Presentation.Car;

namespace T_Car_Shop.Core.Models.Presentation.User
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public RoleRequest Role { get; set; }
        public List<CarRequest> Cars { get; set; }
    }
}