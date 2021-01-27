using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Fiszki
{
    public class TestMode
    {
        private Answer Odp;

        private List<Snapshot> Historia = new List<Snapshot>();
        private Pytanie Originator = new Pytanie(); //aktualne pytanie
        private int Current = -1;
        private Strategia LeveOfDifficulty;
        private Word[] tabWords { get; set; }
        private Random rand { get; set; }
        private int którePytanie { get; set; }
        public void setStrategia(Strategia strategia, List<Word> words)
        {
            rand = new Random();
            int ile = rand.Next(1, 2);
            int k = ile;
            tabWords = new Word[4];
            LeveOfDifficulty = strategia;

            for (int i = 0; i < tabWords.Length; i++)
            {
                tabWords[i] = words[k];
                k = k + ile;
            }
            którePytanie = 0;

        }
        public void DrowACard(MainWindow main)
        {
            main.gameEasy.Visibility = Visibility.Visible;
            main.playEasyNextButton.Visibility = Visibility.Hidden;
            main.colorChange(main);
            this.LeveOfDifficulty.play(main, tabWords, którePytanie);
            którePytanie++;
        }
        public void check(string answer, MainWindow main)
        {
            if(Current == Historia.Count-1)//losuje pytanie
            {
                this.LeveOfDifficulty.check(answer, main);
                Odp = this.LeveOfDifficulty.GetQuestion();
                this.ZapiszStan();
            }
            else//przechodzi do pytania po cofaniu się
            {
                Current++;
                Originator.SetSnapshot(Historia[Current]);
                this.LeveOfDifficulty.ShowQuestion(main, Originator.Odp, Current);
            }

        }
        public void NextQuestion()
        {
            this.ZapiszStan();
        }

        public void ZapiszStan()
        {
            Historia.Add(Originator.CreateSnapshot(Odp));
            Current++;
        }

        public void Cofnij(MainWindow main)
        {
            if (Current > 0)
            {
                Originator.SetSnapshot(Historia[Current]);
                Current--;
            }
            /*
             * ogólnie działa ale nie wiem jak dodać przycisk żeby cofać
             * i jak potem zmienić żeby dało się zmieniać odpowiedzi
             * i żeby znowu pojawiał się przycisk dalej
             */
            this.LeveOfDifficulty.ShowQuestion(main, Originator.Odp, Current);
        }
    }
    class Snapshot
    {
        public Answer Odp { get; }
        public Snapshot(Answer Odpowiedzi)
        {
            this.Odp = Odpowiedzi;
        }
    }

    class Pytanie
    {
        public Answer Odp { get; set; }
        public Snapshot CreateSnapshot(Answer Odpowiedzi)
        {
            return new Snapshot(Odpowiedzi);
        }
        public void SetSnapshot(Snapshot s)
        {
            this.Odp = s.Odp;
        }
    }
}
