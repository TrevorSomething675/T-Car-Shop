using T_Car_Shop.Core.Models.Infrastructure;

namespace T_Car_Shop.Application.Services
{
	public interface IUserCarService
	{
		Task<UserCar> CreateAsync(UserCar userCar, CancellationToken cancellationToken = default);
		Task<UserCar> UpdateAsync(UserCar userCar, CancellationToken cancellationToken = default);
		Task<UserCar> DeleteAsync(UserCar userCar, CancellationToken cancellationToken = default);
	}
}