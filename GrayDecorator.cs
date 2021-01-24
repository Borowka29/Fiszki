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
    public class GrayDecorator : Decorator
    {
        public override void changeColor(MainWindow main)
        {
            main.color = 0;
            foreach (Grid item in main.mainGrid.Children.OfType<Grid>())
            {
                item.Background = Brushes.White;
            }
            foreach (Button item in main.menu.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.highscore.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.start.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.settings.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.gameOver.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.gameEasy.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.gameMedium.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.gameHard.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.startInside.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.gameHardInside.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.easyAnswers.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
            foreach (Button item in main.mediumAnswers.Children.OfType<Button>())
            {
                item.Background = Brushes.LightGray;
            }
        }
    }
}
