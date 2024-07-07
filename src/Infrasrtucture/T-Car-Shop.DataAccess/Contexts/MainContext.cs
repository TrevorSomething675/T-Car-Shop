using T_Car_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using T_Car_Shop.DataAccess.Configuration;
using Microsoft.Extensions.Options;
using T_Car_Shop.Core.OptionModels;

namespace T_Car_Shop.DataAccess.Contexts
{
    public class MainContext : DbContext
    {
        private readonly DataBaseOptions _options;
        public DbSet<CarEntitiy> Cars { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        public MainContext(IOptions<DataBaseOptions> options)
        {
            _options = options.Value;
        }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_options.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarEntityConfiguration());
        }
    }
}