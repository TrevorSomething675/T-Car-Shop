namespace T_Car_Shop.Infrastructure.Entities
{
    public class ColorEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}
