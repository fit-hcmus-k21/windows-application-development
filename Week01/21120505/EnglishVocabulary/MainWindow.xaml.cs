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

namespace EnglishVocabulary
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

        private void changeVocab_click (Object sender, RoutedEventArgs e)
        {
            Random generator = new Random();

            string[] vocabs = {

                "Squirrel",
                "Dog",
                "Pig",
                "Lion",
                "Mouse | Mice (plural)",
                "Monkey",
                "Elephant",
                "Fox",
                "Panda",
                "Kangaroo",
                "Leopard",
                "Coyote",
                "Cow",
                "Hedgehog",
                "Walrus"
            };

            string[] images =
            {
                "Images/image01.png",
                "Images/image02.png",
                "Images/image03.png",
                "Images/image04.png",
                "Images/image05.png",
                "Images/image06.png",
                "Images/image07.png",
                "Images/image08.png",
                "Images/image09.png",
                "Images/image10.png",
                "Images/image11.png",
                "Images/image12.png",
                "Images/image13.png",
                "Images/image14.png",
                "Images/image15.png"
            };

            int randomVocab = generator.Next(vocabs.Length);

            var img = new BitmapImage(new Uri(images[randomVocab], UriKind.Relative));

            vocabTextBlock.Text = vocabs[randomVocab];
            vocabImg.Source = img;

        }
    }
}
