namespace T_Car_Shop.Application.Services
{
	public interface IMinioService
	{
		Task<string> GetObjectAsync(string path, CancellationToken cancellationToken = default);
	}
}