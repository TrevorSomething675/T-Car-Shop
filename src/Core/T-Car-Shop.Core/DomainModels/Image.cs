namespace T_Car_Shop.Core.DomainModels
{
    public class Image : BaseDomainModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}