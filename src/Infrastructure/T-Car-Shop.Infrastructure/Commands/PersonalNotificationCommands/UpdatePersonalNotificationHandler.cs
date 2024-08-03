using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Core.Shared;
using AutoMapper;
using MediatR;

namespace T_Car_Shop.Infrastructure.Commands.PersonalNotificationCommands
{
	public class UpdatePersonalNotificationHandler : IRequestHandler<UpdatePersonalNotification, Result<UserNotification>>
	{
		private readonly IMapper _mapper;
		private readonly IPersonalNotificationService _personalNotificationService;
		public UpdatePersonalNotificationHandler(IPersonalNotificationService personalNotificationService, IMapper mapper)
		{
			_mapper = mapper;
			_personalNotificationService = personalNotificationService;
		}
		public async Task<Result<UserNotification>> Handle(UpdatePersonalNotification request, CancellationToken cancellationToken)
		{
			try
			{
				var user = _mapper.Map<UserNotification>(request.User);
				var updatedNotification = await _personalNotificationService.UpdateAsync(user, cancellationToken);
				return new Result<UserNotification>(updatedNotification);
			}
			catch (Exception ex)
			{
				return new Result<UserNotification>().BadRequest(ex.Message);
			}
		}
	}
}