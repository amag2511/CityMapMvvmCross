using Acr.UserDialogs;
using CityMap.Models;
using CityMap.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityMap.ViewModels
{
	public class CityListViewModel : MvxViewModel
	{
		private const string WEB_API_URL = "https://api.myjson.com/bins/7ybe5";

		private readonly IMvxNavigationService _navigationService;
		private readonly ICityApiService _cityApiService;
		private readonly IUserDialogs _userDialogs;

		private MvxCommand<CityModel> _itemSelectedCommand;
		private MvxCommand<CityModel> _navigateToMapCommand;
		private IEnumerable<CityModel> _cities;

		public CityListViewModel(
			IMvxNavigationService navigationService,
			ICityApiService cityApiService,
			IUserDialogs userDialogs)
		{
			_userDialogs = userDialogs;
			_cityApiService = cityApiService;
			_navigationService = navigationService;
		}

		public override async Task Initialize()
		{
			await base.Initialize();

			CrossConnectivity.Current.ConnectivityChanged += OnCurrentConnectivityChanged;
		}

		public override async void ViewCreated()
		{
			base.ViewCreated();

			await UpdateCityListAsync();
		}

		public IEnumerable<CityModel> Cities
		{
			get => _cities;
			set
			{
				_cities = value;
				RaisePropertyChanged(() => Cities);
			}
		}

		public ICommand ItemSelectedCommand
		{
			get
			{
				_itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<CityModel>(DoSelectItem);
				return _itemSelectedCommand;
			}
		}

		public ICommand NavigateToMapCommand
		{
			get
			{
				_navigateToMapCommand = _navigateToMapCommand ?? new MvxCommand<CityModel>(DoNavigateToMap);
				return _navigateToMapCommand;
			}
		}

		private async void OnCurrentConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			if (e.IsConnected)
			{
				await UpdateCityListAsync();
			}
		}

		private void DoNavigateToMap(CityModel city)
		{
			_navigationService.Navigate<CityLocationViewModel, CityModel>(city);
		}

		private void DoSelectItem(CityModel city)
		{
			_navigationService.Navigate<CityDescriptionViewModel, CityModel>(city);
		}

		private async Task UpdateCityListAsync()
		{
			_userDialogs.ShowLoading();

			Cities = new MvxObservableCollection<CityModel>(await _cityApiService.GetCitiesAsync(WEB_API_URL));

			_userDialogs.HideLoading();
		}
	}
}
