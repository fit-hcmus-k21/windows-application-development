using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFraction
{
    public class AbstractFractory
    {
        public IGui Create(IGui g, IBus b, IDao d)
        {
            IDao dao = d.CreateNew();
            IBus bus = b.CreateNew(dao);
            IGui gui = g.CreateNew(bus);

            return gui;
        }
    }
}
