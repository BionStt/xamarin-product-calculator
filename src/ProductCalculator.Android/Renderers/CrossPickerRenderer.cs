using System;
using Android.Content;
using Android.Graphics.Drawables;
using ProductCalculator.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Picker), typeof(CrossPickerRenderer))]
namespace ProductCalculator.Droid.Renderers
{
    public class CrossPickerRenderer : PickerRenderer
    {

        public CrossPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            if (Element == null)
                return;

            this.Control.Background = new ColorDrawable(Element.BackgroundColor.ToAndroid());
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (this.Element == null)
                return;

            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                this.Control.Background = new ColorDrawable(Element.BackgroundColor.ToAndroid());
            }
        }
    }
}
