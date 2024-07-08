using T_Car_Shop.DataAccess.Contexts;

namespace T_Car_Shop.Web.Extensions
{
    public static class ServiceCollectionDataBaseExtension
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            services.AddDbContextFactory<MainContext>();
            return services;
        }
    }
}