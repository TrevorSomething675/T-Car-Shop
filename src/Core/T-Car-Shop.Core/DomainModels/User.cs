namespace T_Car_Shop.Core.DomainModels
{
    public class User : BaseDomainModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<Car> Cars { get; set; }
    }
}