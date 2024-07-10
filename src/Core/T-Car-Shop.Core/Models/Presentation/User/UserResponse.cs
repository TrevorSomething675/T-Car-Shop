using T_Car_Shop.Core.Models.Presentation.Car;

namespace T_Car_Shop.Core.Models.Presentation.User
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<CarResponse> Cars { get; set; }
    }
}