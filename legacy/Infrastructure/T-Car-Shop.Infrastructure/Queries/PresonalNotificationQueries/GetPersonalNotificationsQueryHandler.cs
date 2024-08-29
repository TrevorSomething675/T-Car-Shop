using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Specification.Models;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Queries.PresonalNotificationQueries
{
	public class GetPersonalNotificationsQueryHandler : IRequestHandler<GetPersonalNotificationsQuery, Result<PagedData<UserNotification>>>
	{
		private readonly IPersonalNotificationRepository _personalNotificationRepository;
		private readonly IMapper _mapper;
		public GetPersonalNotificationsQueryHandler(IPersonalNotificationRepository personalNotificationRepository, IMapper mapper)
		{
			_personalNotificationRepository = personalNotificationRepository;
			_mapper = mapper;
		}
		public async Task<Result<PagedData<UserNotification>>> Handle(GetPersonalNotificationsQuery request, CancellationToken cancellationToken)
		{
			var specification = new PersonalNotificationsSpecification(request.Filter);
			var personalNotifications = _mapper.Map<PagedData<UserNotification>>(await _personalNotificationRepository.GetAllAsync(specification, cancellationToken));

			return new Result<PagedData<UserNotification>>(personalNotifications);
		}
	}
}