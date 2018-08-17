using Blank.Converters;
using CityMap.ViewModels;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System.Drawing;
using UIKit;

namespace Blank.Views
{
	[Register("CityDescriptionView")]
	public class CityDescriptionView : UIView
	{
		public UIImageView ImageView { get; private set; }
		public UITextView TextView { get; private set; }

		public CityDescriptionView()
		{
			Initialize();
		}

		public CityDescriptionView(RectangleF bounds) : base(bounds)
		{
			Initialize();
		}

		private void Initialize()
		{
			BackgroundColor = UIColor.White;

			InitializeComponents();
		}

		private void InitializeComponents()
		{
			InitImageView();
			InitTextView();
		}
		private void InitImageView()
		{
			ImageView = new UIImageView(new CGRect(40, 40, Frame.Width - 80, (Frame.Height - 20) / 2f));

			AddSubview(ImageView);
		}
		private void InitTextView()
		{
			TextView = new UITextView(
				new CGRect(
					10,
					ImageView.Frame.Bottom + 10,
					Frame.Width - 20,
					Frame.Height - ImageView.Frame.Bottom - 10))
			{
				Font = UIFont.FromName("HelveticaNeue-Bold", 20f)
			};

			AddSubview(TextView);
		}
	}

	[Register("CityDescriptionViewController")]
	public class CityDescriptionViewController : MvxViewController<CityDescriptionViewModel>
	{
		public CityDescriptionViewController()
		{
		}

		public override void ViewDidLoad()
		{
			var cityView = new CityDescriptionView((RectangleF)View.Bounds);
			ApplyBindings(cityView.ImageView, cityView.TextView);

			View.AddSubview(cityView);

			base.ViewDidLoad();
		}


		private void ApplyBindings(UIImageView imageView, UITextView textView)
		{
			var bindingSet = this.CreateBindingSet<CityDescriptionViewController, CityDescriptionViewModel>();
			bindingSet.Bind(imageView).For(b => b.Image).To(vm => vm.City.Title).WithConversion<PathToImageValueConverter>();
			bindingSet.Bind(textView).For(b => b.Text).To(vm => vm.City.Description);
			bindingSet.Apply();
		}
	}
}