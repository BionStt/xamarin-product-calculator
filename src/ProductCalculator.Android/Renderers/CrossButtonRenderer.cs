using System;
using System.ComponentModel;
using Android.Content;
using ProductCalculator.Droid.Renderers;
using ProductCalculator.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(CrossButtonRenderer))]
namespace ProductCalculator.Droid.Renderers
{
    public class CrossButtonRenderer : ButtonRenderer
    {
        public CrossButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            FontManager.Current.ChangeFont(Control, Element.FontFamily);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == Button.FontFamilyProperty.PropertyName)
            {
                FontManager.Current.ChangeFont(Control, Element.FontFamily);
            }
        }
    }
}
