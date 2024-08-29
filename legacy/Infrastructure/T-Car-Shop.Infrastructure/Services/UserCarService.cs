using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Application.Services;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Services
{
	public class UserCarService : IUserCarService
	{
		private readonly IMapper _mapper;
		private readonly IUserCarRepository _userCarRepository;
		public UserCarService(IUserCarRepository userCarRepository, IMapper mapper)
		{
			_userCarRepository = userCarRepository;
			_mapper = mapper;
		}

		public async Task<UserCar> CreateAsync(UserCar userCar, CancellationToken cancellationToken = default)
		{
			var createdCar = await _userCarRepository.CreateAsync(_mapper.Map<UserCarEntity>(userCar), cancellationToken);
			return _mapper.Map<UserCar>(createdCar);
		}

		public async Task<UserCar> DeleteAsync(UserCar userCar, CancellationToken cancellationToken = default)
		{
			var deletedCar = await _userCarRepository.DeleteAsync(_mapper.Map<UserCarEntity>(userCar), cancellationToken);
			return _mapper.Map<UserCar>(deletedCar);
		}

		public async Task<UserCar> UpdateAsync(UserCar userCar, CancellationToken cancellationToken = default)
		{
			var car = await _userCarRepository.UpdateAsync(_mapper.Map<UserCarEntity>(userCar), cancellationToken);
			throw new NotImplementedException();
		}
	}
}