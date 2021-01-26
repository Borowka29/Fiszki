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

        private List<Snapshot> Historia;
        private Pytanie Originator; //aktualne pytanie
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
        public void NextQuestion()
        {
            this.ZapiszStan();
            //losowanie pytania
        }

        public void ZapiszStan()
        {
            Historia.Add(Originator.CreateSnapshot(Odp));
            Current++;
        }

        public void Cofnij()
        {
            if (Current > 0)
            {
                Originator.SetSnapshot(Historia[Current]);
                Current--;
            }
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
        private Answer Odp;
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
