using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Lunula.Core.Converters
{
    public class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = value as bool?;
            return b.HasValue && b.Value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
