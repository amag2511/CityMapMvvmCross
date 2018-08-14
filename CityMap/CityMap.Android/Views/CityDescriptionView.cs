using Android.App;
using Android.OS;
using Android.Widget;
using CityMap.ViewModels;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
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

			SetBindings();
		}

		private void SetBindings()
		{
			var showOnMapButton = FindViewById<Button>(Resource.Id.ShowOnMapButton);
			var bindingSet = this.CreateBindingSet<CityDescriptionView, CityDescriptionViewModel>();
			bindingSet.Bind(showOnMapButton).To(vm => vm.ShowMapClickedCommand).Mode(MvxBindingMode.OneWay);
			bindingSet.Apply();
		}
	}
}