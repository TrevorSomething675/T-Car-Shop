using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.Core.Models.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Configuration
{
	public class UserNotificationEntityConfiguration : IEntityTypeConfiguration<UserNotificationEntity>
	{
		public void Configure(EntityTypeBuilder<UserNotificationEntity> builder)
		{
			builder.HasOne(un => un.User)
				.WithMany(u => u.UserNotification)
				.HasForeignKey(un => un.UserId);

			builder.HasOne(un => un.Notification)
				.WithMany(n => n.UserNotification)
				.HasForeignKey(un => un.NotificationId);
		}
	}
}