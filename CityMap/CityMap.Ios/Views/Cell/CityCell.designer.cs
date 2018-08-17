// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Blank.Views.Cell
{
    [Register ("CityCell")]
    partial class CityCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView CityImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CityImage != null) {
                CityImage.Dispose ();
                CityImage = null;
            }

            if (CityLabel != null) {
                CityLabel.Dispose ();
                CityLabel = null;
            }
        }
    }
}