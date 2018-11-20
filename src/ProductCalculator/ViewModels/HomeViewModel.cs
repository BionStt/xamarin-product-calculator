using System;
using System.Collections.Generic;
using System.Globalization;
using Juniansoft.MvvmReady;
using ProductCalculator.Models;
using ProductCalculator.Resources;
using ProductCalculator.Services;
using Xamarin.Forms;

namespace ProductCalculator.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ILocalize _localize;

        public HomeViewModel()
        {
            _localize = DependencyService.Get<ILocalize>();
        }

        public string AppName => AppResources.ProductName;
        public string ContactButton => AppResources.ContactButton;

        public IList<Language> Languages => new List<Language>()
        {
            new Language(){Name = "English", Code = "en"},
        };

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            private set
            {
                Set(ref _selectedLanguage, value);
            }
        }

        public int SelectedLanguageIndex
        {
            get
            {
                return Settings.SelectedLanguageIndex;
            }
            set
            {
                var newIndex = Settings.SelectedLanguageIndex = value;
                Settings.SelectedLanguageCode = Languages[newIndex].Code;
                SelectedLanguage = Languages[newIndex].Name;
                UpdateLanguage();
                RaisePropertyChanged(nameof(SelectedLanguageIndex));
            }
        }

        void UpdateLanguage()
        {
            var langCode = Settings.SelectedLanguageCode;
            var ci = new CultureInfo(langCode);

            AppResources.Culture = ci; // set the RESX for resource localization
            _localize.SetLocale(ci); // set the Thread for locale-aware methods

            RaisePropertyChanged(nameof(AppName));
            RaisePropertyChanged(nameof(ContactButton));
        }

    }
}
