using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.Core.Models.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Configuration
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Users)
                .WithMany(u => u.Cars)
                .UsingEntity(uc => uc.ToTable("CarUser"));

            builder.HasMany(c => c.Images)
                .WithOne(i => i.Car)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(c => c.Manufacturer)
                .WithMany(b => b.Cars)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}