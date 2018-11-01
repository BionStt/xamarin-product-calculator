using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProductCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = App.CreateMainPage();
        }

        public static Page CreateMainPage()
        {
            var mainPage = new MainPage() { BindingContext = new MainViewModel() };
            var navigationPage = new NavigationPage(mainPage)
            {
                BarBackgroundColor = (Color)Current.Resources["Header"],
                BarTextColor = Color.White
            };
            return navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
