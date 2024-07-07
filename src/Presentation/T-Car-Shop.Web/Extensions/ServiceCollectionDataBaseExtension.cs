using T_Car_Shop.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using T_Car_Shop.Core.OptionModels;

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