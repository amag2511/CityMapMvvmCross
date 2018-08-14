using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CityMap.Models;

namespace CityMap.Services.Interfaces
{
	public interface ICityApiService
	{
		Task<IEnumerable<CityModel>> GetCitiesAsync(string uri);
	}
}
