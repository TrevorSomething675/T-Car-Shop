namespace T_Car_Shop.Core.DomainModels
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public List<Brand> Brands { get; set; }
    }
}