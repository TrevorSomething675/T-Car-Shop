using T_Car_Shop.Web.Models.Car;

namespace T_Car_Shop.Web.Models.User
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<CarRequest> Cars { get; set; }
    }
}
