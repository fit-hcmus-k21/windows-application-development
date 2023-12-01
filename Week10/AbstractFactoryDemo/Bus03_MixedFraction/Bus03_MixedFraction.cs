using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using ThreeLayerContract;

namespace BusNamespace
{
    public class Bus03_MixedFraction: IBus
    {
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using ThreeLayerContract;

namespace BusEmplementation
    {
        public class Bus02_Reduction : IBus
        {
            public Bus02_Reduction()
            {
            }

            public Bus02_Reduction(IDAO dao)
            {
                _dao = dao;
            }

            public override Fraction Add(Fraction a, Fraction b)
            {
                int num = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
                int den = a.Denominator * b.Denominator;
                
                

                return new Fraction() { Numerator = num / gcd, Denominator = den / gcd };
            }

            public override IBus CreateNew(IDAO dao)
            {
                return new Bus02_Reduction(dao);
            }

            public override bool Save(Fraction f)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return "Bus 03 - Mixed fraction.";
            }
        }
    }

}
}
