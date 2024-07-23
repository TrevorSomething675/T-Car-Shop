using Microsoft.EntityFrameworkCore.Metadata.Builders;
using T_Car_Shop.Core.Models.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.DataAccess.Configuration
{
	public class ManufacturerImageEntityConfiguration : IEntityTypeConfiguration<ManufacturerImageEntity>
	{
		public void Configure(EntityTypeBuilder<ManufacturerImageEntity> builder)
		{
			builder.Property(i => i.Base64String)
				.IsRequired(false);
		}
	}
}