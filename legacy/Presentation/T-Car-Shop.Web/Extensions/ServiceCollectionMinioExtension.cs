using Microsoft.Extensions.Options;
using T_Car_Shop.Core.OptionModels;
using Minio;

namespace T_Car_Shop.Web.Extensions
{
	public static class ServiceCollectionMinioExtension
	{
		public static IServiceCollection AddAppMinio(this IServiceCollection services)
		{
			var minioOptions = services.BuildServiceProvider().GetRequiredService<IOptions<MinioOptions>>().Value;
			services.AddMinio(configureClient => configureClient
				.WithEndpoint(minioOptions.StorageEndPoint)
				.WithCredentials(minioOptions.ROOT_USER, minioOptions.ROOT_PASSWORD)
				.WithSSL(false)
				.Build());

			return services;
		}
	}
}