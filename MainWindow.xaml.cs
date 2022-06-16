using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;


namespace TicTacToe_ver_3._0
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Button> buttons;
        bool turnComputer = false;
        bool turnPlayer;
        public int counter = 0;
        int resultPlayer1 = 0, resultPlayer2 = 0;

        enum Player
        {
            Player1,
            Player2,
            Computer,
            X,
            O
        }
        private void PvP_Click(object sender, RoutedEventArgs e)
        {

            NewGame();
            turnComputer = false;
            Player1.Content = Player.Player1;
            Player2.Content = Player.Player2;
            SetScore();

        }


        private void PvE_Click(object sender, RoutedEventArgs e)
        {

            NewGame();
            turnComputer = true;
            Player1.Content = Player.Player1;
            Player2.Content = Player.Computer;
            SetScore();
        }
        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            SetScore();
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AllButtons()
        {
            buttons = new List<Button> { btn00, btn01, btn02, btn10, btn11, btn12, btn20, btn21, btn22 };

        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            turnPlayer ^= true;

            if (turnComputer)
            {

                if (button.Content == string.Empty)
                {

                    button.Content = Player.X;
                    counter++;
                    CheckOptions();
                    TurnComputer();
                    CheckOptions();
                }

            }

            else
            {
                if (button.Content == string.Empty)
                {
                    button.Content = turnPlayer ? Player.X : Player.O;
                    counter++;
                    CheckOptions();

                }

            }
        }

        //Turn Computer
        private bool TurnComputer()
        {

            DispatcherTimer timer = new DispatcherTimer();
            var turnComputer = new TurnComputer();
            timer.Start();
            if (turnComputer.AIGame(buttons)) { counter++; timer.Stop(); return true; }
            else { timer.Stop(); return false; }
        }
        private void EndGame()
        {
            var window1 = new Window1();
            window1.ShowDialog();
            NewGame();
        }
        private void NewGame()
        {

            AllButtons();
            foreach (var button in buttons)
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.IsEnabled = true;
            }
            counter = 0;
        }

        private bool Win(Button btA, Button btB, Button btC)
        {
            if (btA.Content == btB.Content && btB.Content == btC.Content && btA.Content != string.Empty && btB.Content != string.Empty && btC.Content != string.Empty)
            {
                if (btA.Content == "X")
                {
                    btA.Background = Brushes.Green;
                    btB.Background = Brushes.Green;
                    btC.Background = Brushes.Green;
                    ScorePl1.Content = ++resultPlayer1;
                    turnPlayer = false;
                    return true;
                }
                else
                {
                    btA.Background = Brushes.Green;
                    btB.Background = Brushes.Green;
                    btC.Background = Brushes.Green;
                    ScorePl2.Content = ++resultPlayer2;
                    turnPlayer = true;
                    return true;
                }

            }
            else { return false; }
        }

        private void CheckOptions()
        {

            if (Win(btn00, btn01, btn02)) { EndGame(); }
            else if (Win(btn10, btn11, btn12)) { EndGame(); }
            else if (Win(btn20, btn21, btn22)) { EndGame(); }
            else if (Win(btn00, btn10, btn20)) { EndGame(); }
            else if (Win(btn01, btn11, btn21)) { EndGame(); }
            else if (Win(btn02, btn12, btn22)) { EndGame(); }
            else if (Win(btn00, btn11, btn22)) { EndGame(); }
            else if (Win(btn02, btn11, btn20)) { EndGame(); }
            else if (counter == 9)
            {
                if (turnPlayer == true)
                {
                    turnPlayer = true;
                }
                else { turnPlayer = false; }
                NewGame();
            }
        }

        public void SetScore()
        {
            ScorePl1.Content = "0";
            ScorePl2.Content = "0";
        }

    }
}

