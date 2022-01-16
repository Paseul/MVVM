using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVM.ViewModel
{
    class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);
            if (value == null)
            {
                return color;
            }

            if ((int)value == 0)
            {
                color = new SolidColorBrush(Colors.LightGray);
            }
            if ((int)value == 1)
            {
                color = new SolidColorBrush(Colors.Yellow);
            }
            if ((int)value == 2)
            {
                color = new SolidColorBrush(Colors.Lime);
            }
            if ((int)value == 3)
            {
                color = new SolidColorBrush(Colors.Red);
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
