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
        public string[] wrongAnswer = { "", "", "" };
        public int correctIndex;
        public bool point;

        override public void play(MainWindow main)
        {
            this.question = readQuestion(0);
            this.correctAnswer = readAnswer(0);
            this.wrongAnswer[0] = readAnswer(1);
            this.wrongAnswer[1] = readAnswer(2);
            this.wrongAnswer[2] = readAnswer(3);

            main.gameMedium.Visibility = Visibility.Visible;
            main.playMediumNextButton.Visibility = Visibility.Hidden;
            main.colorChange(main);

            main.questionMedium.Content = question;

            Random rand = new Random();
            correctIndex = rand.Next(3);

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
