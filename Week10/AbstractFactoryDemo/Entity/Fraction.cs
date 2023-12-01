using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public static string SEPERATOR = "/";

        public override string ToString()
        {
            return $"{Numerator}{SEPERATOR}{Denominator}";
        }

        public static Fraction Parse(string line)
        {
            var tokens = line.Split(new string[] { SEPERATOR }, StringSplitOptions.None);
            var num = int.Parse(tokens[0]);
            var den = int.Parse(tokens[1]);
            var result = new Fraction() { Numerator = num, Denominator = den };
            return result;
        }
    }
}
