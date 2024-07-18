using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.Core.Models.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Configuration
{
    public class ManufacturerEntityConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            builder.HasMany(m => m.Cars)
                .WithOne(b => b.Manufacturer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
