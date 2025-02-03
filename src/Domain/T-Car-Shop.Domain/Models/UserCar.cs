namespace T_Car_Shop.Domain.Models
{
	public class UserCar
	{
		public Guid UserId { get; set; }
		public User User { get; set; }
		public Guid CarId { get; set; }
		public Car Car { get; set; }
	}
}