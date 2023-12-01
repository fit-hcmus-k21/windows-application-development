using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFraction
{
    public class FractionReductionBus : IBus
    {
        public int gcd(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        public FractionReductionBus() { }

        public FractionReductionBus(IDao dao)
        {
            _dao = dao;
        }
        public override Fraction Add(Fraction a, Fraction b)
        {
            int num = a.Numerator * b.Denominator + a.Denominator * b.Numerator; //this.Nume
            int den = a.Denominator * b.Denominator;
            int common = gcd(num, den);
            num /= common;
            den /= common;
            Fraction result = new Fraction(num, den);
            return result;
        }

        public override void AddFraction(Fraction f)
        {
            _dao.Insert(f);
        }

        public override BindingList<Fraction> GetAllFractions()
        {
            return _dao.GetAllFractions();
        }

        public override IBus CreateNew(IDao dao)
        {
            return new FractionReductionBus(dao);
        }
    }
}
