using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.DataAccess.Entities;

namespace T_Car_Shop.DataAccess.Configuration
{
    public class ManufacturerEntityConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            builder.HasMany(m => m.Brands)
                .WithOne(b => b.Manufacturer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
