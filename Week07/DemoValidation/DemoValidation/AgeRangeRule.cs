using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoValidation
{
    public class AgeRangeRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age = 0;

            try
            {
                if (((string) value).Length > 0)
                {
                    age = int.Parse((string) value);
                }
            } catch (Exception ex)
            {
                return new ValidationResult(false,
                    $"Invalid format or {ex.Message}");
            }

            if ( age < Min || Max < age) {
                return new ValidationResult(false,
                    $"Please enter age in the range of [{Min}, {Max}]");
            }

            return ValidationResult.ValidResult;
        }
    }
}
