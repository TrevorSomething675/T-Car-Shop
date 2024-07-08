namespace T_Car_Shop.Core.DomainModels
{
    public class Image
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}