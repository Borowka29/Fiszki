using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Fiszki
{
    public class TestMode
    {
        public bool end = false;

        private Answer Odp;
        public List<Snapshot> Historia { get; } = new List<Snapshot>();
        private Question Originator = new Question(); //aktualne Question
        private int Current = -1;
        private Strategia LevelOfDifficulty;
        private Word[] tabWords { get; set; }
        private Random rand { get; set; }
        private int któreQuestion { get; set; }

        public void setStrategia(Strategia strategia, List<Word> words)
        {
            rand = new Random();
            int ile = rand.Next(1, 2);
            int k = ile;
            tabWords = new Word[10];
            LevelOfDifficulty = strategia;

            for (int i = 0; i < tabWords.Length; i++)
            {
                tabWords[i] = words[k];
                k = k + ile;
            }
            któreQuestion = 0;

        }
        public void DrowACard(MainWindow main)
        {
            LevelOfDifficulty.next(main);
            this.LevelOfDifficulty.play(main, tabWords, któreQuestion);
            któreQuestion++;
        }
        public void check(string answer, MainWindow main)
        {
            if(Current == Historia.Count-1)//losuje Question
            {
                this.LevelOfDifficulty.check(answer, main);
                end = LevelOfDifficulty.end;
                Odp = this.LevelOfDifficulty.GetQuestion();
              //  this.ZapiszStan();

            }
            else//przechodzi do pytania po cofaniu się
            {
                Current++;
                Originator.SetSnapshot(Historia[Current]);
                this.LevelOfDifficulty.ShowQuestion(main, Originator.Odp, Current);
            }

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


            któreQuestion--;
            this.LevelOfDifficulty.play(main, tabWords, Current);
        }

    }
    public class Snapshot
    {
        public Answer Odp { get; }
        public Snapshot(Answer Odpowiedzi)
        {
            this.Odp = Odpowiedzi;
        }
    }

    class Question
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
