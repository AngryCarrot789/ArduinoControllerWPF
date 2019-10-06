using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ArduinoController.Utils
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    public class BoolToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                //green
                return new SolidColorBrush(Color.FromRgb(22, 203, 55));
            }
            else
            {
                //red
                return new SolidColorBrush(Color.FromRgb(207, 28, 28));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
