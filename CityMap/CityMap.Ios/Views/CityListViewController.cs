using Blank.Views.CollectionSource;
using CityMap.ViewModels;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System.Drawing;
using Blank.Views.Cell;
using UIKit;

namespace Blank.Views
{
	[Register("UniversalView")]
	public class CityListView : UIView
	{
		public UIButton MapButton { get; private set; }
		public UICollectionView CollectionView { get; private set; }
		public CityListCollectionSource CitiesCollectionSource { get; private set; }

		public CityListView(RectangleF bounds) : base(bounds)
		{
			Initialize();
		}

		private void Initialize()
		{
			BackgroundColor = UIColor.White;
			InitializeMapButton();
			InitializeCollectionView();
		}

		private void InitializeMapButton()
		{
			MapButton = new UIButton(new CGRect(0, 80, 120, 60)) {BackgroundColor = UIColor.Gray};
			MapButton.SetTitle("Map", UIControlState.Normal);
			MapButton.TitleLabel.Text = "Map";
			AddSubview(MapButton);
		}

		private void InitializeCollectionView()
		{
			var layout = new UICollectionViewFlowLayout
			{
				ItemSize = new CGSize(160, 200),
				SectionInset = new UIEdgeInsets(0, 30, 0, 20),
				ScrollDirection = UICollectionViewScrollDirection.Vertical,
				MinimumInteritemSpacing = 0,
				MinimumLineSpacing = 0
			};

			//CollectionView.RegisterNibForCell(CityCell.Nib, CityCell.Key);
			CollectionView = new UICollectionView(new CGRect(0, MapButton.Frame.Bottom + 10, Frame.Width, Frame.Height - MapButton.Frame.Bottom - 20), layout);
			AddSubview(CollectionView);
			CitiesCollectionSource = new CityListCollectionSource(CollectionView);
			CollectionView.Source = CitiesCollectionSource;
			CollectionView.BackgroundColor = UIColor.White;
		}
	}

	[Register("CityCityViewController")]
	public class CityListViewController : MvxViewController<CityListViewModel>
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var cityListView = new CityListView((RectangleF)View.Bounds);
			ApplyBindings(cityListView);

			View.AddSubview(cityListView);
		}

		private void ApplyBindings(CityListView cityListView)
		{
			var bindingSet = this.CreateBindingSet<CityListViewController, CityListViewModel>();
			bindingSet.Bind(cityListView.MapButton).To(vm => vm.NavigateToMapCommand);
			bindingSet.Bind(cityListView.CitiesCollectionSource).For(b => b.ItemsSource).To(vm => vm.Cities);
			bindingSet.Bind(cityListView.CitiesCollectionSource).For(b => b.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
			bindingSet.Apply();
		}
	}
}