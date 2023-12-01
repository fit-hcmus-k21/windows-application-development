using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using ThreeLayerContract;

namespace Bus01_NoReduction
{
    public class Bus01_NoRecduction : IBus
    {
        public Bus01_NoRecduction()
        {

        }

        public Bus01_NoRecduction(IDAO dao)
        {
            _dao = dao;
        }
        public override Fraction Add(Fraction a, Fraction b)
        {
            int num = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
            int den = a.Denominator * b.Denominator;

            return new Fraction() { Numerator = num, Denominator = den };
        }

        public override IBus CreateNew(IDAO dao)
        {
            return new Bus01_NoRecduction(dao);
        }

        public override bool Save(Fraction f, string config)
        {
            return _dao.Save(f, config);
        }

        public override string ToString()
        {
            return "Bus 01 - Add without reduction.";
        }

        public override List<Fraction> GetAll(string config)
        {
            return _dao.GetAll(config);
        }
    }
}
