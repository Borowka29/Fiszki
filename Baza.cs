using Fiszki.DAL;
using Fiszki.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiszki
{
    public class Baza
    {
        private static WordListContext db { get; set; }
        private Baza()
        {
            db = new WordListContext();
        }
        private static Baza instance;
        public static Baza GetInstance()
        {
            if (instance == null)
            {
                instance = new Baza();
            }
            return instance;
        }
        public static List<Word> getListWordLocal()
        {
            db.Word.Load();
            List<Word> localDatabase = db.Word.Local.ToList();
            return localDatabase;
        }
        public static List<Word> getListWord()
        {
            return db.Word.ToList();
        }
        public static void deleteWord(Word wordd)
        {
            Word word = db.Word.Where(z => z == wordd).FirstOrDefault();
            db.Word.Remove(word);
            db.SaveChanges();
        }
        public static void updateWord(int id,string pol, string ang)
        {
            Word word = db.Word.Where(z => z.Id == id).FirstOrDefault();
            word.PolishVersion = pol;
            word.EnglishVersion = ang;
            db.Attach(word).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void addeWord(string pol, string ang)
        {
            Word word = new Word();
            word.PolishVersion = pol;
            word.EnglishVersion = ang;
            db.Word.Add(word);
            db.SaveChanges();
        }
        public static Account getUserData(string userName)
        {
            return db.Account.Where(z => z.Username == userName).FirstOrDefault();

        }
        public static bool createNewUser(string userName, string password)
        {
            Account NewUser = new Account();
            NewUser.Username = userName;
            NewUser.Password = password;
            NewUser.LevelHard = 1;
            NewUser.Color = 1;
            if(db.Account.Where(p=>p.Username==userName).ToList().Count==0)
            {
                db.Account.Add(NewUser);
                db.SaveChanges();
                return true;
            }
            return false;
            
        }
        public static void updateDataUser(int id, double difficult, int color)
        {
            Account User = db.Account.Where(z => z.Id == id).FirstOrDefault();
            User.LevelHard = difficult;
            User.Color = color;
            db.Attach(User).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
