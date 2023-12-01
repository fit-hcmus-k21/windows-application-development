using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class Fraction
    {
        public int Numerator { get; set; } = 0;
        public int Denominator { get; set; } = 1;

        public Fraction()
        {

        }

        public Fraction(int num, int den)
        {
            Numerator = num;
            Denominator = den;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Fraction Parse(string info)
        {
            var tokens = info.Split(new string[] { "/" },
                StringSplitOptions.None);
            int num = int.Parse(tokens[0]);
            int den = int.Parse(tokens[1]);
            Fraction result = new Fraction(num, den);
            return result;
        }
    }
}
