using System.Threading.Tasks;
using CityMap.Services.Models;

namespace CityMap.Services.Interfaces
{
	public interface IWebApiClient
	{
		Task<ResponseData<T>> GetDataAsync<T>(string url);
		Task<byte[]> GetDataAsByteArrayAsync(string url);
	}
}
