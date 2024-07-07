using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using T_Car_Shop.Infrastructure;

namespace T_Car_Shop.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(AssemblyMarker))));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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