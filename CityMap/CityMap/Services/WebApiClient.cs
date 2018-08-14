using CityMap.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CityMap.Services.Models;

namespace CityMap.Services
{
	public class WebApiClient : IWebApiClient, IDisposable
	{
		private readonly HttpClient _httpClient;

		public WebApiClient()
		{
			_httpClient = new HttpClient();
		}

		public async Task<ResponseData<T>> GetDataAsync<T>(string url)
		{
			var responseData = new ResponseData<T>();

			var response = await _httpClient.GetAsync(new Uri(url));

			if (response.StatusCode != HttpStatusCode.OK)
			{
				return responseData;
			}

			var responseBody = await response.Content.ReadAsStringAsync();

			try
			{
				responseData.Result = JsonConvert.DeserializeObject<T>(responseBody);

				responseData.IsSuccessed = true;

				return responseData;
			}
			catch
			{
				return responseData;
			}
		}

		public async Task<byte[]> GetDataAsByteArrayAsync(string url)
		{
			var response = await _httpClient.GetAsync(new Uri(url));

			if (response.StatusCode != HttpStatusCode.OK)
			{
				return null;
			}

			return await response.Content.ReadAsByteArrayAsync();
		}

		public void Dispose()
		{
			_httpClient.Dispose();
		}
	}
}

