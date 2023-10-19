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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LayoutPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void layoutBtn_click(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            string option = btnClicked.Name.ToString();

            // option format: layout{id}Btn | layout1Btn/ layout2Btn...
            Dictionary<string, object> keyValuePairs= new Dictionary<string, object>();
            keyValuePairs.Add("layout1Btn", new Layout1());
            keyValuePairs.Add("layout2Btn", new Layout2());
            keyValuePairs.Add("layout3Btn", new Layout3());

            // open layout window 
            var layoutWindow = (Window) keyValuePairs[option];
            layoutWindow.Show();

        }
    }
}
