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
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Window
    {
        public Book()
        {
            InitializeComponent();
        }

        public void onLoaded(object sender, RoutedEventArgs e)
        {
            CBook bookObj = new CBook("11", "Why we sleep ?", "assets/books/11.WhyWeSleep.jpg", "Matthew Walker", 2017);
            this.DataContext = bookObj;
        }
    }
}
