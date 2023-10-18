using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishVocabulary
{
    internal class Quiz
    {
        // Properties
        private int totalQuestions;
        private int numberOfQuestionsDone;
        private int score;
        private string currentVocab;
        private List<int> indexQuestionShowed;
        private string[] vocabs;
        private string[] images;

        public Quiz(string[] vocabs, string[] images, int totalQuestions)   // done
        {
            this.totalQuestions = totalQuestions;
            this.numberOfQuestionsDone = 0;
            this.score = 0;
            this.currentVocab = "";
            indexQuestionShowed = new List<int>();
            this.vocabs = vocabs;
            this.images = images;
        }

        //Random a quiz
        public Dictionary<string, string> random()
        {
            Random generator = new Random();

            //create an random index for current vocab 
            int ranIndex = generator.Next(vocabs.Length);
            while (indexQuestionShowed.Contains(ranIndex))
            {
                ranIndex++;
                ranIndex = ranIndex % vocabs.Length;
            }
            indexQuestionShowed.Add(ranIndex);

            //create another random word 
            int ranIndexOpt = generator.Next(vocabs.Length);
            while (ranIndexOpt == ranIndex)
            {
                ranIndexOpt++;
                ranIndexOpt %= vocabs.Length;
            }

            //set current vocab to check 
            currentVocab = vocabs[ranIndex];

            //random a position to place answer : 22 just be a value that I like :))
            int ranPos = generator.Next(22);

            Dictionary<string, string> resultRandom = new Dictionary<string, string>();
            resultRandom.Add("image", images[ranIndex]);
            if (ranPos % 2 == 0)
            {
                resultRandom.Add("option1", vocabs[ranIndex]); // key answer
                resultRandom.Add("option2", vocabs[ranIndexOpt]); 
            } else
            {
                resultRandom.Add("option1", vocabs[ranIndexOpt]);
                resultRandom.Add("option2", vocabs[ranIndex]); // key answer
            }

            return resultRandom;

        }

        //check the option that person choose and answer 
        public void checkAnswer(string opt)     // done
        {
            if (opt == currentVocab)
            {
                score++;
            }
             numberOfQuestionsDone++;
        }

        public Boolean isFinish()   // done
        {
            if (numberOfQuestionsDone == totalQuestions)
            {
                return true;
            } 
            return false;
        }

        public int getScore()   // done
        {
            return score;
        }

        public int getNumberOfQuestionsDone()
        {
            return numberOfQuestionsDone;
        }

        public void reset() // done
        {
            score = 0;
            numberOfQuestionsDone = 0;
            currentVocab = "";

        }


    }
}
