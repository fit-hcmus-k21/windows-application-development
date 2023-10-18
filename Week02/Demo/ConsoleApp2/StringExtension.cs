using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class StringExtension
    {
        public static bool IsEmpty(this string s)
        {
            return s.Length == 0;
        } // StringExtension.IsEmpty(message)-> s.IsEmpty
    }
}
