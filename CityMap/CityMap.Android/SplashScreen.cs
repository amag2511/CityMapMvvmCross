using System;
using System.Threading.Tasks;
using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace CityMap.Android
{
	[Activity(Label = "SplashScreen", MainLauncher = true, NoHistory = true)]
	public class SplashScreen : MvxSplashScreenActivity
	{
		public SplashScreen()
			: base(Resource.Layout.splash_screen_layout)
		{
			AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
		}

		private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			HandleUnhandledException(sender, e.Exception);
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			HandleUnhandledException(sender, e.ExceptionObject as Exception);
		}

		private void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
		{
			HandleUnhandledException(sender, e.Exception);
		}

		protected void HandleUnhandledException(object sender, Exception ex)
		{
			Console.WriteLine("EXCEPTION" + ex.Message);
		}
	}
}