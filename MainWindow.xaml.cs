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
        private double difficult { get; set; } //tymczasowy poziom trudnosci
        public int color { get; set; } // tymczasowy uklad kolorystyczny
        private string[] colorList = { "szary", "różowy", "niebieski", "zielony", "paskudny" }; //lista kolorow do combo boxa

        private Baza Baza { get; set; } // baza slowek i uzytkownikow
        public Account User { get; set; } // obecnie zalogowany uzytkownik
        private static LearningMode learningMode { get; set; } // obiekt trybu NAUKA
        private static TestMode testMode { get; set; }         // obiekt trybu TEST
        public Color decorator; // abstrakcyjny dekorator (bedzie potem przypisany w funkcji colorChange()
        public List<Word> ListOfWords { get; set; } // przepisana na tymczasowo baza slowek

        private bool succesfullAddWord; // ???
        private bool succesfullEditWord;// ???
        private Word EditWord;          // ???

        public int tryb; //1- nauka, 2-test

        public bool translationFromPolish;  // true - tlumaczy pl->ang;      false - tlumaczy ang->pl

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            colorSetter.ItemsSource = colorList;
            Login.Visibility = Visibility.Visible;
            learningMode = new LearningMode();
            testMode = new TestMode();

            Baza = Baza.GetInstance();
            Refresh();
        }

        private void Difficult_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /* 1. easy
             * 2. medium
             * 3. hard
             */

            difficult = difficultSetter.Value;  //|    zczytanie wartosci z settera do zmiennej tymczasowej
            User.LevelHard = difficult;         //|    przekazanie wartości tymczasowej do bazy danych (przypisanie do uzytkownika)
        }

        private void colorSetter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            colorChange();      //| ponowne uruchomienie klasy zarządzającej dekoratorami
            User.Color = color; //| wpisanie nowego koloru do bazy (przypisanie do uzytkownika)
        }

        public void colorChange()
        {

            /* 1. szary
             * 2. rozowy
             * 3. niebieski
             * 4. zielony
             * 5. jakiś paskudny
             */

            if (colorSetter.SelectedItem.ToString() == "szary")
            {
                decorator = new GrayDecorator();
                decorator.changeColor(this);
            }
            else if (colorSetter.SelectedItem.ToString() == "różowy")
            {
                decorator = new PinkDecorator();
                decorator.changeColor(this);
            }
            else if (colorSetter.SelectedItem.ToString() == "niebieski")
            {
                decorator = new BlueDecorator();
                decorator.changeColor(this);
            }
            else if (colorSetter.SelectedItem.ToString() == "zielony")
            {
                decorator = new GreenDecorator();
                decorator.changeColor(this);
            }
            else if (colorSetter.SelectedItem.ToString() == "paskudny")
            {
                decorator = new UglyDecorator();
                decorator.changeColor(this);
            }

        }




        private void BackButton_Click(object sender, RoutedEventArgs e) // cofnięcie się z dowolnego grida do menu
        {
            menu.Visibility = Visibility.Visible;                   //| jedyny grid, ktory bedzie widoczny po cofnieciu sie do menu
            changeDatabaseWords.Visibility = Visibility.Hidden;     //| cala reszta ukryta     
            settings.Visibility = Visibility.Hidden;
            gameOver.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Hidden;
            learningOver.Visibility = Visibility.Hidden;

            gameEasy.Visibility = Visibility.Hidden;
            gameMedium.Visibility = Visibility.Hidden;
            gameHard.Visibility = Visibility.Hidden;
        }

        private void startButton_Click(object sender, RoutedEventArgs e) // przjeście z menu do gridu z wyborem trybu
        {
            menu.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Visible;
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e) // przjeście z menu do gridu z ustawieniami
        {
            menu.Visibility = Visibility.Hidden;
            settings.Visibility = Visibility.Visible;
        }

        private void changeDatabaseWords_Click(object sender, RoutedEventArgs e) // przjeście z menu do gridu z bazą słówek
        {
            menu.Visibility = Visibility.Hidden;
            changeDatabaseWords.Visibility = Visibility.Visible;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e) // wyjscie z aplikacji
        {
            Baza.updateDataUser(User.Id, difficult, color); // update bazy, zeby po ponownym otwarciu przywrocilo obecne ustawienia
            Close();
        }




        private void Start_Click(object sender, RoutedEventArgs e)  // przejscie z gridu Start do wlasciwej Gry(Nauka/Test)
        {
            if (sender == naukaButton) // zaczynamy nauke, wiec nr pytan sa niepotrzebne
            {
                tryb = 1;
                questionNumEasy.Visibility = Visibility.Hidden;
                questionNumMedium.Visibility = Visibility.Hidden;
                questionNumHard.Visibility = Visibility.Hidden;
            }
            else // zaczynamy tst, wiec nr pytan sa potrzebne
            {
                tryb = 2;
                questionNumEasy.Visibility = Visibility.Visible;
                questionNumMedium.Visibility = Visibility.Visible;
                questionNumHard.Visibility = Visibility.Visible;
            }

            switch (difficult) // PRZYPISANIE STRATEGII
            {
                case 0: // easy
                    if(tryb==1)  
                        learningMode.setStrategia(new Easy(),Baza.getListWord());
                    else 
                        testMode.setStrategia(new Easy(), Baza.getListWord());
                    break;

                case 1: // medium
                    if (tryb == 1) 
                        learningMode.setStrategia(new Medium(), Baza.getListWord());
                    else 
                        testMode.setStrategia(new Medium(), Baza.getListWord());
                    break;

                case 2: // hard
                    if (tryb == 1) 
                        learningMode.setStrategia(new Hard(), Baza.getListWord());
                    else 
                        testMode.setStrategia(new Hard(), Baza.getListWord());
                    break;
            }

            start.Visibility = Visibility.Hidden; // schowanie gridu Start
            if (tryb == 1)
                learningMode.DrowACard(this); // wlaczenie gridu i odpalenie Nauki
            else
                testMode.DrowACard(this);     // wlaczenie gridu i odpalenie Testu
        }

        private void answer_Click(object sender, RoutedEventArgs e) // klikniecie ktorejs odpowiedzi lub "sprawdz" w trybie hard
        {
            
                string senderString = null;

                if (sender == answerEasy1) // zmiana sendera (klasa: object) na string [bo jak wysle sender do funkcji, to w funckji juz
                    senderString = "e1";   //                      nie wie, ze to klasa button, czyli klasa dziedziczaca z klasy object]
                else if (sender == answerEasy2)
                    senderString = "e2";
                else if (sender == answerEasy3)
                    senderString = "e3";
                else if (sender == answerMedium1)
                    senderString = "m1";
                else if (sender == answerMedium2)
                    senderString = "m2";
                else if (sender == answerMedium3)
                    senderString = "m3";
                else if (sender == answerMedium4)
                    senderString = "m4";
                else if (sender == nextHard)
                    senderString = "h";


                if (tryb == 1)
                    learningMode.check(senderString, this);
                else
                    testMode.check(senderString, this);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) // klikniecie przycisku "dalej" w Nauce/Tescie
        {
            if (testMode.end)   // koniec testu
            {
                gameEasy.Visibility = Visibility.Hidden; // niezaleznie od poziomu zamykamy Test
                gameMedium.Visibility = Visibility.Hidden;
                gameHard.Visibility = Visibility.Hidden;

                gameOver.Visibility = Visibility.Visible; // pokazujemy widok Konca Testu

                TestAnwers.ItemsSource=testMode.Historia;   // TO CHYBA TRZEBA BEDZIE WYRZUCIC I WSTAWIC WYNIK

                return;
            }

            if (tryb==1 && sender!=nextHard)
            {
                learningMode.DrowACard(this);

            }
            if (tryb == 2 && sender!=nextHard)
            {
                testMode.ZapiszStan();
                testMode.DrowACard(this); 
            }
        }

        private void Previous_Click(object sender, RoutedEventArgs e) // cofanie (pamiatka) w tescie
        {
            testMode.Cofnij(this);
        }



        private void Zaloguj_Click(object sender, RoutedEventArgs e) // logowanie
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
            
            User = Baza.getUserData(login); //db.Account.Where(p => p.Username == login).FirstOrDefault();

            if (User != null)
            {

                if (User.Password == password)
                {
                    Login.Visibility = Visibility.Collapsed;
                    menu.Visibility = Visibility.Visible;
                    difficult = User.LevelHard;
                    color = User.Color;
                    userLogin.Text = "";
                    userPassword.Password = "";

                    colorSetter.SelectedItem = colorList[color];
                    difficultSetter.Value = difficult;
                    colorChange();

                    return;
                }

                userPassword.BorderBrush = Brushes.Red;
                return;
            }
            Wynik.Content = "Podany użytkownik nie istnieje!";
            Wynik.Visibility = Visibility.Visible;

            return;
        }

        private void Rejestracja_Click(object sender, RoutedEventArgs e) // rejstracja
        {
            Login.Visibility = Visibility.Collapsed;
            Rejestracja.Visibility = Visibility.Visible;
        }

        private void RejestracjaOK_Click(object sender, RoutedEventArgs e) // ?????????
        {
            bool udałoSie = false;
            Account NewUser = new Account();
            string password = userPasswordR.Password.ToString();
            if (userLoginR.Text!="" && password != "")
            {
                udałoSie= Baza.createNewUser(userLoginR.Text, password);

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




        private void Btn1_Checked(object sender, RoutedEventArgs e) // zmiana kierunku tlumaczenia pl-ang
        {
            int i = 1;
            if (i != 1)
            {
                if (angpol.IsChecked == true) translationFromPolish = false;
                else translationFromPolish = true;
            }
            i = 2;

        }

        private void Refresh() // update bazy danych
        {
            ListOfWords = Baza.getListWordLocal();
            WordsListView.ItemsSource = ListOfWords;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e) // odpalenie grida AddWord
        {
            changeDatabaseWords.Visibility = Visibility.Hidden;
            CreateWords.Visibility = Visibility.Visible;

            if (succesfullAddWord)
            {
                succesfullAddWord = false;
            }
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e) // odpalenie grida EditWord
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

        private void UsuńButton_Click(object sender, RoutedEventArgs e) // usuwanie slow w bazie
        {
            Word word = WordsListView.SelectedItem as Word;
            if (word != null)
            {
                Baza.deleteWord(word);
                Refresh();
            }
        }

        private void KategorieListView_SelectionChanged(object sender, SelectionChangedEventArgs e) // wybor slowa z listy
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

        private void AddWordButton_Click(object sender, RoutedEventArgs e) // dodawanie slowa do bazy
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

        private void CancelAddWordButton_Click(object sender, RoutedEventArgs e) // cofnij dodawanie slowa do bazy
        {
            changeDatabaseWords.Visibility = Visibility.Visible;
            CreateWords.Visibility = Visibility.Hidden;
        }

        private void EditWordButton_Click(object sender, RoutedEventArgs e) // edytowanie slowa w bazie
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

        private void CancelEditWordButton_Click(object sender, RoutedEventArgs e) // cofnij edycje
        {
            changeDatabaseWords.Visibility = Visibility.Visible;
            EditWords.Visibility = Visibility.Hidden;
        }
    }
}
