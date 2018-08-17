using Foundation;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Plugin.File;
using System;
using System.IO;
using UIKit;

namespace Blank.Converters
{
	public class PathToImageValueConverter : MvxValueConverter<string, UIImage>
	{
		private const string DEFAULT_IMAGE_NAME = "default_image.jpg";

		protected override UIImage Convert(
			string value,
			Type targetType,
			object parameter,
			System.Globalization.CultureInfo culture)
		{
			if (string.IsNullOrEmpty(value))
			{
				return null;
			}

			var fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), value);

			return !File.Exists(fullPath) ? UIImage.FromBundle(DEFAULT_IMAGE_NAME) : UIImage.FromFile(fullPath);
		}
	}
}