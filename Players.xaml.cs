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
using System.Windows.Shapes;

namespace TicTacToe_ver_3._0
{
    /// <summary>
    /// Logika interakcji dla klasy Players.xaml
    /// </summary>
    public partial class Players : Window
    {
        public Players()
        {
            InitializeComponent();
        }

        private void SavePlayers_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            if(txtBoxPlayer1.Text == string.Empty && txtBoxPlayer2.Text == string.Empty)
            {
                mainWindow.Player1.Content = "Player 1";
                mainWindow.Player2.Content = "Player 2";
                this.Close();

            }
            else
            {
                mainWindow.Player1.Content = txtBoxPlayer1.Text;
                mainWindow.Player2.Content = txtBoxPlayer2.Text;
                this.Close();

            }
       
        }
    }
}
