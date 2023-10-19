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

namespace DataBindingOneObject
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

        private void onClickBtn(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            string option = btnClicked.Name.ToString();

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("bookBtn", new Book());
            data.Add("phoneBtn", new Phone());
            data.Add("employeeBtn", new Employee());

            // show new window
            var newWindow = (Window)data[option];
            newWindow.Show();

        }
    }
}
