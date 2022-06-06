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
using System.Windows.Threading;

namespace TicTacToe_ver_3._0
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        List<Button> buttons;
        bool playComputer = false;
        bool turnPlayer = false;
        int counter = 0;
        int resultPlayer1 = 0, resultPlayer2 = 0;
        
        private void PvP_Click(object sender, RoutedEventArgs e)
        {
           
            NewGame();
            playComputer = false;
            Player2.Content = "Player 2";
        }

        private void PvE_Click(object sender, RoutedEventArgs e)
        {
            
            NewGame();
            playComputer = true;
            Player2.Content = "Computer";
            
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AllButtons()
        {
            buttons = new List<Button> { btn00, btn01, btn02, btn10, btn11, btn12, btn20, btn21, btn22 };
;       }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            turnPlayer ^= true;

            if (playComputer)
            {

                if (button.Content == string.Empty)
                {
                    button.Content = "X";
                    counter++;
                    if (Win(btn00, btn01, btn02)) { EndGame(); }
                    else if (Win(btn10, btn11, btn12)) { EndGame(); }
                    else if (Win(btn20, btn21, btn22)) { EndGame(); }
                    else if (Win(btn00, btn10, btn20)) { EndGame(); }
                    else if (Win(btn01, btn11, btn21)) { EndGame(); }
                    else if (Win(btn02, btn12, btn22)) { EndGame(); }
                    else if (Win(btn00, btn11, btn22)) { EndGame(); }
                    else if (Win(btn02, btn11, btn20)) { EndGame(); }
                    else 
                    {
                        
                        DispatcherTime();
                        counter++;
                        if (Win(btn00, btn01, btn02)) { EndGame(); }
                        else if (Win(btn10, btn11, btn12)) { EndGame(); }
                        else if (Win(btn20, btn21, btn22)) { EndGame(); }
                        else if (Win(btn00, btn10, btn20)) { EndGame(); }
                        else if (Win(btn01, btn11, btn21)) { EndGame(); }
                        else if (Win(btn02, btn12, btn22)) { EndGame(); }
                        else if (Win(btn00, btn11, btn22)) { EndGame(); }
                        else if (Win(btn02, btn11, btn20)) { EndGame(); }
                    }
                }       

                if(counter == 9)
                {
                    NewGame();
                }
            }

            else
            {
                if (button.Content == string.Empty)
                {
                    button.Content = turnPlayer ? "X" : "O";

                    
                    counter++;
                    if (Win(btn00, btn01, btn02)) { EndGame(); }
                    if (Win(btn10, btn11, btn12)) { EndGame(); }
                    if (Win(btn20, btn21, btn22)) { EndGame(); }
                    if (Win(btn00, btn10, btn20)) { EndGame(); }
                    if (Win(btn01, btn11, btn21)) { EndGame(); }
                    if (Win(btn02, btn12, btn22)) { EndGame(); }
                    if (Win(btn00, btn11, btn22)) { EndGame(); }
                    if (Win(btn02, btn11, btn20)) { EndGame(); }
                }
                if(counter == 9)
                {
                    NewGame();
                }
                
            }
        }

        private bool DispatcherTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
           
            timer.Start();
            if (AIGame()) { timer.Stop(); return true; }
            else { timer.Stop(); return false; }
        }
        public void EndGame()
        {
            var window1 = new Window1();
            window1.ShowDialog();
            NewGame();
        }
        public void NewGame()
        {

            AllButtons();
            foreach(var button in buttons)
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.IsEnabled = true;
            }
            turnPlayer = false;
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
                    return true;
                }
                else
                {
                    btA.Background = Brushes.Green;
                    btB.Background = Brushes.Green;
                    btC.Background = Brushes.Green;
                    ScorePl2.Content = ++resultPlayer2;
                    return true;
                }
            }
            else { return false; }
        }


        private bool AIGame()
        {
            var aiGame = new Random();

            if (counter < 10)
            {
                if (CheckWinComputer(btn00, btn01, btn02)) { return true; }
                else if (CheckWinComputer(btn10, btn11, btn12)) { return true; }
                else if (CheckWinComputer(btn20, btn21, btn22)) { return true; }
                else if (CheckWinComputer(btn00, btn10, btn20)) { return true; }
                else if (CheckWinComputer(btn01, btn11, btn21)) { return true; }
                else if (CheckWinComputer(btn02, btn12, btn22)) { return true; }
                else if (CheckWinComputer(btn00, btn11, btn22)) { return true; }
                else if (CheckWinComputer(btn02, btn11, btn20)) { return true; }

                else if (CheckBlockPlayer(btn00, btn01, btn02)) { return true; }
                else if (CheckBlockPlayer(btn10, btn11, btn12)) { return true; }
                else if (CheckBlockPlayer(btn20, btn21, btn22)) { return true; }
                else if (CheckBlockPlayer(btn00, btn10, btn20)) { return true; }
                else if (CheckBlockPlayer(btn01, btn11, btn21)) { return true; }
                else if (CheckBlockPlayer(btn02, btn12, btn22)) { return true; }
                else if (CheckBlockPlayer(btn00, btn11, btn22)) { return true; }
                else if (CheckBlockPlayer(btn02, btn11, btn20)) { return true; }
                else
                {
                start:
                    int index = aiGame.Next(buttons.Count());
                    if (buttons[index].Content == string.Empty)
                    {
                        buttons[index].Content = "O";
                        return true;
                    }
                    else
                    {
                        goto start;
                    }

                }
            }
            else { return false; }

        }

        private bool CheckBlockPlayer(Button btA, Button btB, Button btC)
        {
            if (btA.Content == "X" && btA.Content == btB.Content && btA.Content != string.Empty && btB.Content != string.Empty && btC.Content == string.Empty)
            {
                btC.Content = "O";
                return true;
            }
            else if (btA.Content == "X" && btA.Content == btC.Content && btA.Content != string.Empty && btC.Content != string.Empty && btB.Content == string.Empty)
            {
                btB.Content = "O";
                return true;
            }
            else if (btC.Content == "X" && btC.Content == btB.Content && btC.Content != string.Empty && btB.Content != string.Empty && btA.Content == string.Empty)
            {
                btA.Content = "O";
                return true;
            }
            else { return false; }
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        

        private bool CheckWinComputer(Button btA, Button btB, Button btC)
        {
            if (btA.Content == "O" && btA.Content == btB.Content && btA.Content != string.Empty && btB.Content != string.Empty && btC.Content == string.Empty)
            {
                btC.Content = "O";
                return true;
            }
            else if (btA.Content == "O" && btA.Content == btC.Content && btA.Content != string.Empty && btC.Content != string.Empty && btB.Content == string.Empty)
            {
                btB.Content = "O";
                return true;
            }
            else if (btC.Content == "O" && btC.Content == btB.Content && btC.Content != string.Empty && btB.Content != string.Empty && btA.Content == string.Empty)
            {
                btA.Content = "O";
                return true;
            }
            else { return false; }
        }
    }
}

