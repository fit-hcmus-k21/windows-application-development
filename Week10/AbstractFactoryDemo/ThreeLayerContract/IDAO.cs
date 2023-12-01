using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ThreeLayerContract
{
    public abstract class IDAO
    {
        public abstract List<Fraction> GetAll(string config);
        public abstract bool Save(Fraction f, string config);
    }
}
