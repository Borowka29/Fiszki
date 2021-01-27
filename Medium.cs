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
        private string userAnswer;
        public string[] wrongAnswer = new string[3];
        public int ktore { get; set; }
        private int[] indexy;
        private Random rand { get; set; } = new Random();
        public int correctIndex;

        override public void play(MainWindow main, Word[] tabWords, int ktorePytanie)
        {
            main.gameMedium.Visibility = Visibility.Visible;
            main.playMediumNextButton.Visibility = Visibility.Hidden;
            main.previousQuestionMedium.Visibility = Visibility.Hidden;

            ktore = ktorePytanie;
            showNumber(main);
            losuj();
            if (main.translationFromPolish == true)
            {
                this.question = tabWords[ktore].PolishVersion;
                this.correctAnswer = tabWords[ktore].EnglishVersion;
                this.wrongAnswer[0] = tabWords[indexy[0]].EnglishVersion;
                this.wrongAnswer[1] = tabWords[indexy[1]].EnglishVersion;
                this.wrongAnswer[2] = tabWords[indexy[2]].EnglishVersion;
            }
            else
            {
                this.question = tabWords[ktore].EnglishVersion;
                this.correctAnswer = tabWords[ktore].PolishVersion;
                this.wrongAnswer[0] = tabWords[indexy[0]].PolishVersion;
                this.wrongAnswer[1] = tabWords[indexy[1]].PolishVersion;
                this.wrongAnswer[2] = tabWords[indexy[2]].PolishVersion;
            }

            main.gameMedium.Visibility = Visibility.Visible;
            main.playMediumNextButton.Visibility = Visibility.Hidden;

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
            } while (indexy[0] == ktore || indexy[0] == indexy[1] || indexy[1] == ktore|| indexy[2]== indexy[1]|| indexy[2]== indexy[0]|| 
                     indexy[2]==ktore);
        }
        
        public override void check(string answer, MainWindow main)
        {

            if (correctIndex == 0)
            {
                if (answer == "m1")
                    point = true;
                else
                    point = false;
            }
            else if (correctIndex == 1)
            {
                if (answer == "m2")
                    point = true;
                else
                    point = false;
            }
            else if (correctIndex == 2)
            {
                if (answer == "m3")
                    point = true;
                else
                    point = false;
            }
            else if (correctIndex == 3)
            {
                if (answer == "m4")
                    point = true;
                else
                    point = false;
            }


            if (answer == "m1")
                userAnswer = main.answerMedium1.Content.ToString();
            else if (answer == "m2")
                userAnswer = main.answerMedium2.Content.ToString();
            else if (answer == "m3")
                userAnswer = main.answerMedium3.Content.ToString();
            else if (answer == "m4")
                userAnswer = main.answerMedium4.Content.ToString();



            if (main.tryb == 2)
            {
                main.playMediumNextButton.Visibility = Visibility.Visible; // "Dalej" staje się widoczny
                if(ktore > 0)
                    main.previousQuestionMedium.Visibility = Visibility.Visible; // "Cofnij" staje się widoczny

                if (ktore == 9)
                {
                    main.playMediumNextButton.Content = "Koniec";
                    end = true;
                }
                else
                {
                    main.playMediumNextButton.Content = "Dalej";
                    end = false;
                }
            }

            else if (main.tryb == 1)
            {
                if (point == true)
                {
                    main.playMediumNextButton.Visibility = Visibility.Visible;

                    if (ktore == 10)
                    {
                        main.learningOver.Visibility = Visibility.Visible;
                        main.gameMedium.Visibility = Visibility.Hidden;
                    }
                }
                else
                    main.playMediumNextButton.Visibility = Visibility.Hidden;
            }

        }

        public override Answer GetQuestion()
        {
            return new Answer(question, correctAnswer, wrongAnswer, userAnswer, correctIndex);
        }
        override public void ShowQuestion(MainWindow main, Answer ans, int ktorePytanie)
        {
            //ktore = ktorePytanie;

            this.question = ans.Question;
            this.correctAnswer = ans.CorrectAnswer;

            main.gameMedium.Visibility = Visibility.Visible;
            main.playMediumNextButton.Visibility = Visibility.Hidden;
            main.colorChange();

            main.questionEasy.Content = question;
            main.questionMedium.Content = question;

            correctIndex = ans.correctIndex;

            if (correctIndex == 0)
            {
                main.answerMedium1.Content = ans.CorrectAnswer;

                main.answerMedium2.Content = ans.AdditionalAnswers[0];
                main.answerMedium3.Content = ans.AdditionalAnswers[1];
                main.answerMedium4.Content = ans.AdditionalAnswers[2];
            }

            else if (correctIndex == 1)
            {
                main.answerMedium2.Content = ans.CorrectAnswer;

                main.answerMedium1.Content = ans.AdditionalAnswers[0];
                main.answerMedium3.Content = ans.AdditionalAnswers[1];
                main.answerMedium4.Content = ans.AdditionalAnswers[2];
            }

            else if (correctIndex == 2)
            {
                main.answerMedium3.Content = ans.CorrectAnswer;

                main.answerMedium1.Content = ans.AdditionalAnswers[0];
                main.answerMedium2.Content = ans.AdditionalAnswers[1];
                main.answerMedium4.Content = ans.AdditionalAnswers[2];
            }

            else if (correctIndex == 3)
            {
                main.answerMedium4.Content = ans.CorrectAnswer;

                main.answerMedium1.Content = ans.AdditionalAnswers[0];
                main.answerMedium2.Content = ans.AdditionalAnswers[1];
                main.answerMedium3.Content = ans.AdditionalAnswers[2];
            }
            /*
            //ans.UserAnswer - zaznaczyć button 
            main.answerMedium1.Background = Brushes.White;
            main.answerMedium2.Background = Brushes.White;
            main.answerMedium3.Background = Brushes.White;
            main.answerMedium4.Background = Brushes.White;
            if (ans.UserAnswer == "m1")
                main.answerMedium1.Background = Brushes.Blue;
            else if (ans.UserAnswer == "m2")
                main.answerMedium2.Background = Brushes.Blue;
            else if (ans.UserAnswer == "m3")
                main.answerMedium3.Background = Brushes.Blue;
            else if (ans.UserAnswer == "m4")
                main.answerMedium4.Background = Brushes.Blue;
            */

            point = false;
        }

        public void showNumber(MainWindow main)
        {
            main.questionNumMedium.Content = "Pytanie " + (ktore + 1).ToString() + "/10";
        }

        override public void next(MainWindow main)
        {
            main.playMediumNextButton.Visibility = Visibility.Hidden;
        }
    }
}