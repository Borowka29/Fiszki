﻿using Fiszki.DAL;
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
    public abstract class Strategia
    {
        public bool end;
        public bool point;
        public abstract void play(MainWindow main, Word[] tabWords, int ktorePytanie);
        public abstract void check(string answer, MainWindow main);
        public abstract Answer GetQuestion();
        public abstract void ShowQuestion(MainWindow main, Answer ans, int ktorePytanie);
        public abstract void next(MainWindow main);
    }

}
