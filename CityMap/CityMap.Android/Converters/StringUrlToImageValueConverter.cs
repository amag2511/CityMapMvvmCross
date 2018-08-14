using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;
using System;
using System.Globalization;
using Acr.UserDialogs.Infrastructure;
using Android.Content.Res;
using Android.Support.V4.Content;
using MvvmCross.Plugin.File;

namespace CityMap.Android.Converters
{
	public class StringUrlToImageValueConverter : MvxValueConverter<string, Drawable>
	{
		private IMvxFileStore _fileStore;

		public StringUrlToImageValueConverter()
		{
			_fileStore = Mvx.Resolve<IMvxFileStore>();
		}

		protected override Drawable Convert(
			string value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

			if (!_fileStore.Exists(value))
			{
				return currentActivity.GetDrawable(Resource.Drawable.DefaultImage);
			}

			var decodedByte = BitmapFactory.DecodeFile($"{currentActivity.FilesDir}/{value}");

			return new BitmapDrawable(currentActivity.Resources, decodedByte);

		}
	}
}