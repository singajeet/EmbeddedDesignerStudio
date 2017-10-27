using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace Core.Utils
{
    public class UISelectedItemToContentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // first value is selected menu item, second value is selected option item
            if (values != null && values.Length > 1)
            {
                return values[0] ?? values[1];
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return targetTypes.Select(t => Binding.DoNothing).ToArray();
        }
    }
}
