using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Configuration
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<CarEntitiy>
    {
        public void Configure(EntityTypeBuilder<CarEntitiy> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Users)
                .WithMany(u => u.Cars)
                .UsingEntity(uc => uc.ToTable("CarUser"));

            builder.HasMany(c => c.Images)
                .WithOne(i => i.Car)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}