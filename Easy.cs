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

        override public void play(MainWindow main, Word[] tabWords, int ktorePytanie) // inicjalizacja widoku gry, podpiecie zmiennych pod widok
        {

            main.gameEasy.Visibility = Visibility.Visible;              //| widok Gry
            main.playEasyNextButton.Visibility = Visibility.Hidden;     //| przycisk "Dalej" - jeszcze niewidoczny, bo nic nie zaznaczylismy
            main.previousQuestionEasy.Visibility = Visibility.Hidden;   //| przycisk "Cofnij" - jeszcze niewidoczny, bo nie przeszlismy dalej

            ktore = ktorePytanie;

            losuj();

            if (main.translationFromPolish == true) // przypisanie slowek do pól
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
            

            main.questionEasy.Content = question; // przypisanie slowka, o ktore pytamy

            correctIndex = rand.Next(3); // wylosowanie indexu, w ktorym bedzie poprawne tlumaczenie



            if (correctIndex == 0)  // przypisanie opowiedzi
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



            point = false; // poki co poprawne tlumaczenie nie zostalo zaznaczone
        }

        public void losuj() // losowanie blednych odpowiedzi
        {
            indexy = new int[2];
            do
            {
                indexy[0] = this.rand.Next(0, 11);
                indexy[1] = this.rand.Next(0, 11);

            } while (indexy[0] == ktore || indexy[0] == indexy[1] || indexy[1] == ktore);
        }

        public override void check(string answer, MainWindow main) // metoda wywolywana po zaznaczeniu odpowiedzi
        {
            if (correctIndex == 0) // sprawdzenie, czy zaznaczona odpowiedz jest prawidlowa
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


            if(answer=="e1") // zczytanie odpowiedzi z przycisku
                userAnswer = main.answerEasy1.Content.ToString();
            else if(answer=="e2")
                userAnswer = main.answerEasy2.Content.ToString();
            else if (answer == "e3")
                userAnswer = main.answerEasy3.Content.ToString();


            if (main.tryb == 2) // jesli to test
            {
                main.playEasyNextButton.Visibility = Visibility.Visible; // odpowiedz zaznaczona, wiec mozna przejsc dalej: przycisk "Dalej" widoczny
                
                if(ktore > 0) // jestesmy juz po pierwszym pytaniu wiec...
                    main.previousQuestionEasy.Visibility = Visibility.Visible; // ...mozna cofnac, wiec przycisk "Cofnij" widoczny

                if (ktore == 9) // to ostatnie pytanie, nastepne bedzie przejscie do gridu gameOver
                {
                    main.playEasyNextButton.Content = "Koniec"; // zmiana napisu na przycisku "Dalej"
                    end = true; // sygnal dla MainWindow
                }
                else
                {
                    main.playEasyNextButton.Content = "Dalej";
                    end = false;
                }
            }
            else if(main.tryb==1) // jesli nauka
                {
                    if (point) // jesli odpowiemy dobrze...
                        main.playEasyNextButton.Visibility = Visibility.Visible; // ...to przycisk "Dalej" jest dostepny
                    else // jesli odpowiemy zle...
                        main.playEasyNextButton.Visibility = Visibility.Hidden; // ...to przycisk "Dalej" znowu znika

                    if (ktore == 10) // jesli dotarlismy na koniec bazy
                    {
                        main.learningOver.Visibility = Visibility.Visible; // wyswietlamy grida z info, ze to koniec Nauki
                        main.gameEasy.Visibility = Visibility.Hidden;      // wylaczamy grida z Nauką
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

        public void showNumber(MainWindow main) // wyswietla info o numerze pytania w tescie
        {
            main.questionNumEasy.Content = "Pytanie " + (ktore + 1).ToString() + "/10";
        }

        override public void next(MainWindow main)
        {
            main.playEasyNextButton.Visibility = Visibility.Hidden;
        }
    }
}
