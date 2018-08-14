using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using System.Windows.Input;

namespace CityMap.Android.Controls
{
	public class CityRecyclerViewHolder : MvxRecyclerViewHolder
	{
		public CityRecyclerViewHolder(
			View itemView,
			IMvxAndroidBindingContext context) : base(itemView, context)
		{
		}
	}
}