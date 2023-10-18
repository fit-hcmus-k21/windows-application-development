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
using static System.Net.Mime.MediaTypeNames;

namespace EnglishVocabulary
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        // Properties 
        private Quiz quizObj;

        public QuizWindow(string[] vocabs, string[] images)
        {
            InitializeComponent();
            quizObj = new Quiz(vocabs, images, 10);

            // set total question on display
            totalQuestions.Content = "Total: " + "10 ";

            // start quiz
            onChangeQuestion();

        }

        public void onChangeQuestion()
        {
            
            Dictionary<string, string> resRandom = new Dictionary<string, string>();
            resRandom = quizObj.random();

            //set img and options for current question
            option1Btn.Content = resRandom["option1"];
            option2Btn.Content = resRandom["option2"];

            //set  path abs for source img 
            string pathDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string pathToImg = $"{pathDirectory}{resRandom["image"]}";

            var img = new BitmapImage(new Uri(pathToImg, UriKind.Absolute));
            currentImg.Source = img;
        }

        private void optionBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedBtn = (Button)sender;
            if (clickedBtn != null)
            {
                quizObj.checkAnswer(clickedBtn.Content.ToString());

                //check if enough question: stop and show score, else continue to random
                if (quizObj.isFinish())
                {
                    MessageBox.Show("Your score: " + quizObj.getScore());

                } else
                {
                    onChangeQuestion();

                    // set quetions done
                    numberOfQuestionDone.Content = "Completed: " + quizObj.getNumberOfQuestionsDone();
                }
            }
            
        }

        private void goBack_click(object sender, RoutedEventArgs e)
        {
            var screen = new MainWindow();
            this.Close();
            screen.Show();
        }
    }
}
