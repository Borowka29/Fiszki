using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki
{
    public class Answer
    {
        public Word Word { get; set; }
        //public string Eng { get; set; }
        //public string Pl { get; set; }
        List<string> AdditionalAnswers;
        public string UserAnswer { get; set; }

        public void AddAdditionalAnswer(string Ans)
        {
            this.AdditionalAnswers.Add(Ans);
        }
    }
}
