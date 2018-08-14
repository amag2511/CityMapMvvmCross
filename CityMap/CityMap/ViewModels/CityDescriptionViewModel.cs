using System;
using System.Collections.Generic;
using System.Text;
using CityMap.Models;
using MvvmCross.ViewModels;

namespace CityMap.ViewModels
{
	public class CityDescriptionViewModel : MvxViewModel<CityModel>
	{
		private CityModel _city;

		public override void Prepare(CityModel parameter)
		{
			// receive and store the parameter here
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
