using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DataBindingOneObject
{
    public class RelativeToAbsoluteConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            string relativePath = value as string;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fullPath = $"{baseDirectory}{relativePath}";
            return fullPath;

        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
