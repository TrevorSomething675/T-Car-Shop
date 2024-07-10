namespace T_Car_Shop.Core.Models.DomainModels
{
    public class Image : BaseModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}