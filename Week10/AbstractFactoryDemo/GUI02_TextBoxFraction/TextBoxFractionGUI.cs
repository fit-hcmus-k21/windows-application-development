using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Entity;
using ThreeLayerContract;

namespace GUI02_TextBoxFraction
{
    public class TextBoxFractionGUI : IGUI
    {
        public TextBoxFractionGUI()
        {
        }

        public TextBoxFractionGUI(IBus bus)
        {
            _bus = bus;
        }

        public override IGUI CreateNew(IBus bus)
        {
            return new TextBoxFractionGUI(bus);
        }

        public override UserControl GetMainWindow()
        {
            return new UserControl1(_bus);
        }
    }
}
