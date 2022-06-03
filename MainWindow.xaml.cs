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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
        }
        
        bool turnPlayer = false;
        bool endGame = false;
        int resultPlayer1 = 0, resultPlayer2 = 0;
        int counter = 0;

        Window2 window2 = new();
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            turnPlayer ^= true;

            if (button.Content == string.Empty)
            {
                button.Content = turnPlayer ? "X" : "O";
                counter++;
                CheckWin();
            } 
            if(CheckWin() == true)
            {
                if(turnPlayer == true)
                {
                    Result1.Content = ++resultPlayer1;
                    endGame = true;
                }
                else { Result2.Content = ++resultPlayer2; endGame = true;}
            }
            else if(counter ==9)
            {
                NewGame();
            }

            if(endGame == true)
            {
                window2.Show();
                NewGame();
            }    

        }

        private bool CheckWin()
        {
            
            if (btn00.Content == btn01.Content && btn01.Content == btn02.Content && btn00.Content != string.Empty)
            {
                btn00.Background = Brushes.Green;
                btn01.Background = Brushes.Green;
                btn02.Background = Brushes.Green;
                return true;

            }
            if(btn10.Content == btn11.Content && btn11.Content == btn12.Content && btn10.Content != string.Empty)
            {
                btn10.Background = Brushes.Green;
                btn11.Background = Brushes.Green;
                btn12.Background = Brushes.Green;
                return true;

            }
            if (btn20.Content == btn21.Content && btn21.Content == btn22.Content && btn20.Content != string.Empty)
            {
                btn20.Background = Brushes.Green;
                btn21.Background = Brushes.Green;
                btn22.Background = Brushes.Green;
                return true;

            }
            if (btn00.Content == btn10.Content && btn10.Content == btn20.Content && btn00.Content != string.Empty)
            {
                btn00.Background = Brushes.Green;
                btn10.Background = Brushes.Green;
                btn20.Background = Brushes.Green;
                return true;

            }
            if (btn01.Content == btn11.Content && btn11.Content == btn21.Content && btn01.Content != string.Empty)
            {
                btn01.Background = Brushes.Green;
                btn11.Background = Brushes.Green;
                btn21.Background = Brushes.Green;
                return true;

            }
            if (btn02.Content == btn12.Content && btn12.Content == btn22.Content && btn02.Content != string.Empty)
            {
                btn02.Background = Brushes.Green;
                btn12.Background = Brushes.Green;
                btn22.Background = Brushes.Green;
                return true;

            }
            if (btn00.Content == btn11.Content && btn11.Content == btn22.Content && btn00.Content != string.Empty)
            {
                btn00.Background = Brushes.Green;
                btn11.Background = Brushes.Green;
                btn22.Background = Brushes.Green;
                return true;

            }
            if (btn20.Content == btn11.Content && btn11.Content == btn02.Content && btn20.Content != string.Empty)
            {
                btn20.Background = Brushes.Green;
                btn11.Background = Brushes.Green;
                btn02.Background = Brushes.Green;
                return true;
            }
            else { return false; }
           
        }

        internal void NewGame()
        {
            turnPlayer = false;
            endGame = false;
            counter = 0;
            btn00.Content = string.Empty;
            btn01.Content = string.Empty;
            btn02.Content = string.Empty;

            btn10.Content = string.Empty;
            btn11.Content = string.Empty;
            btn12.Content = string.Empty;

            btn20.Content = string.Empty;
            btn21.Content = string.Empty;
            btn22.Content = string.Empty;

            //Reset Color
            btn00.Background = Brushes.White;
            btn01.Background = Brushes.White;
            btn02.Background = Brushes.White;

            btn10.Background = Brushes.White;
            btn11.Background = Brushes.White;
            btn12.Background = Brushes.White;

            btn20.Background = Brushes.White;
            btn21.Background = Brushes.White;
            btn22.Background = Brushes.White;
        }

    }
}
