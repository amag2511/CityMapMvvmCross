using CityMap.ViewModels;
using MapKit;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
	public class CityLocationViewController : MvxViewController<CityLocationViewModel>
	{
		public CityLocationViewController()
		{
		}

		public override void ViewDidLoad()
		{
			View = new MKMapView(UIScreen.MainScreen.Bounds);

			base.ViewDidLoad();

			// Perform any additional setup after loading the view
		}
	}
}