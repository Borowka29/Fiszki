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
        public string[] wrongAnswer = { "", "" };
        public int correctIndex;
        public bool point;

        override public void play(MainWindow main)
        {
            this.question = readQuestion(0);
            this.correctAnswer = readAnswer(0);
            this.wrongAnswer[0] = readAnswer(1);
            this.wrongAnswer[1] = readAnswer(2);

            main.gameEasy.Visibility = Visibility.Visible;
            main.playEasyNextButton.Visibility = Visibility.Hidden;
            main.colorChange(main);

            main.questionMedium.Content = question;

            Random rand = new Random();
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

        public override void check(string answer, MainWindow main)
        {
            main.answerEasy1.Background = Brushes.Red;
            main.answerEasy2.Background = Brushes.Red;
            main.answerEasy3.Background = Brushes.Red;

            if (correctIndex == 0)
            {
                main.answerEasy1.Background = Brushes.LightGreen;
                if (answer == "e1")
                    point = true;
            }

            else if (correctIndex == 1)
            {
                main.answerEasy2.Background = Brushes.LightGreen;
                if (answer == "e2")
                    point = true;
            }
            else if (correctIndex == 2)
            {
                main.answerEasy3.Background = Brushes.LightGreen;
                if (answer == "e3")
                    point = true;
            }

            main.playEasyNextButton.Visibility = Visibility.Visible;

        }

        public string readQuestion(int index)
        {
            string q;
            // <--- zczytanie pytania z pliku
            return "trzeba ustawic";
        }

        public string readAnswer(int index)
        {
            string a;
            // <--- zczytanie odpowiedzi z pliku
            return "trzeba ustawic";
        }
    }
}
