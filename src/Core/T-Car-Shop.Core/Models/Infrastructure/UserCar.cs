namespace T_Car_Shop.Core.Models.Infrastructure
{
	public class UserCar : BaseModel
	{
		public Guid UserId { get; set; }
		public Guid CarId { get; set; }
	}
}