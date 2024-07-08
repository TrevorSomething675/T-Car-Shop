namespace T_Car_Shop.Core.Entities
{
    public class ImageEntity : BaseEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public CarEntitiy Car { get; set; }
    }
}
