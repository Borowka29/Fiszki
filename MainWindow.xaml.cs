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
        private double difficult = 0;   //trzeba do bazy zapisac
        public int color = 0;           //trzeba do bazy zapisac
        private string[] colorList = { "szary", "różowy", "niebieski", "zielony", "krejzolski" };
        public string settingsTxt;
        public bool isBold;
        public bool questionsCounting;
        public WordDatabase df = WordDatabase.GetWordDatabase();

        private Strategia strategia;
        public Decorator decorator;


        public MainWindow()
        {
            InitializeComponent();

            colorSetter.ItemsSource = colorList;
            colorSetter.SelectedItem = colorList[color];
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

            // JESZCZE TRZEBA ZMIENIC W PLIKU
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
            highscore.Visibility = Visibility.Hidden;
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
            {
                questionsCounting = false;
                questionNumEasy.Visibility = Visibility.Hidden;
                questionNumMedium.Visibility = Visibility.Hidden;
                questionNumHard.Visibility = Visibility.Hidden;
            }
            else
            {
                questionsCounting = true;
                questionNumEasy.Visibility = Visibility.Visible;
                questionNumMedium.Visibility = Visibility.Visible;
                questionNumHard.Visibility = Visibility.Visible;
            }

            switch (difficult)
            {
                case 0:
                    this.strategia = new Easy();
                    break;

                case 1:
                    this.strategia = new Medium();
                    break;

                case 2:
                    this.strategia = new Hard();
                    break;
            }

            start.Visibility = Visibility.Hidden;
            strategia.play(this);
        }

        private void answer_Click(object sender, RoutedEventArgs e)
        {
            
            if (playEasyNextButton.Visibility == Visibility.Hidden)
            {
                if (sender == answerEasy1)
                    strategia.check("e1", this);
                else if (sender == answerEasy2)
                    strategia.check("e2", this);
                else if (sender == answerEasy3)
                    strategia.check("e3", this);
                else if (sender == answerMedium1)
                    strategia.check("m1", this);
                else if (sender == answerMedium2)
                    strategia.check("m2", this);
                else if (sender == answerMedium3)
                    strategia.check("m3", this);
                else if (sender == answerMedium4)
                    strategia.check("m4", this);
                else if (sender == answerHard)
                    strategia.check("h", this);
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

            strategia.play(this);
        }

        private void boldCheck_Checked(object sender, RoutedEventArgs e)
        {
            decorator = new BoldDecorator();
            decorator.changeColor(this);
        }

        private void boldCheck_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
