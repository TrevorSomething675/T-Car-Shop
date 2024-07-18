using T_Car_Shop.Application.Repositories;
using T_Car_Shop.DataAccess.Repositories;
using T_Car_Shop.Infrastructure.Services;
using T_Car_Shop.Application.Services;
using T_Car_Shop.Infrastructure;
using T_Car_Shop.Web.Extensions;
using System.Reflection;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.DataAccess.Contexts;

namespace T_Car_Shop.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppOptions();
            services.AddAppDbContext();
            services.AddAppAutoMapper();
            services.AddCors();

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            
            using (var context = services.BuildServiceProvider().GetRequiredService<MainContext>())
            {
                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.Add(new ManufacturerEntity { Name = "BMW" });
                    context.SaveChanges();

                }
                if (!context.Cars.Any())
                {
                    var manufacturer = context.Manufacturers.FirstOrDefault();

                    var cars = new List<CarEntity>
                    {
                        new CarEntity{
                            Name = "BMW 2 серии 2020",
                            Manufacturer = manufacturer
                        },
                        new CarEntity{
                            Name = "BMW 3 серии 2013",
                            Manufacturer = manufacturer
                        },
                        new CarEntity{
                            Name = "BMW 4 серии 2014",
                            Manufacturer = manufacturer
                        }
                    };

                    context.Cars.AddRange(cars);
                    context.SaveChanges();
                }
            }

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(AssemblyMarker))));
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
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
            app.UseAppAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Car}/{action=Get}");
            });
        }
    }
}