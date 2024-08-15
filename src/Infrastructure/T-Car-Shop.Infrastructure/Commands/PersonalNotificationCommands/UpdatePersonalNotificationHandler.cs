using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Repositories;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.PersonalNotificationCommands
{
	public class UpdatePersonalNotificationHandler : IRequestHandler<UpdatePersonalNotification, Result<UserNotification>>
	{
		private readonly IMapper _mapper;
		private readonly IPersonalNotificationRepository _personalNotificationRepository;
		public UpdatePersonalNotificationHandler(IPersonalNotificationRepository personalNotificationRepository, IMapper mapper)
		{
			_mapper = mapper;
			_personalNotificationRepository = personalNotificationRepository;
		}
		public async Task<Result<UserNotification>> Handle(UpdatePersonalNotification request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<UserNotificationEntity>(request.User);
			var updatedNotification = _mapper.Map<UserNotification>(await _personalNotificationRepository.UpdateAsync(user, cancellationToken));
			return new Result<UserNotification>(updatedNotification);
		}
	}
}