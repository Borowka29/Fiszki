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
    class BoldDecorator : Decorator
    {
        public override void changeColor(MainWindow main)
        {
            main.startButton.FontWeight = FontWeights.Bold;
            main.settingsButton.FontWeight = FontWeights.Bold;
            main.databaseWordButton.FontWeight = FontWeights.Bold;
            main.quitButton.FontWeight = FontWeights.Bold;
            main.playEasyBackButton.FontWeight = FontWeights.Bold;
            main.playMediumBackButton.FontWeight = FontWeights.Bold;
            main.playHardBackButton.FontWeight = FontWeights.Bold;
            main.playEasyNextButton.FontWeight = FontWeights.Bold;
            main.playMediumNextButton.FontWeight = FontWeights.Bold;
            main.playHardNextButton.FontWeight = FontWeights.Bold;
            main.nextHard.FontWeight = FontWeights.Bold;
            main.questionEasy.FontWeight = FontWeights.Bold;
            main.questionMedium.FontWeight = FontWeights.Bold;
            main.questionHard.FontWeight = FontWeights.Bold;
            main.questionNumEasy.FontWeight = FontWeights.Bold;
            main.questionNumMedium.FontWeight = FontWeights.Bold;
            main.questionNumMedium.FontWeight = FontWeights.Bold;
            main.boldLabel.FontWeight = FontWeights.Bold;
            main.colorLabel.FontWeight = FontWeights.Bold;
            main.colorSetter.FontWeight = FontWeights.Bold;
            main.difficultLabel.FontWeight = FontWeights.Bold;
            main.startBackButton.FontWeight = FontWeights.Bold;
            main.naukaButton.FontWeight = FontWeights.Bold;
            main.testButton.FontWeight = FontWeights.Bold;
            main.typeLabel.FontWeight = FontWeights.Bold;
            main.settingsBackButton.FontWeight = FontWeights.Bold;
            main.answerEasy1.FontWeight = FontWeights.Bold;
            main.answerEasy2.FontWeight = FontWeights.Bold;
            main.answerEasy3.FontWeight = FontWeights.Bold;
            main.answerMedium1.FontWeight = FontWeights.Bold;
            main.answerMedium2.FontWeight = FontWeights.Bold;
            main.answerMedium3.FontWeight = FontWeights.Bold;
            main.answerMedium4.FontWeight = FontWeights.Bold;
            main.answerHard.FontWeight = FontWeights.Bold;
        }
    }
}
