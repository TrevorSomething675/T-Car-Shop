using T_Car_Shop.Application.Repositories;
using T_Car_Shop.DataAccess.Repositories;
using T_Car_Shop.Infrastructure.Services;
using T_Car_Shop.Application.Services;
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
            services.AddScoped<ICarService, CarService>();

            /*
            using (var context = services.BuildServiceProvider().GetRequiredService<MainContext>())
            {
                if (context.Cars.ToList().Count == 0)
                {
                    var cars = new List<CarEntity>
                    {
                        new CarEntity{
                            Name = "test-name-1",
                            Brand = new BrandEntity
                            {
                                Name = "test-brand-1",
                                Manufacturer = new ManufacturerEntity
                                {
                                    Name = "test-manufacturer-1"
                                }
                            }
                        },
                        new CarEntity{
                            Name = "test-name-2",
                            Brand = new BrandEntity
                            {
                                Name = "test-brand-2",
                                Manufacturer = new ManufacturerEntity
                                {
                                    Name = "test-manufacturer-2"
                                }
                            }
                        },
                        new CarEntity{
                            Name = "test-name-3",
                            Brand = new BrandEntity
                            {
                                Name = "test-brand-3",
                                Manufacturer = new ManufacturerEntity
                                {
                                    Name = "test-manufacturer-3"
                                }
                            }
                        }
                    };

                    context.Cars.AddRange(cars);
                    context.SaveChanges();
                }
            }
            */

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