using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoFraction
{
    public class FractionUI : IGui
    {
        public FractionUI() { }

        public FractionUI(IBus bus)
        {
            _bus = bus;
        }

        public override IGui CreateNew(IBus bus)
        {
            return new FractionUI(bus);
        }

        public override UserControl GetMainWindow()
        {
            var screen = new BasicUserControl(_bus);
            return screen;
        }
    }
}
