using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki
{
    class Hard : Strategia
    {
        public string question;
        public string correctAnswer;

        override public void play()
        {
            this.question = readQuestion(0);
            this.correctAnswer = readAnswer(0);
        }

        public string readQuestion(int index)
        {
            string q="";
            // <--- zczytanie pytania z pliku
            return q;
        }

        public string readAnswer(int index)
        {
            string a="";
            // <--- zczytanie odpowiedzi z pliku
            return a;
        }
    }
}
