using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ProductCalculator.Services
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static int SelectedLanguageIndex
        {
            get => AppSettings.GetValueOrDefault(nameof(SelectedLanguageIndex), 0);
            set => AppSettings.AddOrUpdateValue(nameof(SelectedLanguageIndex), value);
        }

        public static string SelectedLanguageCode
        {
            get => AppSettings.GetValueOrDefault(nameof(SelectedLanguageCode), "en");
            set => AppSettings.AddOrUpdateValue(nameof(SelectedLanguageCode), value);
        }
    }
}
