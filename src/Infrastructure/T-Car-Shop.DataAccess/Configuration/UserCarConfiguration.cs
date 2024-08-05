using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.Core.Models.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Configuration
{
	public class UserCarConfiguration : IEntityTypeConfiguration<UserCarEntity>
	{
		public void Configure(EntityTypeBuilder<UserCarEntity> builder)
		{
			builder.HasOne(uc => uc.User)
				.WithMany(u => u.UserCar)
				.HasForeignKey(un => un.UserId);

			builder.HasOne(uc => uc.Car)
				.WithMany(c => c.UserCar)
				.HasForeignKey(un => un.CarId);
		}
	}
}