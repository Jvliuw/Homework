using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TicTacToeJohnLinehan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isX = true;
        int btnCounter = 0;
        string currentPlayer = "X";
        string buttonContent = string.Empty;
        List<Tuple<int, int, string>> btnPicked = new List<Tuple<int, int, string>>();
        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "O is up first";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = (sender as Button).Tag.ToString();

            buttonContent = currentPlayer;
            var thisTuple = new Tuple<int, int, string>((Convert.ToInt32(result[0].ToString())), (Convert.ToInt32(result[2].ToString())), buttonContent);

            btnPicked.Add(thisTuple);

            if (!isX)  //start with X
            {
                currentPlayer = "X";
                (sender as Button).Content = currentPlayer;
                uxTurn.Text = "O's turn";
            }
            else
            {
                currentPlayer = "O";
                (sender as Button).Content = currentPlayer;
                uxTurn.Text = "X's turn";
            }

            (sender as Button).IsEnabled = false;

            isX = !isX;  //toggle turn

            btnCounter++;

            if (btnCounter < 9)
            {
                if (CheckForWinHorz())
                {
                    uxTurn.Text = "we have a winner";
                    PlayAgain(sender);  //
                }

                if (CheckForWinVert())
                {
                    uxTurn.Text = "we have a winner";
                    PlayAgain(sender);
                }

                if (CheckForWinDiag())
                {
                    uxTurn.Text = "we have a winner";
                    PlayAgain(sender);
                }               
            }
            else
            {
                PlayAgain(sender);
            }
        }

        private void PlayAgain(object sender)
        {
            if (MessageBox.Show("Play Again?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                Close();
            }
            else
            {
                MainWindow main = new MainWindow();  // Could not get a uxNewGame click event to raise.
                main.Show();
                Close();
            }
        }

        private bool CheckForWinVert()
        {
            List<int> zeroCountX = new List<int>();
            List<int> oneCountX = new List<int>();
            List<int> twoCountX = new List<int>();
            List<int> zeroCountO = new List<int>();
            List<int> oneCountO = new List<int>();
            List<int> twoCountO = new List<int>();

            foreach (var item in btnPicked)
            {
                if (item.Item2 == 0)  //if the first tuple item is a zero (top row horizontal)
                {
                    if (item.Item3 == "X")  //and the current button picked is X
                    {
                        zeroCountX.Add(item.Item2); //add to firstCount list for X
                    }
                    else
                    {
                        zeroCountO.Add(item.Item2);//add to firstCount list for O
                    }
                }
                else if (item.Item2 == 1) //repeat for button who's first grid index is 1 (middle horizontal)
                {
                    if (item.Item3 == "X")
                    {
                        oneCountX.Add(item.Item2);
                    }
                    else
                    {
                        oneCountO.Add(item.Item2);
                    }
                }
                else
                {
                    if (item.Item3 == "X")
                    {
                        twoCountX.Add(item.Item2);
                    }
                    else
                    {
                        twoCountO.Add(item.Item2);
                    }
                }
            }//foreach

            if (zeroCountO.Count > 2)
            {
                return true;
            }
            else if (oneCountO.Count > 2)
            {
                return true;
            }
            else if (twoCountO.Count > 2)
            {
                return true;
            }
            else if (zeroCountX.Count > 2)
            {
                return true;
            }
            else if (oneCountX.Count > 2)
            {
                return true;
            }
            else if (twoCountX.Count > 2)
            {
                return true;
            }
            else
            {
                return false;
            }

            //return false;
        }
        private bool CheckForWinHorz()
        {
            List<int> zeroCountX = new List<int>();
            List<int> oneCountX = new List<int>();
            List<int> twoCountX = new List<int>();
            List<int> zeroCountO = new List<int>();
            List<int> oneCountO = new List<int>();
            List<int> twoCountO = new List<int>();

            foreach (var item in btnPicked)
            {
                if (item.Item1 == 0)  //if the first tuple item is a zero (top row horizontal)
                {
                    if (item.Item3 == "X")  //and the current button picked is X
                    {
                        zeroCountX.Add(item.Item1); //add to firstCount list for X
                    }
                    else
                    {
                        zeroCountO.Add(item.Item1);//add to firstCount list for O
                    }
                }
                else if (item.Item1 == 1) //repeat for button who's first grid index is 1 (middle horizontal)
                {
                    if (item.Item3 == "X")
                    {
                        oneCountX.Add(item.Item1);
                    }
                    else
                    {
                        oneCountO.Add(item.Item1);
                    }
                }
                else
                {
                    if (item.Item3 == "X")
                    {
                        twoCountX.Add(item.Item1);
                    }
                    else
                    {
                        twoCountO.Add(item.Item1);
                    }
                }
            }//foreach

            if (zeroCountO.Count > 2)
            {
                return true;
            }
            else if (oneCountO.Count > 2)
            {
                return true;
            }
            else if (twoCountO.Count > 2)
            {
                return true;
            }
            else if (zeroCountX.Count > 2)
            {
                return true;
            }
            else if (oneCountX.Count > 2)
            {
                return true;
            }
            else if (twoCountX.Count > 2)
            {
                return true;
            }
            else
            {
                return false;
            }

            //return false;
        }
        private bool CheckForWinDiag()
        {
            List<int> DiagDownCountX = new List<int>();
            List<int> DiagUpCountX = new List<int>();
            List<int> DiagDownCountO = new List<int>();
            List<int> DiagUpCountO = new List<int>();

            foreach (var item in btnPicked)
            {
                if (item.Item1 == 1 && item.Item2 == 1)  //if the first tuple item is a zero (top row horizontal)
                {
                    if (item.Item3 == "X")
                    {
                        DiagDownCountX.Add(item.Item1);  //add center square
                        DiagDownCountO.Add(item.Item1);
                    }
                    else
                    {
                        DiagUpCountX.Add(item.Item1);  //add center square
                        DiagUpCountO.Add(item.Item1);
                    }
                }

                if (item.Item1 == 0 && item.Item2 == 0)  //check top left
                {
                    if (item.Item3 == "X")
                    {
                        DiagDownCountX.Add(item.Item1);
                    }
                    else
                    {
                        DiagDownCountO.Add(item.Item1);
                    }
                }

                if (item.Item1 == 2 && item.Item2 == 2)  //check bottom right
                {
                    if (item.Item3 == "X")
                    {
                        DiagDownCountX.Add(item.Item1);
                    }
                    else
                    {
                        DiagDownCountO.Add(item.Item1);
                    }
                }

                if (item.Item1 == 0 && item.Item2 == 2)  //check top right
                {
                    if (item.Item3 == "X")
                    {
                        DiagUpCountX.Add(item.Item1);
                    }
                    else
                    {
                        DiagUpCountO.Add(item.Item1);
                    }
                }

                if (item.Item1 == 2 && item.Item2 == 0) //check bottom left
                {
                    if (item.Item3 == "X")
                    {
                        DiagUpCountX.Add(item.Item1);
                    }
                    else
                    {
                        DiagUpCountO.Add(item.Item1);
                    }
                }
            }//foreach

            if (DiagUpCountO.Count > 2)
            {
                return true;
            }
            if (DiagUpCountX.Count > 2)
            {
                return true;
            }
            if (DiagDownCountO.Count > 2)
            {
                return true;
            }
            if (DiagDownCountX.Count > 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }//method

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void E_xit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }//class
}//namespace
