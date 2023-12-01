using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Entity;
using ThreeLayerContract;
using System.Windows.Controls;

namespace GUINamespace
{
    class TwoPartsGUI : IGUI
    {        
        public TwoPartsGUI()
        {
        }

        public TwoPartsGUI(IBus bus)
        {
            _bus = bus;
        }

        public override IGUI CreateNew(IBus bus)
        {
            return new TwoPartsGUI(bus);
        }

        public override UserControl GetMainWindow()
        {
            return new UserControl1(_bus);
        }

        public override string ToString()
        {
            return "GUI01: Fraction are seperated";
        }


    }
}
