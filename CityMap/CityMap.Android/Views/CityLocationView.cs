using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using CityMap.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace CityMap.Android.Views
{
	[Activity]
	public class CityLocationView : MvxActivity<CityLocationViewModel> , IOnMapReadyCallback
	{
		private const string GOOGLE_MAP_TAG = "googlemap";
		private const float _mapZoom = 15f;

		private GoogleMap _googleMap;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.city_location_view_layout);

			SetUpMap();
		}

		private void SetUpMap()
		{
			if (_googleMap != null)
			{
				return;
			}

			var mapOptions = new GoogleMapOptions()
				.InvokeMapType(GoogleMap.MapTypeTerrain)
				.InvokeZoomControlsEnabled(true)
				.InvokeCompassEnabled(true);

			var fragTx = FragmentManager.BeginTransaction();

			var mapFragment = MapFragment.NewInstance(mapOptions);

			fragTx.Add(Resource.Id.googlemap, mapFragment, GOOGLE_MAP_TAG);
			fragTx.Commit();

			mapFragment.GetMapAsync(this);
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			_googleMap = googleMap;

			var latlng = new LatLng(ViewModel.City.Latitude, ViewModel.City.Longitude);

			googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(latlng, _mapZoom));

			var options = new MarkerOptions().SetPosition(latlng).SetTitle(ViewModel.City.Title);
			googleMap.AddMarker(options);
		}
	}
}