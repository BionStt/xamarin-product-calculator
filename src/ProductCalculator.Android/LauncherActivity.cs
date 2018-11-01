using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProductCalculator.Droid
{
    [Activity(Label = "Product Calculator",
              Icon = "@mipmap/icon",
              Theme = "@style/LauncherTheme",
              MainLauncher = true,
              NoHistory = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
              ScreenOrientation = ScreenOrientation.Portrait)]
    public class LauncherActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Window.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
            ActionBar?.Hide();
        }

        protected override void OnResume()
        {
            base.OnResume();

            StartActivity(typeof(MainActivity));
        }
    }
}
