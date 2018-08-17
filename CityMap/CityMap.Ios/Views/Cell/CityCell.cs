using System;
using Blank.Converters;
using CityMap.Models;
using Foundation;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views.Cell
{
	public partial class CityCell : MvxCollectionViewCell
	{
		public static readonly NSString Key = new NSString("CityCell");
		public static readonly UINib Nib;

		static CityCell()
		{
			Nib = UINib.FromName("CityCell", NSBundle.MainBundle);
		}

		protected CityCell(IntPtr handle) : base(handle)
		{
			InitializeBindings();
			// Note: this .ctor should not contain any initialization logic.
		}

		public static CityCell Create()
		{
			return Nib.Instantiate(null, null)[0] as CityCell;
		}

		public UIImage Image
		{
			get => CityImage.Image;
			set => CityImage.Image = value;
		}

		public string Title
		{
			get => CityLabel.Text;
			set => CityLabel.Text = value;
		}

		private void InitializeBindings()
		{
			this.DelayBind(
				() =>
				{
					this.CreateBinding().For(cell => cell.Title).To((CityModel city) => city.Title)
						.Mode(MvxBindingMode.OneWay).Apply();
					this.CreateBinding().For(cell => cell.Image).To((CityModel city) => city.Title)
						.Mode(MvxBindingMode.OneWay).WithConversion<PathToImageValueConverter>().Apply();
				});
		}
	}
}