using System;
using System.Globalization;

namespace ProductCalculator.Services
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
