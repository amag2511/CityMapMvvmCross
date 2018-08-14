using System;
using Acr.UserDialogs;
using Android.App;
using Android.Runtime;
using MvvmCross.Core;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace CityMap.Android
{
	[Application]
	public class MainApplication : MvxAndroidApplication<MvxAndroidSetup<App>, App>
	{
		public MainApplication()
			: base()
		{
		}


		public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
			UserDialogs.Init(this);
		}
	}
}