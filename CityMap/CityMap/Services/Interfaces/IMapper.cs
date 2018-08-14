using System;
using System.Collections.Generic;
using System.Text;
using CityMap.DataModels;
using CityMap.Models;

namespace CityMap.Services.Interfaces
{
	public interface IMapper
	{
		IEnumerable<CityModel> MapCollection(IEnumerable<CityDataModel> cityDataModels);
	}
}
