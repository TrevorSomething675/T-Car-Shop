using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Infrastructure.Services
{
	public class NotificationService : INotificationService
	{
		private readonly IMapper _mapper;
		private readonly INotificationRepository _notificationRepository;
		public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
		{
			_mapper = mapper;
			_notificationRepository = notificationRepository;
		}
		public async Task<PagedData<Notification>> GetNotifications(NotificationsSpecification specification, CancellationToken cancellationToken = default)
		{
			var notifications = await _notificationRepository.GetNotifications(specification, cancellationToken);
			return _mapper.Map<PagedData<Notification>>(notifications);
		}
	}
}