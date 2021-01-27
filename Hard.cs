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

        override public void play(MainWindow main, Word[] tabWords, int ktorePytanie)
        {
            main.answerHard.Text = "";                                //| przy kazdym nowym pytaniu zerujemy zawartosc TextBoxa na odpowiedz
            main.gameHard.Visibility = Visibility.Visible;            //| grid Gry widoczny
            main.playHardNextButton.Visibility = Visibility.Hidden;   //| przycisk "Dalej" niedostępny
            main.previousQuestionHard.Visibility = Visibility.Hidden; //| przycisk "Cofnij" niedostepny

            ktore = ktorePytanie;

            if (main.translationFromPolish == true) // sprawdzenie kierunku tlumaczenia pl-ang
            {
                this.question = tabWords[ktore].PolishVersion;
                this.correctAnswer = tabWords[ktore].EnglishVersion;
            }
            else
            {
                this.question = tabWords[ktore].EnglishVersion;
                this.correctAnswer = tabWords[ktore].PolishVersion;
            }


            main.questionHard.Content = question; // frontend - przypisanie slowka do przetlumaczenia
        }

        public override void check(string answer, MainWindow main)
        {
            if (main.answerHard.Text == correctAnswer) // jesli odpowiedz w TextBoxie = poprawnej odpowiedzi... <-- TU TRZEBA BREAKPOINT!
                point = true;
            else
                point = false;

            userAnswer = main.answerHard.Text; // zczytaj odpowiedz z TextBoxa (zeby zapisac do pamiatki)

            if (main.tryb == 2) // jesli to test
            {
                main.playHardNextButton.Visibility = Visibility.Visible; // odpowiedz zaznaczona, wiec mozna przejsc dalej: przycisk "Dalej"

                if (ktore > 0) // jestesmy juz po pierwszym pytaniu wiec...
                    main.previousQuestionHard.Visibility = Visibility.Visible; // ...mozna cofnac, wiec przycisk "Cofnij" widoczny

                if (ktore == 9) // to ostatnie pytanie, nastepne bedzie przejscie do gridu gameOver
                {
                    main.playHardNextButton.Content = "Koniec"; // zmiana napisu na przycisku "Dalej"
                    end = true; // sygnal dla MainWindow
                }
                else
                {
                    main.playHardNextButton.Content = "Dalej";
                    end = false;
                }
            }
            else if (main.tryb == 1) // jesli nauka
            {
                if (point) // jesli odpowiedzielismy dobrze...
                    main.playHardNextButton.Visibility = Visibility.Visible; // ...to przycisk "Dalej" jest widoczny
                else // jesli odpowiemy zle...
                    main.playHardNextButton.Visibility = Visibility.Hidden; // ...to przycisk "Dalej" znowu znika

                if (ktore == 10) // jesli dotarlismy na koniec bazy
                {
                    main.learningOver.Visibility = Visibility.Visible; // wyswietlamy grida z info, ze to koniec Nauki
                    main.gameHard.Visibility = Visibility.Hidden;      // wylaczamy grida z Nauką
                }
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

        override public void next(MainWindow main)
        {
            main.playHardNextButton.Visibility = Visibility.Hidden;
        }
    }
}