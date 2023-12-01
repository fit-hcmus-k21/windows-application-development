using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusEmplementation
{
    class Util
    {
        /// <summary>
        /// Hàm tìm ước chung lớn nhất của hai số
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static int Gcd(int a, int b)
        {
            if (b != 0)
            {
                return Gcd(b, a % b);
            }
            else
            {
                return a;
            }
        }
    }
}
