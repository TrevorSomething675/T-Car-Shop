using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.NotificationQueries
{
	public class NotificationQueryHandler : IRequestHandler<NotificationQuery, Result<PagedData<Notification>>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationRepository _notificationRepository;
		public NotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper) 
		{
			_mapper = mapper;
			_notificationRepository = notificationRepository;
		}
		public async Task<Result<PagedData<Notification>>> Handle(NotificationQuery request, CancellationToken cancellationToken)
		{
			var specification = new NotificationsSpecification(request.Filter);
			var notifications = _mapper.Map<PagedData<Notification>>(await _notificationRepository.GetNotifications(specification, cancellationToken));

			return new Result<PagedData<Notification>>(notifications).Success();
		}
	}
}