using System;
using Android.Content;
using Android.Graphics.Drawables;
using ProductCalculator.Droid.Renderers;
using ProductCalculator.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(CrossEditorRenderer))]
namespace ProductCalculator.Droid.Renderers
{
    public class CrossEditorRenderer : EditorRenderer
    {
        public CrossEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);


            if (Control == null)
                return;

            if (Element == null)
                return;

            this.Control.Background = new ColorDrawable(Element.BackgroundColor.ToAndroid());
            FontManager.Current.ChangeFont(Control, Element.FontFamily);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
                return;

            if (Element == null)
                return;

            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                this.Control.Background = new ColorDrawable(Element.BackgroundColor.ToAndroid());
            }
            else if (e.PropertyName == Editor.FontFamilyProperty.PropertyName)
            {
                FontManager.Current.ChangeFont(Control, Element.FontFamily);
            }
        }
    }
}
