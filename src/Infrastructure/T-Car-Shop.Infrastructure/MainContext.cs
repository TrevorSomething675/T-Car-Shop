using T_Car_Shop.Domain.OptionModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using T_Car_Shop.Domain.Models;

namespace T_Car_Shop.Infrastructure
{
	public class MainContext : DbContext
	{
		private readonly DataBaseOptions _options;

		public DbSet<Car> Cars { get; set; }

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
			modelBuilder.Entity<Car>().HasData(
					new Car { Name = "Tom"},
					new Car { Name = "Bob"},
					new Car { Name = "Sam"}
			);
		}
	}
}