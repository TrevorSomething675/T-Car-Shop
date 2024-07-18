using System.Reflection;
using AutoMapper;

namespace T_Car_Shop.Web.Extensions
{
    public static class ServiceCollectionAutoMapperExtension
    {
        public static void AddAppAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddMaps(Assembly.GetAssembly(typeof(Core.AssemblyMarker)));
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}