using T_Car_Shop.Domain.OptionModels;

namespace T_Car_Shop.Web.Configurations
{
	public static class ServiceCollectionOptionsExtension
	{
		public static IServiceCollection AddAppOptions(this IServiceCollection services)
		{
			var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
			services.Configure<DataBaseOptions>(configuration.GetSection(DataBaseOptions.SectionName));

			return services;
		}
	}
}