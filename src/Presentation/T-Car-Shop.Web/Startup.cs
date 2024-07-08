using T_Car_Shop.Application.Repositories;
using T_Car_Shop.DataAccess.Repositories;
using T_Car_Shop.Infrastructure;
using T_Car_Shop.Web.Extensions;
using System.Reflection;

namespace T_Car_Shop.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppOptions();
            services.AddAppDbContext();
            services.AddAppAutoMapper();

            services.AddScoped<ICarRepository, CarRepository>();

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(AssemblyMarker))));
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
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