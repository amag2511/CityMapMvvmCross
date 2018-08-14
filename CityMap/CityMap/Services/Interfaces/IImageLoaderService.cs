using System.Collections.Generic;
using System.Threading.Tasks;
using CityMap.Models;

namespace CityMap.Services.Interfaces
{
	public interface IImageLoaderService
	{
		Task WriteFilesAsync(IEnumerable<CityModel> cityModels);
	}
}