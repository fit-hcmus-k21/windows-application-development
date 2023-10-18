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

namespace InspiringQuotes
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

        private void changeQuoteBtn_Click(object sender, RoutedEventArgs e)
        {
            Random generator = new Random();

            string[] quotes = {

                "Never give up.Today is hard, tomorrow will be worse, but the after tomorrow will be sunshine.",
                "Stay Hungry, Stay Foolish.",
                "The limits of my language mean the limits of my world.",
                "Life is not fair - get used to it !",
                "If you think your teacher is tough, wait 'til you get a boss. He doesn't have tenure.",
                "Imagination is more important than knowledge",
                "Anyone who has never made a mistake has never tried anything new.",
                "We should love, not fall in love. Because everything that falls, gets broken.",
                "Hard things will happens to us. We Will recover. We will learn from it. We will grow more resilent because of it.",
                "If they don't like you for being yourself, be yourself even more.",
                "Failure is an option here. If things are not failing, you are not innovating.",
                "People work better when they know what the goal is and why.",
                "The most important decision you make is to be in a good mood.",
                "You need the right people with you, not the best people.",
                "Only fools use their mouth to speak. A smart man uses his brain, and a wise man uses his heart."
            };

            string[] images =
            {
                "Images/image01.jpg",
                "Images/image02.jpg",
                "Images/image03.jpg",
                "Images/image04.jpg",
                "Images/image05.jpg",
                "Images/image06.jpg",
                "Images/image07.jpg",
                "Images/image08.jpg",
                "Images/image09.jpg",
                "Images/image10.jpg",
                "Images/image11.jpg",
                "Images/image12.jpg",
                "Images/image13.jpg",
                "Images/image14.jpg",
                "Images/image15.jpg"
            };

            int randomQuote = generator.Next(quotes.Length);

            var img = new BitmapImage(new Uri(images[randomQuote], UriKind.Relative));

            quoteLabel.Text = quotes[randomQuote];
            quoteImg.Source = img;
          
        }
    }
}
