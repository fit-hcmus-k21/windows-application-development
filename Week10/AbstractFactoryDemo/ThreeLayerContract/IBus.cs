using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ThreeLayerContract
{
    public abstract class IBus
    {
        protected IDAO _dao;
        public abstract Fraction Add(Fraction a, Fraction b);
        public abstract bool Save(Fraction f, string config);
        public abstract IBus CreateNew(IDAO dao);
        public abstract List<Fraction> GetAll(string config);
    }
}
