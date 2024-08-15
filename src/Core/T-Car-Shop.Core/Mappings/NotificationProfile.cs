using T_Car_Shop.Core.Models.Web.Notification;
using T_Car_Shop.Core.Models.Infrastructure;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Core.Shared;
using AutoMapper;

namespace T_Car_Shop.Core.Mappings
{
	public class NotificationProfile : Profile
	{
		public NotificationProfile() 
		{
			CreateMap<NotificationRequest, Notification>();
			CreateMap<Notification,  NotificationEntity>().ReverseMap();
			CreateMap<PagedData<Notification>, PagedData<NotificationEntity>>().ReverseMap();

			CreateMap<UserNotification, UserNotificationEntity>().ReverseMap();
			CreateMap<PagedData<UserNotification>, PagedData<UserNotificationEntity>>().ReverseMap();
		}
	}
}