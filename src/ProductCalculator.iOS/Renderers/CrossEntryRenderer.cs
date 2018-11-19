using System;
using ProductCalculator.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CrossEntryRenderer))]
namespace ProductCalculator.iOS.Renderers
{
    public class CrossEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            if (Element == null)
                return;

            this.Control.Layer.BorderWidth = 1.0f;
            this.Control.Layer.BorderColor = UIColor.Clear.CGColor;
        }

    }
}
