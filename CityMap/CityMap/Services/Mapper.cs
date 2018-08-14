using CityMap.DataModels;
using CityMap.Models;
using System.Collections.Generic;
using IMapper = CityMap.Services.Interfaces.IMapper;

namespace CityMap.Services
{
	public class Mapper : IMapper
	{
		public Mapper()
		{
			AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<CityDataModel, CityModel>());
		}
		public IEnumerable<CityModel> MapCollection(IEnumerable<CityDataModel> cityDataModels)
		{
			if (cityDataModels == null)
			{
				return null;
			}

			return AutoMapper.Mapper.Map<IEnumerable<CityDataModel>, IEnumerable<CityModel>>(cityDataModels);
		}
	}
}
