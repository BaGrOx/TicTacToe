using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe_ver_3._0
{
    public class TurnComputer : MainWindow
    {
        enum ContentPLayer
        { 
            X,
            O
        }

        public bool AIGame(List<Button> buttonList)
        {
            
            var randomNumer = new Random();
            if (counter < 10)
            {
                if (CheckWinComputer(btn00, btn01, btn02)) { return true; }
                else if (CheckWinComputer(buttonList[0], buttonList[1], buttonList[2])) { return true; }
                else if (CheckWinComputer(buttonList[3], buttonList[4], buttonList[5])) { return true; }
                else if (CheckWinComputer(buttonList[6], buttonList[7], buttonList[8])) { return true; }
                else if (CheckWinComputer(buttonList[0], buttonList[3], buttonList[6])) { return true; }
                else if (CheckWinComputer(buttonList[1], buttonList[4], buttonList[7])) { return true; }
                else if (CheckWinComputer(buttonList[2], buttonList[5], buttonList[8])) { return true; }
                else if (CheckWinComputer(buttonList[0], buttonList[4], buttonList[8])) { return true; }
                else if (CheckWinComputer(buttonList[2], buttonList[4], buttonList[6])) { return true; }

                else if (CheckBlockPlayer(buttonList[0], buttonList[1], buttonList[2])) { return true; }
                else if (CheckBlockPlayer(buttonList[3], buttonList[4], buttonList[5])) { return true; }
                else if (CheckBlockPlayer(buttonList[6], buttonList[7], buttonList[8])) { return true; }
                else if (CheckBlockPlayer(buttonList[0], buttonList[3], buttonList[6])) { return true; }
                else if (CheckBlockPlayer(buttonList[1], buttonList[4], buttonList[7])) { return true; }
                else if (CheckBlockPlayer(buttonList[2], buttonList[5], buttonList[8])) { return true; }
                else if (CheckBlockPlayer(buttonList[0], buttonList[4], buttonList[8])) { return true; }
                else if (CheckBlockPlayer(buttonList[2], buttonList[4], buttonList[6])) { return true; }
                else
                {
                    while (true)
                    {
                        int index = randomNumer.Next(buttonList.Count());
                        if (buttonList[index].Content == string.Empty)
                        {
                            buttonList[index].Content = ContentPLayer.O;
                            return true;
                        }
                    }
                    
                }
            }
            else { return false; }

        }

        private bool CheckBlockPlayer(Button btA, Button btB, Button btC)
        {
            if (btA.Content == "X" && btA.Content == btB.Content && btA.Content != string.Empty && btB.Content != string.Empty && btC.Content == string.Empty)
            {
                btC.Content = ContentPLayer.O;
                return true;
            }
            else if (btA.Content == "X" && btA.Content == btC.Content && btA.Content != string.Empty && btC.Content != string.Empty && btB.Content == string.Empty)
            {
                btB.Content = ContentPLayer.O;
                return true;
            }
            else if (btC.Content == "X" && btC.Content == btB.Content && btC.Content != string.Empty && btB.Content != string.Empty && btA.Content == string.Empty)
            {
                btA.Content = ContentPLayer.O;
                return true;
            }
            else { return false; }
        }

        private bool CheckWinComputer(Button btA, Button btB, Button btC)
        {
            if (btA.Content == "O" && btA.Content == btB.Content && btA.Content != string.Empty && btB.Content != string.Empty && btC.Content == string.Empty)
            {
                btC.Content = ContentPLayer.O;
                return true;
            }
            else if (btA.Content == "O" && btA.Content == btC.Content && btA.Content != string.Empty && btC.Content != string.Empty && btB.Content == string.Empty)
            {
                btB.Content = ContentPLayer.O;
                return true;
            }
            else if (btC.Content == "O" && btC.Content == btB.Content && btC.Content != string.Empty && btB.Content != string.Empty && btA.Content == string.Empty)
            {
                btA.Content = ContentPLayer.O;
                return true;
            }
            else { return false; }
        }
    }
}
