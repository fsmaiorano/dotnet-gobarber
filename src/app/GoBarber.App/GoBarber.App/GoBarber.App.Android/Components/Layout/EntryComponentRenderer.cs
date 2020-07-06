

using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using GoBarber.App.Components.Layout;
using GoBarber.App.Droid.Components.Layout;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(EntryComponent), typeof(EntryComponentRenderer))]
namespace GoBarber.App.Droid.Components.Layout
{
    public class EntryComponentRenderer : MaterialEntryRenderer
    {
        public EntryComponentRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Control.EditText.SetTextColor(Color.Rgb(255, 255, 255));
            }
        }

        protected override void OnFocusChanged(bool gainFocus, [GeneratedEnum] FocusSearchDirection direction, Rect previouslyFocusedRect)
        {
            base.OnFocusChanged(gainFocus, direction, previouslyFocusedRect);
        }
    }
}