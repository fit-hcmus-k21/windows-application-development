using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFraction
{
    public class FractionBus: IBus
    {
        public FractionBus(IDao dao) { _dao = dao; }

        public override Fraction Add(Fraction a, Fraction b)
        {
            int num = a.Numerator * b.Denominator + a.Denominator * b.Numerator; //this.Nume
            int den = a.Denominator * b.Denominator;
            Fraction result = new Fraction(num, den);
            return result;
        }

        public override BindingList<Fraction> GetAllFractions()
        {
            return _dao.GetAllFractions();
        }

        public override void AddFraction(Fraction f)
        {
            _dao.Insert(f);
        }

        public override IBus CreateNew(IDao dao)
        {
            return new FractionBus(dao);
        }

        public FractionBus() { }
    }
}
