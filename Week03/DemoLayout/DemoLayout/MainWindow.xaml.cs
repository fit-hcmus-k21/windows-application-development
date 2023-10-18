using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DemoLayout
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

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new SettingsWindows();
            screen.Owner = this;
            screen.Show();

            Debug.WriteLine("An error has occurred");


           
        }

        Student _sv;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _sv = new Student()
            {
                Id = "007",
                Name = "James Bond",
                Credits = 80,
                Avatar = "assets/avatar02.jpg",
                Tuition = 22350000
            };

            DataContext = _sv;
        }

        private void updateButton_Click_1(object sender, RoutedEventArgs e)
        {
            _sv.Id = "008";
            _sv.Name = "Jason Bourne";
            _sv.Credits = 1;
            MessageBox.Show("Updated");
        }
    }
}
