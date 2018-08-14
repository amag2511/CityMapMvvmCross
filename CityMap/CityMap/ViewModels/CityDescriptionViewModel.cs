using System.Windows.Input;
using CityMap.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.Connectivity.Abstractions;

namespace CityMap.ViewModels
{
	public class CityDescriptionViewModel : MvxViewModel<CityModel>
	{
		private readonly IMvxNavigationService _navigationService;

		private CityModel _city;
		private MvxCommand _showMapClickedCommand;

		public CityDescriptionViewModel(IMvxNavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public override void Prepare(CityModel parameter)
		{
			_city = parameter;
		}

		public CityModel City
		{
			get => _city;
			set
			{
				_city = value;
				RaisePropertyChanged(() => City);
			}
		}

		public ICommand ShowMapClickedCommand
		{
			get
			{
				_showMapClickedCommand = _showMapClickedCommand ?? new MvxCommand(DoSelectItem);
				return _showMapClickedCommand;
			}
		}

		private void DoSelectItem()
		{
			_navigationService.Navigate<CityLocationViewModel, CityModel>(City);
		}
	}
}
