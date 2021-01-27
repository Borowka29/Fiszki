using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Fiszki
{
    public class LearningMode
    {
        public Strategia LeveOfDifficulty { get; set; }
        private Word[] tabWords { get; set; }
        private Random rand { get; set; }
        public int którePytanie { get; set; }
        public void setStrategia(Strategia strategia, List<Word> words)
        {
            rand = new Random();
            int ile = rand.Next(1, 2);
            int k = ile;
            tabWords = new Word[5];
            LeveOfDifficulty = strategia;

            for(int i = 0; i < 5; i++)
            {
                tabWords[i] = words[k];
                k = k + ile;
            }
            którePytanie = 0;

        }
        public void DrowACard(MainWindow main)
        {
            if (którePytanie < tabWords.Length)
            {

            this.LeveOfDifficulty.play(main, tabWords,którePytanie);
            którePytanie++;
            }
            else
            {

                main.learningOver.Visibility = Visibility.Visible;
                main.gameMedium.Visibility = Visibility.Hidden;
            }
        }
        public void check(string answer, MainWindow main)
        {
            this.LeveOfDifficulty.check(answer, main);
        }
    }
}
