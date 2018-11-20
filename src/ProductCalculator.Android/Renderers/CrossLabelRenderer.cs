using System;
using System.ComponentModel;
using Android.Content;
using ProductCalculator.Droid.Renderers;
using ProductCalculator.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(CrossLabelRenderer))]
namespace ProductCalculator.Droid.Renderers
{
    public class CrossLabelRenderer : LabelRenderer
    {

        public CrossLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            if (Element == null)
                return;

            FontManager.Current.ChangeFont(Control, Element.FontFamily);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
                return;

            if (Element == null)
                return;

            if (e.PropertyName == Label.FontFamilyProperty.PropertyName)
            {
                FontManager.Current.ChangeFont(Control, Element.FontFamily);
            }
        }
    }
}
