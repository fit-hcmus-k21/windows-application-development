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

namespace DataBindingOneObject
{
    /// <summary>
    /// Interaction logic for Phone.xaml
    /// </summary>
    public partial class Phone : Window
    {
        public Phone()
        {
            InitializeComponent();
        }

        public void onLoaded(object sender, RoutedEventArgs e)
        {
            CPhone phoneObj = new CPhone("Xiaomi Redmi Note 11", "assets/phones/01.XiaomiRedmiNote11.jpg", "Xiaomi Inc", 4690000);
            this.DataContext = phoneObj;
        }
    }
}
