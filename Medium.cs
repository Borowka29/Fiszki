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
    public class Medium : Strategia
    {
        public string question;
        public string correctAnswer;
        public string[] wrongAnswer = new string[3];
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
            this.wrongAnswer[2] = tabWords[indexy[2]].EnglishVersion;

            main.gameMedium.Visibility = Visibility.Visible;
            main.playMediumNextButton.Visibility = Visibility.Hidden;
            main.colorChange(main);

            main.questionEasy.Content = question;
            main.questionMedium.Content = question;

            correctIndex = rand.Next(4);

            if (correctIndex == 0)
            {
                main.answerMedium1.Content = correctAnswer;

                main.answerMedium2.Content = wrongAnswer[0];
                main.answerMedium3.Content = wrongAnswer[1];
                main.answerMedium4.Content = wrongAnswer[2];
            }

            else if (correctIndex == 1)
            {
                main.answerMedium2.Content = correctAnswer;

                main.answerMedium1.Content = wrongAnswer[0];
                main.answerMedium3.Content = wrongAnswer[1];
                main.answerMedium4.Content = wrongAnswer[2];
            }

            else if (correctIndex == 2)
            {
                main.answerMedium3.Content = correctAnswer;

                main.answerMedium1.Content = wrongAnswer[0];
                main.answerMedium2.Content = wrongAnswer[1];
                main.answerMedium4.Content = wrongAnswer[2];
            }

            else if (correctIndex == 3)
            {
                main.answerMedium4.Content = correctAnswer;

                main.answerMedium1.Content = wrongAnswer[0];
                main.answerMedium2.Content = wrongAnswer[1];
                main.answerMedium3.Content = wrongAnswer[2];
            }

            point = false;
        }
        public void losuj()
        {
            indexy = new int[3];
            do
            {
                indexy[0] = this.rand.Next(0, 4);
                indexy[1] = this.rand.Next(0, 4);
                indexy[2] = this.rand.Next(0, 4);
            } while (indexy[0] == ktore || indexy[0] == indexy[1] || indexy[1] == ktore|| indexy[2]== indexy[1]|| indexy[2]== indexy[0]|| indexy[2]==ktore);
        }
        
        public override void check(string answer, MainWindow main)
        {
            main.answerMedium1.Background = Brushes.Red;
            main.answerMedium2.Background = Brushes.Red;
            main.answerMedium3.Background = Brushes.Red;
            main.answerMedium4.Background = Brushes.Red;

            if (correctIndex == 0)
            {
                main.answerMedium1.Background = Brushes.LightGreen;
                if (answer == "m1")
                    point = true;
            }
            else if (correctIndex == 1)
            {
                main.answerMedium2.Background = Brushes.LightGreen;
                if (answer == "m2")
                    point = true;
            }
            else if (correctIndex == 2)
            {
                main.answerMedium3.Background = Brushes.LightGreen;
                if (answer == "m3")
                    point = true;
            }
            else if (correctIndex == 3)
            {
                main.answerMedium4.Background = Brushes.LightGreen;
                if (answer == "m4")
                    point = true;
            }

            main.playMediumNextButton.Visibility = Visibility.Visible;
        }
    }
}
