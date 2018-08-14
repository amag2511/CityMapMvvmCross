using Acr.UserDialogs;
using CityMap.Common;
using CityMap.Services;
using CityMap.Services.Interfaces;
using CityMap.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace CityMap
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			Mvx.RegisterType<ICityApiService, CityApiService>();
			Mvx.RegisterType<IMapper, Mapper>();
			Mvx.RegisterType<IImageLoaderService, ImageLoaderService>();

			Mvx.RegisterSingleton<IWebApiClient>(() => new WebApiClient());

			Mvx.RegisterSingleton(() => UserDialogs.Instance);

			RegisterAppStart<CityListViewModel>();
		}
	}
}