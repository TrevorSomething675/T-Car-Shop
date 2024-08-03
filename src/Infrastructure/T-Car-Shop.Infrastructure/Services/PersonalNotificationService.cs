using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Services
{
	public class PersonalNotificationService : IPersonalNotificationService
	{
		private readonly IMapper _mapper;
		private readonly IPersonalNotificationRepository _personalNotificationRepository;
		public PersonalNotificationService(IPersonalNotificationRepository personalNotificationRepository, IMapper mapper)
		{
			_mapper = mapper;
			_personalNotificationRepository = personalNotificationRepository;
		}
		public async Task<PagedData<UserNotification>> GetAllAsync(PersonalNotificationsSpecification specification, CancellationToken cancellationToken = default)
		{
			var notifications = _mapper.Map<PagedData<UserNotification>>(await _personalNotificationRepository.GetAllAsync(specification, cancellationToken));
			return notifications;
		}
		public async Task<UserNotification> UpdateAsync(UserNotification userNotification, CancellationToken cancellationToken = default)
		{
			var notification = _mapper.Map<UserNotification>(await _personalNotificationRepository.UpdateAsync(_mapper.Map<UserNotificationEntity>(userNotification), cancellationToken));
			return notification;
		}
	}
}