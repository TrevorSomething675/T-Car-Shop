﻿namespace T_Car_Shop.Core.Models.Web.UserCar
{
	public class UserCarRequest
	{
		public Guid? Id { get; set; }
		public Guid? UserId { get; set; }
		public Guid? CarId { get; set; }
	}
}