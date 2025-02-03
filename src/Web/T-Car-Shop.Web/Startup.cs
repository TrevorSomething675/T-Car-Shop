using T_Car_Shop.Domain.Abstractions.Repositories;
using T_Car_Shop.Domain.Abstractions.Services;
using T_Car_Shop.Infrastructure.Repositories;
using T_Car_Shop.Infrastructure.Services;
using T_Car_Shop.Web.Configurations;
using T_Car_Shop.Infrastructure;
using System.Reflection;
using T_Car_Shop.Application;

namespace T_Car_Shop.Web
{
	public class Startup
	{
		public async void ConfigureServices(IServiceCollection services)
		{
			services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(AssemblyMarker))));
			services.AddAppOptions();
			services.AddControllers();
			services.AddScoped<ICarService, CarService>();
			services.AddScoped<ICarRepository, CarRepository>();
			services.AddDbContextFactory<MainContext>();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(builder =>
			{
				builder.WithOrigins("http://localhost:3000")
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
			});
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Car}/{action=Get}");
			});
		}
	}
}
