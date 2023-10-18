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
            DisplayRandomData(); // Refactoring
        }

        private void DisplayRandomData()
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

            // C:\Windows\Dev\ -> tan cung co san dau \
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
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
            string avatar = $"{baseDirectory}{avatars[i]}";

            var bitmap = new BitmapImage(
                new Uri(avatar, UriKind.Absolute)
            ); // Unique resource identifier
            avatarImage.Source = bitmap;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayRandomData();
        }

        private void quizButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new QuizWindow();
            screen.Show();

            this.Close();
        }
    }
}
