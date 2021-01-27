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
using System.IO;

namespace Fiszki
{
    public class Hard : Strategia
    {
        public string question;
        public string correctAnswer;
        private string userAnswer;
        public int ktore { get; set; }
        public bool point;

        override public void play(MainWindow main, Word[] tabWords, int ktorePytanie)
        {
            main.gameHard.Visibility = Visibility.Visible;
            main.playHardNextButton.Visibility = Visibility.Hidden;
            main.previousQuestionHard.Visibility = Visibility.Hidden;

            ktore = ktorePytanie;
            if (main.translationFromPolish == true)
            {
                this.question = tabWords[ktore].PolishVersion;
                this.correctAnswer = tabWords[ktore].EnglishVersion;
            }
            else
            {
                this.question = tabWords[ktore].EnglishVersion;
                this.correctAnswer = tabWords[ktore].PolishVersion;
            }

            main.gameHard.Visibility = Visibility.Visible;
            main.playHardNextButton.Visibility = Visibility.Hidden;
            main.colorChange();

            main.questionHard.Content = question;
            if (ktore == 9)
            {
                main.playHardNextButton.Content = "Koniec";
            }
                
            else
                main.playHardNextButton.Content = "Dalej";
        }

        public override void check(string answer, MainWindow main)
        {
            if (main.answerHard.Text == correctAnswer)
            {
                main.nextHard.Visibility = Visibility.Hidden;
                point = true;
            }
            else
            {
                main.nextHard.Visibility = Visibility.Hidden;
                main.correctAnswerHard.Visibility = Visibility.Visible;
                main.correctAnswerHard.FontWeight = FontWeights.Bold;
                main.correctAnswerHard.Foreground = Brushes.LightGreen;
                point = false;
            }

            main.nextHard.Visibility = Visibility.Hidden;
            main.playHardNextButton.Visibility = Visibility.Visible;
            userAnswer = answer;

            if (main.tryb == 2 && ktore > 0)
                main.previousQuestionHard.Visibility = Visibility.Visible;
            if (ktore == 9)
            {
                main.playHardNextButton.Content = "Koniec";
                end = true;
            }
            else
            {
                main.playHardNextButton.Content = "Dalej";
                end = false;
            }
        }

        public override Answer GetQuestion()
        {
            return new Answer(question, correctAnswer, null, userAnswer, 0);
        }
        override public void ShowQuestion(MainWindow main, Answer ans, int ktorePytanie)
        {
            ktore = ktorePytanie;
            this.question = ans.Question;
            this.correctAnswer = ans.CorrectAnswer;
            

            main.gameHard.Visibility = Visibility.Visible;
            main.playHardNextButton.Visibility = Visibility.Hidden;
            main.colorChange();

            main.questionHard.Content = question;

            //ans.UserAnswer - wpisać 
            main.answerHard.Text = ans.UserAnswer;
        }

        public void showNumber(MainWindow main)
        {
            main.questionNumHard.Content = "Pytanie " + (ktore + 1).ToString() + "/10";
        }
    }
}
