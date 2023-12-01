using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entity;
using ThreeLayerContract;

namespace Level03_3LayerPlugin
{
    /// <summary>
    /// Interaction logic for FractionProgramWindow.xaml
    /// </summary>
    public partial class FractionProgramWindow : Window
    {
        IGUI _gui;

        public FractionProgramWindow(IGUI gui)
        {
            _gui = gui;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var control = _gui.GetMainWindow();            

            Content.Children.Add(control);
            Content.Width = control.Width;
            Content.Height = control.Height;

            MainWindow.DataContext = control;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
