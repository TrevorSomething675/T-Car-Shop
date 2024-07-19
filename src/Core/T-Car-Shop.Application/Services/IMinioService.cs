using T_Car_Shop.Core.Models.Infrastructure;

namespace T_Car_Shop.Application.Services
{
	public interface IMinioService
	{
		Task<string> GetObjectAsync(string path);
	}
}