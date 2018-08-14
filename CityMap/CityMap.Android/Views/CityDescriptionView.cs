using Android.App;
using Android.OS;
using CityMap.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace CityMap.Android.Views
{
	[Activity(Label = "View for City Description")]
	public class CityDescriptionView : MvxActivity<CityDescriptionViewModel>
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.city_description_view_layout);
		}
	}
}