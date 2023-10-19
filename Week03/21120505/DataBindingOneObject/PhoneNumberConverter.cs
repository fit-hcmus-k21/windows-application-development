using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBindingOneObject
{
    internal class PhoneNumberConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
           // phone number format: 0xx xxx xxxx
           string phoneNum = value as string;
            return phoneNum.Substring(0, 3) + ' ' + phoneNum.Substring(3, 3) + ' ' + phoneNum.Substring(6);
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
