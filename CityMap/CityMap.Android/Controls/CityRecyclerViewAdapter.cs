using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using System.Windows.Input;
using CityMap.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace CityMap.Android.Controls
{
	public class CityRecyclerViewAdapter : MvxRecyclerAdapter
	{
		private readonly ICommand _itemClickCommand;

		public CityRecyclerViewAdapter(IMvxAndroidBindingContext bindingContext, ICommand itemClickCommand)
			: base(bindingContext)
		{
			_itemClickCommand = itemClickCommand;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext?.LayoutInflaterHolder);
			var view = itemBindingContext.BindingInflate(Resource.Layout.city_item_template, parent, false);

			var viewHolder =
				new CityRecyclerViewHolder(view, itemBindingContext) {Click = _itemClickCommand};

			return viewHolder;
		}
	}
}