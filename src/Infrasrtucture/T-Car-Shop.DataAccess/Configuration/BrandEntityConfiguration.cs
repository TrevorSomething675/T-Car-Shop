using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.Core.Entities;

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