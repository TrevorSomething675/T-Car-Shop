namespace T_Car_Shop.Infrastructure.Entities
{
	public class UserCarEntity
	{
		public Guid UserId { get; set; }
		public UserEntity User { get; set; }
		public Guid CarId { get; set; }
		public CarEntity Car { get; set; }
	}
}