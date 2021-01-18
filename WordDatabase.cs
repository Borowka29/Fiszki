using Fiszki.DAL;
using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiszki
{
    public class WordDatabase
    {
        private static WordListContext db = new WordListContext();
        private List<Word> words;
        private WordDatabase() { words = db.Word.ToList(); }
        private static WordDatabase instance = new WordDatabase();
        public List<Word> get()
        {
            return words;
        }
        public void AddWord(string polishWord, string englishWord)
        {
            Word newWord = new Word();
            newWord.PolishVersion = polishWord;
            newWord.EnglishVersion = englishWord;
            words.Add(newWord);
        }
        public void EditWord(int id, string pol, string eng)
        {
            words.Where(z => z.IdWord == id).FirstOrDefault().PolishVersion=pol;
            words.Where(z => z.IdWord == id).FirstOrDefault().EnglishVersion = eng;
        }
        public void DeleteWord(Word word)
        {
            words.Remove(word);
        }
        public static WordDatabase GetWordDatabase()
        {
            return instance;
        }
    }
}
