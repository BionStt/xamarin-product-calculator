using System;
using System.Globalization;
using Xamarin.Forms;

namespace ProductCalculator.Converters
{
    public class NullableFloatConverter : IValueConverter
    {
        public NullableFloatConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (float?)value;
            return val.HasValue ? val.ToString() : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float? result = null;
            try
            {
                result = float.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
            return result;
        }
    }
}
