using System;
using System.Globalization;

namespace ProductCalculator.Services
{
    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
