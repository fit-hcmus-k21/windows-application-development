using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DemoValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public int Age { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;


        class User
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Avatar { get; set; }
            public DateTime Birthday { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Age = 15;
            DataContext = this;

            var users = new List<User>()
            {
                new User() {Avatar="assets/avatar01.jpg", Id = "001", Name="Tran Huu Long", Birthday=new DateTime(1971, 7, 23)},
                new User() {Avatar="assets/avatar02.jpg", Id = "002", Name="Cao Hoang Thai", Birthday=new DateTime(1974, 1, 17)},
                new User() {Avatar="assets/avatar03.jpg", Id = "003", Name="Do Tan Tai", Birthday=new DateTime(1991, 9, 2)},
            };

            dataGrid.ItemsSource = users;
        }
    }
}
