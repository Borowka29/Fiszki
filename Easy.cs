using Fiszki.DAL;
using Fiszki.Models;
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

namespace Fiszki
{
    public class Easy : Strategia
    {
        public string question;
        public string correctAnswer;
        public string[] wrongAnswer =new string[2];
        public int ktore { get; set; }
        private int[] indexy;
        private Random rand { get; set; } = new Random();
        public int correctIndex;
        public bool point;

        override public void play(MainWindow main, Word[] tabWords, int ktorePytanie)
        {
            ktore = ktorePytanie;
            this.question = tabWords[ktore].PolishVersion;
            this.correctAnswer = tabWords[ktore].EnglishVersion;

            losuj();
            this.wrongAnswer[0] = tabWords[indexy[0]].EnglishVersion;
            this.wrongAnswer[1] = tabWords[indexy[1]].EnglishVersion;

            main.questionEasy.Content = question;

            correctIndex = rand.Next(3);

            if (correctIndex == 0)
            {
                main.answerEasy1.Content = correctAnswer;
                main.answerEasy2.Content = wrongAnswer[0];
                main.answerEasy3.Content = wrongAnswer[1];
            }

            else if (correctIndex == 1)
            {
                main.answerEasy2.Content = correctAnswer;
                main.answerEasy1.Content = wrongAnswer[0];
                main.answerEasy3.Content = wrongAnswer[1];
            }

            else if (correctIndex == 2)
            {
                main.answerEasy3.Content = correctAnswer;
                main.answerEasy1.Content = wrongAnswer[0];
                main.answerEasy2.Content = wrongAnswer[1];
            }

            point = false;
        }
        public void losuj()
        {
            indexy = new int[2];
            do
            {
                indexy[0]=this.rand.Next(0, 4);
                indexy[1] = this.rand.Next(0, 4);

            } while (indexy[0] == ktore || indexy[0] == indexy[1] || indexy[1] == ktore); 
        }
        //
        public override void check(string answer, MainWindow main)
        {
            if (correctIndex == 0)
            {
                if (answer == "e1")
                    point = true;
            }
            else if (correctIndex == 1)
            {
                if (answer == "e2")
                    point = true;
            }
            else if (correctIndex == 2)
            {
                if (answer == "e3")
                    point = true;
            }
            //main.playEasyNextButton.Visibility = Visibility.Visible;

        }
    }
}
