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
        private string userAnswer;
        public string[] wrongAnswer = new string[2];
        public int ktore { get; set; }
        private int[] indexy;
        private Random rand { get; set; } = new Random();
        public int correctIndex;
        public bool point;

        override public void play(MainWindow main, Word[] tabWords, int ktorePytanie)
        {

            main.gameEasy.Visibility = Visibility.Visible;
            main.playEasyNextButton.Visibility = Visibility.Hidden;
            main.previousQuestionEasy.Visibility = Visibility.Hidden;

            ktore = ktorePytanie;
            losuj();
            if (main.translationFromPolish == true)
            {
                this.question = tabWords[ktore].PolishVersion;
                this.correctAnswer = tabWords[ktore].EnglishVersion;
                this.wrongAnswer[0] = tabWords[indexy[0]].EnglishVersion;
                this.wrongAnswer[1] = tabWords[indexy[1]].EnglishVersion;
            }
            else
            {
                this.question = tabWords[ktore].EnglishVersion;
                this.correctAnswer = tabWords[ktore].PolishVersion;
                this.wrongAnswer[0] = tabWords[indexy[0]].PolishVersion;
                this.wrongAnswer[1] = tabWords[indexy[1]].PolishVersion;
            }
            

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
                indexy[0] = this.rand.Next(0, 4);
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
            userAnswer = answer;

            main.playEasyNextButton.Visibility = Visibility.Visible;
            if (main.tryb == 2 && ktore > 0)
            {
                main.previousQuestionEasy.Visibility = Visibility.Visible;

                if (ktore == 9)
                {
                    main.playEasyNextButton.Content = "Koniec";
                    end = true;
                }
                else
                {
                    main.playEasyNextButton.Content = "Dalej";
                    end = false;
                }
            }
            else if(main.tryb==1)
                {
                    if (point)
                        main.playMediumNextButton.Visibility = Visibility.Visible;
                    else
                        main.playMediumNextButton.Visibility = Visibility.Hidden;

                    if (ktore == 5)
                    {
                        main.learningOver.Visibility = Visibility.Visible;
                        main.gameEasy.Visibility = Visibility.Hidden;
                    }
                }

        }

        public override Answer GetQuestion()
        {
            return new Answer(question, correctAnswer, wrongAnswer, userAnswer, correctIndex);
        }

        override public void ShowQuestion(MainWindow main, Answer ans, int ktorePytanie)
        {
            ktore = ktorePytanie;

            this.question = ans.Question;
            this.correctAnswer = ans.CorrectAnswer;

            main.questionEasy.Content = question;

            correctIndex = ans.correctIndex;

            if (correctIndex == 0)
            {
                main.answerEasy1.Content = ans.CorrectAnswer;
                main.answerEasy2.Content = ans.AdditionalAnswers[0];
                main.answerEasy3.Content = ans.AdditionalAnswers[1];
            }

            else if (correctIndex == 1)
            {
                main.answerEasy2.Content = ans.CorrectAnswer;
                main.answerEasy1.Content = ans.AdditionalAnswers[0];
                main.answerEasy3.Content = ans.AdditionalAnswers[1];
            }

            else if (correctIndex == 2)
            {
                main.answerEasy3.Content = ans.CorrectAnswer;
                main.answerEasy1.Content = ans.AdditionalAnswers[0];
                main.answerEasy2.Content = ans.AdditionalAnswers[1];
            }

            //ans.UserAnswer - zaznaczyć button ; nie wiem czy dobrze
            main.answerEasy1.Background = Brushes.White;
            main.answerEasy2.Background = Brushes.White;
            main.answerEasy3.Background = Brushes.White;
            if (ans.UserAnswer == "e1")
                main.answerEasy1.Background = Brushes.Blue;
            else if (ans.UserAnswer == "e2")
                main.answerEasy2.Background = Brushes.Blue;
            else if (ans.UserAnswer == "e3")
                main.answerEasy3.Background = Brushes.Blue;

            point = false;
        }

        public void showNumber(MainWindow main)
        {
            main.questionNumEasy.Content = "Pytanie " + (ktore + 1).ToString() + "/10";
        }
    }
}
