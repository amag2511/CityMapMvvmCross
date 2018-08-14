using System;
using Acr.UserDialogs;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using CityMap.Android.Controls;
using CityMap.ViewModels;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace CityMap.Android.Views
{
	[Activity(Label = "View for ListViewModel")]
	public class CityListView : MvxActivity<CityListViewModel>
	{
		private MvxRecyclerView _mvxRecyclerView;
		private CityRecyclerViewAdapter _cityRecyclerViewAdapter;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.city_listview_layout);

			InitializeMvxRecyclerView();

			ApplyBindings();
		}

		private void InitializeMvxRecyclerView()
		{
			_mvxRecyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
			_cityRecyclerViewAdapter = new CityRecyclerViewAdapter(
				(IMvxAndroidBindingContext) BindingContext,
				ViewModel.ItemSelectedCommand);

			_mvxRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
			_mvxRecyclerView.Adapter = _cityRecyclerViewAdapter;
		}

		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<CityListView, CityListViewModel>();
			bindingSet.Bind(_mvxRecyclerView).For(b => b.ItemsSource).To(vm => vm.Cities).Mode(MvxBindingMode.OneWay);
			bindingSet.Apply();
		}
	}
}