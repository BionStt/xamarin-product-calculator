using System;
using System.Collections.Generic;
using ProductCalculator.ViewModels;
using Xamarin.Forms;

namespace ProductCalculator.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            contactButton.Clicked +=
                async (sender, e) => await Navigation.PushAsync(new ContactPage()
                {
                    BindingContext = new ContactViewModel()
                });
        }
    }
}
