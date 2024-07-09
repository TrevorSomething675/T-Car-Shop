namespace T_Car_Shop.Core.DomainModels
{
    public class Role : BaseDomainModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}