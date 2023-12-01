using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoFraction
{
    public class AdvancedUI : IGui
    {
        public AdvancedUI() { }
        public AdvancedUI(IBus bus) {
            _bus = bus;
        }

        public override IGui CreateNew(IBus bus)
        {
            return new AdvancedUI(bus);
        }

        public override UserControl GetMainWindow()
        {
            return new FullNumberUserControl(_bus);
        }
    }
}
