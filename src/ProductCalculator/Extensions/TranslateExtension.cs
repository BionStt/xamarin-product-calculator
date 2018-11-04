using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using ProductCalculator.Resources;
using ProductCalculator.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductCalculator.Extensions
{
    [ContentProperty(nameof(Text))]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        private static readonly string ResourceId = typeof(AppResources).FullName;

        private static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId
                                                                                                                  , typeof(TranslateExtension).GetTypeInfo().Assembly));

        public TranslateExtension()
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                var langCode = Settings.SelectedLanguageCode;
                ci = new CultureInfo(langCode);
                Resources.AppResources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            var translation = ResMgr.Value.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format($"Key '{Text}' was not found in resources '{ResourceId}' for culture '{ci.Name}'."),
                    nameof(Text));
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
