namespace T_Car_Shop.Core.Models.DomainModels
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}