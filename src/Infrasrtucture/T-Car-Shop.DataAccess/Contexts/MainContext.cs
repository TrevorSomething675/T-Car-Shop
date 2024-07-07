using T_Car_Shop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using T_Car_Shop.Core.OptionModels;

namespace T_Car_Shop.DataAccess.Contexts
{
    public class MainContext(IOptions<DataBaseOption> option) : DbContext
    {
        DbSet<CarEntitiy> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(option.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}