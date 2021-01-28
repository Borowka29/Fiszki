using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki
{
    public class Answer
    {
        //public Word Word { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string[] AdditionalAnswers { get; set; }
        public string UserAnswer { get; set; }
        public int correctIndex { get; set; }
        public Answer(string q, string a, string[] wrongAnswer, string user, int correctIndex)
        {
            this.Question = q;
            this.CorrectAnswer = a;
            this.UserAnswer = user;
            this.correctIndex = correctIndex;
            this.AdditionalAnswers = wrongAnswer;
        }

        //public void AddAdditionalAnswer(string Ans)
        //{
        //    this.AdditionalAnswers.Add(Ans);
        //}
    }
}
