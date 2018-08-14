using CityMap.Models;
using MvvmCross.ViewModels;
using System;

namespace CityMap.ViewModels
{
	public class CityLocationViewModel : MvxViewModel<CityModel>
	{
		private CityModel _city;

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
	}
}
