﻿using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Fiszki
{
    public class LearningMode
    {
        public Strategia LevelOfDifficulty { get; set; }
        private Word[] tabWords { get; set; }
        private Random rand { get; set; }
        public int którePytanie { get; set; }
        public void setStrategia(Strategia strategia, List<Word> words)
        {
            rand = new Random();
            int ile = rand.Next(1, 2);
            int k = ile;
            tabWords = new Word[12];
            LevelOfDifficulty = strategia;

            for(int i = 0; i < 12; i++)
            {
                tabWords[i] = words[k];
                k = k + ile;
            }
            którePytanie = 0;

        }
        public void DrowACard(MainWindow main)
        {
            LevelOfDifficulty.next(main);
            if (którePytanie < tabWords.Length)
            {
                którePytanie++;

                this.LevelOfDifficulty.play(main, tabWords,którePytanie);
            }
            else
            {

                main.learningOver.Visibility = Visibility.Visible;
                main.gameMedium.Visibility = Visibility.Hidden;
            }

        }
        public void check(string answer, MainWindow main)
        {
            this.LevelOfDifficulty.check(answer, main);
        }
    }
}
