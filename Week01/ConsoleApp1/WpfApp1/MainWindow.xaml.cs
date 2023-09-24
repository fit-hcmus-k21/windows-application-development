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

namespace WpfApp1
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

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();

            string[] salutes =
            {
                "Hello",
                "Salute",
                "Bon jour",
                "Xiao",
                "Selamat datang",
                "Ohayo"
            };
            int i = rng.Next(salutes.Length);
            string salute = salutes[i];
            saluteLabel.Content = salute;

            string[] avatars =
            {
                "Images/avatar01.jpg",
                "Images/avatar02.jpg",
                "Images/avatar03.jpg",
                "Images/avatar04.jpg",
                "Images/avatar05.jpg",
                "Images/avatar06.jpg",
                "Images/avatar07.jpg",
                "Images/avatar08.jpg",
                "Images/avatar09.jpg",
                "Images/avatar10.jpg",
            };
            
            i = rng.Next(avatars.Length);
            string avatar = avatars[i];

            var bitmap = new BitmapImage(
                new Uri(avatar, UriKind.Relative)
            ); // Unique resource identifier
            avatarImage.Source = bitmap;
        }
    }
}
