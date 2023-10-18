using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DemoLayout
{
    public class TuitionToCurrencyConvertercs : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tuition = (int)value;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");  // en-US /en-UK

            string result = tuition.ToString("#,### đ", cul.NumberFormat);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
