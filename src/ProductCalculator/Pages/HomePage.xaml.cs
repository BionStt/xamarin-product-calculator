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
            calculatorButton.Clicked +=
                async (_, e) => await Navigation.PushAsync(new CalculatorPage()
                {
                    BindingContext = new CalculatorViewModel()
                });
            contactButton.Clicked +=
                async (_, e) => await Navigation.PushAsync(new ContactPage()
                {
                    BindingContext = new ContactViewModel()
                });
        }
    }
}
