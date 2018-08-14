using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CityMap.Common
{
	public static class SettingsManager
	{
		private const string CITY_LIST_KEY = "city_list_key";

		private static ISettings _appSettings = CrossSettings.Current;

		public static string CityList
		{
			get => _appSettings.GetValueOrDefault(CITY_LIST_KEY, string.Empty);
			set => _appSettings.AddOrUpdateValue(CITY_LIST_KEY, value);
		}
	}
}
