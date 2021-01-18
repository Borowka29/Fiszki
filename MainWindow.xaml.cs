using Fiszki.DAL;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double difficult = 0;
        private int color = 0;
        private string[] colorList = { "szary", "różowy", "niebieski", "zielony", "krejzolski" };
        public string settingsTxt;
        public bool isDiacriticalSigns;
        public bool questionsCounting;

        private Strategia s;
        public MainWindow()
        {
            InitializeComponent();
            /* W settings.txt sa 2 wiersze z 0/1
             *      1. wiersz to poziom trudnosci
             *      2. wiersz to wersja kolorystyczna
             * Wrzucam to do pliku, zeby pamietalo ustawienia przy kolejnych wlaczeniach programu.
             */
            WordDatabase df = WordDatabase.GetWordDatabase();
            /*settingsTxt = File.ReadAllText(@"C:\Users\user\source\repos\ztp_projekt_fiszki\ztp_projekt_fiszki\settings\settings.txt");

            for (int i = 0; i < 8; i++)
                    {
                        while (i < 3)
                            if (settingsTxt[i] == '1') difficult = i;
                        while (i > 2)
                            if (settingsTxt[i] == '1') color = i - 3;
                        if (settingsTxt[i] == '1') isDiacriticalSigns = true;
                    }*/

            colorSetter.ItemsSource = colorList;
            colorSetter.SelectedItem = colorList[color];
        }

        private void playMain()
        {
            s.play();
        }

        private void Difficult_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /* 1. easy
             * 2. medium
             * 3. hard
             */

            difficult = difficultSetter.Value;

            // JESZCZE TRZEBA ZMIENIC W PLIKU
        }

        private void colorSetter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* 1. szary
             * 2. rozowy
             * 3. niebieski
             * 4. zielony
             * 5. krejzolski
             */

            if (colorSetter.SelectedItem.ToString() == "szary")
            {
                color = 0;
                foreach (Grid item in this.mainGrid.Children.OfType<Grid>())
                {
                    item.Background = Brushes.White;
                }
                foreach (Button item in this.menu.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.highscore.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.start.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.settings.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.gameOver.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.gameEasy.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.gameMedium.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.gameHard.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
                foreach (Button item in this.startInside.Children.OfType<Button>())
                {
                    item.Background = Brushes.LightGray;
                }
            }
            else if (colorSetter.SelectedItem.ToString() == "różowy")
            {
                color = 1;
                foreach (Grid item in this.mainGrid.Children.OfType<Grid>())
                {
                    item.Background = Brushes.Pink;
                }
                foreach (Button item in this.menu.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.highscore.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.start.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.settings.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.gameOver.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.gameEasy.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.gameMedium.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.gameHard.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
                foreach (Button item in this.startInside.Children.OfType<Button>())
                {
                    item.Background = Brushes.HotPink;
                }
            }
            else if (colorSetter.SelectedItem.ToString() == "niebieski")
            {
                color = 2;
                foreach (Grid item in this.mainGrid.Children.OfType<Grid>())
                {
                    item.Background = Brushes.LightBlue;
                }
                foreach (Button item in this.menu.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.highscore.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.start.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.settings.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.gameOver.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.gameEasy.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.gameMedium.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.gameHard.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
                foreach (Button item in this.startInside.Children.OfType<Button>())
                {
                    item.Background = Brushes.Azure;
                }
            }
            else if (colorSetter.SelectedItem.ToString() == "zielony")
            {
                color = 3;
                foreach (Grid item in this.mainGrid.Children.OfType<Grid>())
                {
                    item.Background = Brushes.LightGreen;
                }
                foreach (Button item in this.menu.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.highscore.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.start.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.settings.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.gameOver.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.gameEasy.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.gameMedium.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.gameHard.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
                foreach (Button item in this.startInside.Children.OfType<Button>())
                {
                    item.Background = Brushes.Lime;
                }
            }
            else if (colorSetter.SelectedItem.ToString() == "krejzolski")
            {
                color = 4;
                foreach (Grid item in this.mainGrid.Children.OfType<Grid>())
                {
                    item.Background = Brushes.Red;
                }
                foreach (Button item in this.menu.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.highscore.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.start.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.settings.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.gameOver.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.gameEasy.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.gameMedium.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.gameHard.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
                foreach (Button item in this.startInside.Children.OfType<Button>())
                {
                    item.Background = Brushes.Blue;
                }
            }

            // JESZCZE TRZEBA ZMIENIC W PLIKU
        }

        private void diacriticalMarksCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (isDiacriticalSigns)
                isDiacriticalSigns = false;
            else
                isDiacriticalSigns = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
            highscore.Visibility = Visibility.Hidden;
            settings.Visibility = Visibility.Hidden;
            gameOver.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Hidden;
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

        private void highScoreButton_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            highscore.Visibility = Visibility.Visible;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (sender == naukaButton)
                questionsCounting = true;
            else
                questionsCounting = false;

            switch (difficult)
            {
                case 0:
                    this.s = new Easy();
                    gameEasy.Visibility = Visibility.Visible;
                    break;

                case 1:
                    this.s = new Medium();
                    gameMedium.Visibility = Visibility.Visible;
                    break;

                case 2:
                    this.s = new Hard();
                    gameHard.Visibility = Visibility.Visible;
                    break;
            }

            s.play();
        }
    }
}