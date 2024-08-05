namespace T_Car_Shop.Core.Models.DataAccess
{
	public class UserCarEntity : BaseEntity
	{
		public Guid UserId { get; set; }
		public UserEntity User { get; set; }
		public Guid CarId { get; set; }
		public CarEntity Car { get; set; }
	}
}