using T_Car_Shop.Application.Services;
using Minio.DataModel.Args;
using Minio;

namespace T_Car_Shop.Infrastructure.Services
{
	public class MinioService : IMinioService
	{
		private readonly IMinioClientFactory _minioClientFactory;
		public MinioService(IMinioClientFactory minioClientFactory)
		{
			_minioClientFactory = minioClientFactory;
		}

		public async Task<string> GetObjectAsync(string path)
		{
			string bucketName = Path.GetDirectoryName(path);
			string objectName = Path.GetFileName(path);
			var objectBytes = Array.Empty<byte>();
			try
			{
				using (var client = _minioClientFactory.CreateClient())
				{
					var args = new GetObjectArgs()
						.WithBucket(bucketName)
						.WithObject(objectName)
						.WithCallbackStream(async (stream) => 
						{
							await using (var ms = new MemoryStream())
							{
								stream.CopyTo(ms);
								objectBytes = ms.ToArray();
							}
						});
					await client.GetObjectAsync(args);
					return Convert.ToBase64String(objectBytes);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}