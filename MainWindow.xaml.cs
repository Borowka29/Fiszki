using Fiszki.DAL;
using Fiszki.Models;
using Microsoft.EntityFrameworkCore;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double difficult { get; set; }
        public int color { get; set; } 
        private string[] colorList = { "szary", "różowy", "niebieski", "zielony", "krejzolski" };
        public bool isBold { get; set; }
        private Baza Baza { get; set; }
        public Account User { get; set; }
        private static LearningMode learningMode { get; set; }
        private static TestMode testMode { get; set; }
        public Decorator decorator;
        public List<Word> ListOfWords { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            colorSetter.ItemsSource = colorList;
            Login.Visibility = Visibility.Visible;
            learningMode = new LearningMode();
            testMode = new TestMode();
            //colorSetter.SelectedItem = colorList[color];
            Baza = Baza.GetInstance();
        }

        private void Difficult_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /* 1. easy
             * 2. medium
             * 3. hard
             */

            difficult = difficultSetter.Value;
        }

        private void colorSetter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            colorChange(this);
        }

        public void colorChange(MainWindow main)
        {

            /* 1. szary
             * 2. rozowy
             * 3. niebieski
             * 4. zielony
             * 5. krejzolski
             */

            if (colorSetter.SelectedItem.ToString() == "szary")
            {
                decorator = new GrayDecorator();
                decorator.changeColor(main);
            }
            else if (colorSetter.SelectedItem.ToString() == "różowy")
            {
                decorator = new PinkDecorator();
                decorator.changeColor(main);
            }
            else if (colorSetter.SelectedItem.ToString() == "niebieski")
            {
                decorator = new BlueDecorator();
                decorator.changeColor(main);
            }
            else if (colorSetter.SelectedItem.ToString() == "zielony")
            {
                decorator = new GreenDecorator();
                decorator.changeColor(main);
            }
            else if (colorSetter.SelectedItem.ToString() == "krejzolski")
            {
                decorator = new UglyDecorator();
                decorator.changeColor(main);
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
            changeDatabaseWords.Visibility = Visibility.Hidden;
            settings.Visibility = Visibility.Hidden;
            gameOver.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Hidden;

            gameEasy.Visibility = Visibility.Hidden;
            gameMedium.Visibility = Visibility.Hidden;
            gameHard.Visibility = Visibility.Hidden;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Visible;
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            settings.Visibility = Visibility.Visible;
        }

        private void changeDatabaseWords_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            changeDatabaseWords.Visibility = Visibility.Visible;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Baza.updateDataUser(User.Id, difficult, color, isBold);
            //User.LevelHard = difficult;
            //User.Color = color;
            //User.IsBold =isBold;
            //db.Attach(User).State = EntityState.Modified;
            //db.SaveChanges();
            Close();
        }
        private int tryb;
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (sender == naukaButton)
            {
                tryb = 1;
                questionNumEasy.Visibility = Visibility.Hidden;
                questionNumMedium.Visibility = Visibility.Hidden;
                questionNumHard.Visibility = Visibility.Hidden;
            }
            else
            {
                tryb = 2;
                questionNumEasy.Visibility = Visibility.Visible;
                questionNumMedium.Visibility = Visibility.Visible;
                questionNumHard.Visibility = Visibility.Visible;
            }

            switch (difficult)
            {
                case 0:
                    if(tryb==1)  learningMode.setStrategia(new Easy(),Baza.getListWord());
                    else testMode.setStrategia(new Easy(), Baza.getListWord());
                    break;

                case 1:
                    if (tryb == 1) learningMode.setStrategia(new Medium(), Baza.getListWord());
                    else testMode.setStrategia(new Medium(), Baza.getListWord());
                    break;

                case 2:
                    if (tryb == 1) learningMode.setStrategia(new Hard(), Baza.getListWord());
                    else testMode.setStrategia(new Hard(), Baza.getListWord());
                    break;
            }

            start.Visibility = Visibility.Hidden;
            if (tryb == 1)
                learningMode.DrowACard(this);
            else
                testMode.DrowACard(this);
        }

        private void answer_Click(object sender, RoutedEventArgs e)
        {
            
            if (playEasyNextButton.Visibility == Visibility.Hidden)
            {
                if (tryb == 1)
                {
                    if (sender == answerEasy1)
                        learningMode.check("e1", this);
                    else if (sender == answerEasy2)
                        learningMode.check("e2", this);
                    else if (sender == answerEasy3)
                        learningMode.check("e3", this);
                    else if (sender == answerMedium1)
                        learningMode.check("m1", this);
                    else if (sender == answerMedium2)
                        learningMode.check("m2", this);
                    else if (sender == answerMedium3)
                        learningMode.check("m3", this);
                    else if (sender == answerMedium4)
                        learningMode.check("m4", this);
                    else if (sender == answerHard)
                        learningMode.check("h", this);
                }
                else
                {
                    if (sender == answerEasy1)
                        testMode.check("e1", this);
                    else if (sender == answerEasy2)
                        testMode.check("e2", this);
                    else if (sender == answerEasy3)
                        testMode.check("e3", this);
                    else if (sender == answerMedium1)
                        testMode.check("m1", this);
                    else if (sender == answerMedium2)
                        testMode.check("m2", this);
                    else if (sender == answerMedium3)
                        testMode.check("m3", this);
                    else if (sender == answerMedium4)
                        testMode.check("m4", this);
                    else if (sender == answerHard)
                        testMode.check("h", this);
                }
                    
            }

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

            if (sender == playEasyNextButton)
                playEasyNextButton.Visibility = Visibility.Hidden;
            else if (sender == playMediumNextButton)
                playMediumNextButton.Visibility = Visibility.Hidden;
            else if (sender == playMediumNextButton)
            {
                playHardNextButton.Visibility = Visibility.Hidden;
                nextHard.Visibility = Visibility.Visible;
            }
            if(tryb==1 && learningMode.którePytanie<4)
            {
                learningMode.DrowACard(this);

            }
            if (tryb != 1)
            {
                testMode.DrowACard(this);

            }
        }

        private void boldCheck_Checked(object sender, RoutedEventArgs e)
        {
            decorator = new BoldDecorator();
            decorator.changeColor(this);
        }

        private void boldCheck_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Zaloguj_Click(object sender, RoutedEventArgs e)
        {
            userLogin.ClearValue(TextBox.BorderBrushProperty);
            userPassword.ClearValue(TextBox.BorderBrushProperty);
            string login = userLogin.Text;

            if (login=="")
            {
                userLogin.BorderBrush = Brushes.Red;

                return;
            }
            string password = userPassword.Password.ToString();
            
            User = Baza.getUserData(login);//db.Account.Where(p => p.Username == login).FirstOrDefault();

            if (User != null)
            {

                if (User.Password == password)
                {
                    Login.Visibility = Visibility.Collapsed;
                    menu.Visibility = Visibility.Visible;
                    difficult = User.LevelHard;
                    isBold = User.IsBold;
                    color = User.Color;
                    userLogin.Text = "";
                    userPassword.Password = "";
                    return;
                }

                userPassword.BorderBrush = Brushes.Red;
                return;
            }
            Wynik.Content = "Podany użytkownik nie istnieje!";
            Wynik.Visibility = Visibility.Visible;
            return;
        }

        private void Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            Login.Visibility = Visibility.Collapsed;
            Rejestracja.Visibility = Visibility.Visible;
        }

        private void RejestracjaOK_Click(object sender, RoutedEventArgs e)
        {
            bool udałoSie = false;
            Account NewUser = new Account();
            string password = userPasswordR.Password.ToString();
            if (userLoginR.Text!="" && password != "")
            {
                udałoSie= Baza.createNewUser(userLoginR.Text, password);
                //NewUser.Username = userLoginR.Text;
                //NewUser.Password = password;
                //NewUser.LevelHard = 1;
                //NewUser.Color = 1;
                //NewUser.IsBold = false;
                //db.Account.Add(NewUser);
                //db.SaveChanges();

            }
            else
            {
                WynikR.Content = "Nie wypełniłeś danych!";
                WynikR.Visibility = Visibility.Visible;
            }
            if (udałoSie == true)
            {
                colorSetter.SelectedItem = colorList[color];
                Rejestracja.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Visible;
            }
            else
            {
                WynikR.Content = "Login jest już zajęty!";
                WynikR.Visibility = Visibility.Visible;
            }
        }
        public bool translationFromPolish;
        int i = 1;
        private void Btn1_Checked(object sender, RoutedEventArgs e)
        {
            if (i != 1)
            {
                if (angpol.IsChecked == true) translationFromPolish = false;
                else translationFromPolish = true;
            }
            i = 2;

        }
        private void Refresh()
        {
            ListOfWords = Baza.getListWordLocal();
            WordsListView.ItemsSource = ListOfWords;
        }
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            changeDatabaseWords.Visibility = Visibility.Hidden;
            CreateWords.Visibility = Visibility.Visible;

            if (succesfullAddWord)
            {
                succesfullAddWord = false;
            }
        }
        private bool succesfullEditWord;
        private Word EditWord;
        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            EditWord = WordsListView.SelectedItem as Word;
            polishTranslationEdit.Text = EditWord.PolishVersion;
            englishTranslationEdit.Text = EditWord.EnglishVersion;

            changeDatabaseWords.Visibility = Visibility.Hidden;
            EditWords.Visibility = Visibility.Visible;
            if (succesfullEditWord)
            {
                succesfullEditWord = false;
            }
        }

        private void UsuńButton_Click(object sender, RoutedEventArgs e)
        {
            Word word = WordsListView.SelectedItem as Word;
            if (word != null)
            {
                Baza.deleteWord(word);
                Refresh();
            }
        }

        private void KategorieListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WordsListView.SelectedItem != null)
            {
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
            else
            {
                EditButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }
        private bool succesfullAddWord;
        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(polishTranslation.Text) && !string.IsNullOrEmpty(englishTranslation.Text))
            {
                Baza.addeWord(polishTranslation.Text, englishTranslation.Text);
                changeDatabaseWords.Visibility = Visibility.Visible;
                CreateWords.Visibility = Visibility.Hidden;
                polishTranslation.Text = "";
                englishTranslation.Text = "";
                succesfullAddWord = true;
                Refresh();
            }
        }

        private void CancelAddWordButton_Click(object sender, RoutedEventArgs e)
        {
            changeDatabaseWords.Visibility = Visibility.Visible;
            CreateWords.Visibility = Visibility.Hidden;
        }

        private void EditWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(polishTranslationEdit.Text) && !string.IsNullOrEmpty(englishTranslationEdit.Text))
            {
                Baza.updateWord(EditWord.Id, polishTranslationEdit.Text, englishTranslationEdit.Text);
                changeDatabaseWords.Visibility = Visibility.Visible;
                EditWords.Visibility = Visibility.Hidden;
                polishTranslationEdit.Text = "";
                englishTranslationEdit.Text = "";
                succesfullEditWord = true;
                Refresh();
            }
        }

        private void CancelEditWordButton_Click(object sender, RoutedEventArgs e)
        {
            changeDatabaseWords.Visibility = Visibility.Visible;
            EditWords.Visibility = Visibility.Hidden;
        }
    }
}
