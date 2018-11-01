using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ProductCalculator.Droid
{
    [Activity(Label = "Product Calculator", 
              Icon = "@mipmap/icon", 
              Theme = "@style/MainTheme", 
              MainLauncher = false, 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                // clear FLAG_TRANSLUCENT_STATUS flag:
                Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                //Window.ClearFlags(WindowManager.Pa WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
                Window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);

                // finally change the color
                var darkPrimaryColor = (Color) Xamarin.Forms.Application.Current.Resources["PrimaryDark"];
                Window.SetStatusBarColor(darkPrimaryColor.ToAndroid());
            }
        }
    }
}