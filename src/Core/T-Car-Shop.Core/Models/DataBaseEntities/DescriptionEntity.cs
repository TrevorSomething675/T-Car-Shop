namespace T_Car_Shop.DataAccess.Entities
{
    public class DescriptionEntity : BaseEntity
    {
        public string LongDescription { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}