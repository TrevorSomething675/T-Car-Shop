using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Configuration
{
    public class BrandEntityConfiguration : IEntityTypeConfiguration<BrandEntity>
    {
        public void Configure(EntityTypeBuilder<BrandEntity> builder)
        {
            builder.HasMany(b => b.Cars)
                .WithOne(c => c.Brand)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}