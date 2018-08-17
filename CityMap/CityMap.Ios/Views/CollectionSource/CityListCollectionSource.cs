using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Blank.Converters;
using Blank.Views.Cell;
using CityMap.Models;
using Foundation;
using MvvmCross.Base;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.Views.CollectionSource
{
	public class CityListCollectionSource : MvxCollectionViewSource
	{
		public CityListCollectionSource(UICollectionView collectionView) : base(collectionView)
		{
			collectionView.RegisterNibForCell(CityCell.Nib, CityCell.Key);
		}

		public CityListCollectionSource(UICollectionView collectionView, NSString defaultCellIdentifier) : base(collectionView, defaultCellIdentifier)
		{
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var item = ((IEnumerable<CityModel>)ItemsSource).ElementAt(indexPath.Row);

			var cityCell = GetOrCreateCellFor(collectionView, indexPath, item);

			return cityCell;
		}

		protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
		{
			if (!(collectionView.DequeueReusableCell(CityCell.Key ,indexPath) is CityCell cell))
			{
				cell = CityCell.Create();
			}

			var singleTap = new UITapGestureRecognizer(s =>
			{
				SelectionChangedCommand.Execute(item);
			});

			cell.UserInteractionEnabled = true;
			cell.AddGestureRecognizer(singleTap);

			if (cell is IMvxDataConsumer bindable)
			{
				bindable.DataContext = item;
			}

			return cell;
		}

		public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
		{
			return false;
		}

		//private UIImage GetIamge(string path)
		//{
		//	if (string.IsNullOrEmpty(path))
		//	{
		//		return null;
		//	}
		//	var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		//	var jpegData = NSData.FromFile(Path.Combine(docsPath, path));
		//	if (jpegData == null)
		//	{
		//		return null;
		//	}
		//	return UIImage.LoadFromData(jpegData);
		//}
	}
}