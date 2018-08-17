using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;
using System;
using System.Globalization;
using System.IO;

namespace CityMap.Android.Converters
{
	public class PathToImageValueConverter : MvxValueConverter<string, Drawable>
	{
		protected override Drawable Convert(
			string value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

			var fullPath = $"{currentActivity.FilesDir}/{value}";

			if (!File.Exists(fullPath))
			{
				return currentActivity.GetDrawable(Resource.Drawable.DefaultImage);
			}

			var decodedByte = BitmapFactory.DecodeFile(fullPath);

			return new BitmapDrawable(currentActivity.Resources, decodedByte);
		}
	}
}