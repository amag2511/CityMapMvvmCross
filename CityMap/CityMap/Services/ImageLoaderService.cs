using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CityMap.Models;
using CityMap.Services.Interfaces;
using MvvmCross.Plugin.File;

namespace CityMap.Services
{
	public class ImageLoaderService : IImageLoaderService
	{
		private readonly IMvxFileStore _fileStore;
		private readonly IWebApiClient _webApiClient;

		public ImageLoaderService(IMvxFileStore fileStore, IWebApiClient webApiClient)
		{
			_webApiClient = webApiClient;
			_fileStore = fileStore;
		}

		public async Task WriteFilesAsync(IEnumerable<CityModel> cityModels)
		{
			if (cityModels?.Any() != true)
			{
				return;
			}

			foreach (var city in cityModels)
			{
				if (_fileStore.Exists(city?.Title))
				{
					continue;
				}

				try
				{
					var imageByteArray = await _webApiClient.GetDataAsByteArrayAsync(city?.Url);

					if (imageByteArray?.Length > 0)
					{
						_fileStore.WriteFile(city?.Title, imageByteArray);
					}
				}

				catch (Exception e)
				{
					Console.WriteLine("EXCEPTION!!!!!!!!!!!!!!!!!!!!!! " + e.Message);
				}
			}
		}
	}
}
