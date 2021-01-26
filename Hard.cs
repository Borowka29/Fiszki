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
        public int ktore { get; set; }
        public bool point;

        override public void play(MainWindow main, Word[] tabWords, int ktorePytanie)
        {
            ktore = ktorePytanie;
            this.question = tabWords[ktore].PolishVersion;
            this.correctAnswer = tabWords[ktore].EnglishVersion;

            main.gameHard.Visibility = Visibility.Visible;
            main.playHardNextButton.Visibility = Visibility.Hidden;
            main.colorChange(main);

            main.questionHard.Content = question;
        }

        public override void check(string answer, MainWindow main)
        {
            if (main.answerHard.Text == correctAnswer)
            {
                main.answerHard.Foreground = Brushes.LightGreen;
                main.nextHard.Visibility = Visibility.Hidden;
                point = true;
            }
            else
            {
                main.answerHard.Foreground = Brushes.Red;
                main.nextHard.Visibility = Visibility.Hidden;
                main.correctAnswerHard.Visibility = Visibility.Visible;
                main.correctAnswerHard.FontWeight = FontWeights.Bold;
                main.correctAnswerHard.Foreground = Brushes.LightGreen;
                point = false;
            }

            main.nextHard.Visibility = Visibility.Hidden;
            main.playHardNextButton.Visibility = Visibility.Visible;
        }
    }
}
