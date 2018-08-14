using Acr.UserDialogs;
using CityMap.Common;
using CityMap.DataModels;
using CityMap.Models;
using CityMap.Services.Interfaces;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityMap.Services
{
	public class CityApiService : ICityApiService
	{
		private readonly IWebApiClient _webApiClient;
		private readonly IMapper _mapper;
		private readonly IUserDialogs _userDialogs;
		private readonly IImageLoaderService _imageLoaderService;

		public CityApiService(IWebApiClient webApiClient, IMapper mapper, IUserDialogs userDialogs, IImageLoaderService imageLoaderService)
		{
			_userDialogs = userDialogs;
			_webApiClient = webApiClient;
			_mapper = mapper;
			_imageLoaderService = imageLoaderService;
		}

		public async Task<IEnumerable<CityModel>> GetCitiesAsync(string uri)
		{
			if (!CrossConnectivity.Current.IsConnected)
			{
				_userDialogs.Alert("The Internet connection appears to be offline");

				return JsonConvert.DeserializeObject<IEnumerable<CityModel>>(SettingsManager.CityList);
			}

			var responseCities = await _webApiClient.GetDataAsync<CitiesEntityDataModel>(uri);

			if (!responseCities.IsSuccessed)
			{
				return null;
			}

			var resultCollection = _mapper.MapCollection(responseCities.Result.Cities);

			await _imageLoaderService.WriteFilesAsync(resultCollection);

			return resultCollection;

		}
	}
}
