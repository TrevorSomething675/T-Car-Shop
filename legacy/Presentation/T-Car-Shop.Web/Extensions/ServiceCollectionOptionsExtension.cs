using T_Car_Shop.Core.OptionModels;

namespace T_Car_Shop.Web.Extensions
{
    public static class ServiceCollectionOptionsExtension
    {
        public static IServiceCollection AddAppOptions(this IServiceCollection services) 
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<DataBaseOptions>(configuration.GetSection(DataBaseOptions.SectionName));
            services.Configure<JwtAuthOptions>(configuration.GetSection(JwtAuthOptions.SectionName));
            services.Configure<MinioOptions>(configuration.GetSection(MinioOptions.SectionName));

            return services;
        }
    }
}