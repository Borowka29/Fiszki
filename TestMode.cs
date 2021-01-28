using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Fiszki
{
    public class TestMode
    {
        public bool end = false;

        public Answer Odp;
        public List<Snapshot> Historia;
        private Question Originator; //aktualne Question
        private int Current;
        private Strategia LevelOfDifficulty;
        private Word[] tabWords { get; set; }
        private Random rand { get; set; }
        private int któreQuestion { get; set; }

        public void setStrategia(Strategia strategia, List<Word> words)
        {
            Current = -1;
            Historia = new List<Snapshot>();
            Originator = new Question();
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
            if (Current >= 0) // jestesmy juz po pierwszym pytaniu wiec...
                            main.previousQuestionEasy.Visibility = Visibility.Visible;
             else
                            main.previousQuestionEasy.Visibility = Visibility.Hidden;
            
            if (Current==Historia.Count-1)
            {
                if (!end)
                    this.LevelOfDifficulty.play(main, tabWords, któreQuestion++);

            }
            else
            {
                //Current++;
                Originator.SetSnapshot(Historia[Current]);
                this.LevelOfDifficulty.ShowQuestion(main, Originator.Odp, Current+1);
            }
            
        }
        public void check(string answer, MainWindow main)
        {
            this.LevelOfDifficulty.check(answer, main);
            end = LevelOfDifficulty.end;
            Odp = this.LevelOfDifficulty.GetQuestion();

        }

        public void ZapiszStan()
        {
            var question = Historia.FirstOrDefault(x => x.Odp?.Question == Odp.Question);
            if(question == null)
            {
                Historia.Add(Originator.CreateSnapshot(Odp));
            }
            else
            {
                var index = Historia.FindIndex(x => x.Odp.Question == Odp.Question);
                Historia[index] = Originator.CreateSnapshot(Odp);
            }
            Current++;
        }

        public void Cofnij(MainWindow main)
        {

            if (Current >= 0)
            {
                Originator.SetSnapshot(Historia[Current]);
                Current--;
                if (Current >= 0) 
                    main.previousQuestionEasy.Visibility = Visibility.Visible;
                else
                    main.previousQuestionEasy.Visibility = Visibility.Hidden;
                this.LevelOfDifficulty.ShowQuestion(main, Originator.Odp, któreQuestion);
                
            }
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
