using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using GoBarber.App.Components.Layout;
using GoBarber.App.iOS.Components.Layout;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryComponent), typeof(EntryComponentRenderer))]
namespace GoBarber.App.iOS.Components.Layout
{
    public class EntryComponentRenderer : MaterialEntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                Control.BorderStyle = UITextBorderStyle.Line;
            }
        }
    }
}