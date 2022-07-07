using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        private static readonly char[] Arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static int _player = 1;
        private static int _choice; 
        private static int _flag = 0;

        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                Console.WriteLine(_player % 2 == 0 ? "Player 2 Chance" : "Player 1 Chance");
                Console.WriteLine("\n");
                Board();
                _choice = int.Parse(Console.ReadLine()!);
                
                if (Arr[_choice] != 'X' && Arr[_choice] != 'O')
                {
                    if (_player % 2 == 0)
                    {
                        Arr[_choice] = 'O';
                        _player++;
                    }
                    else
                    {
                        Arr[_choice] = 'X';
                        _player++;
                    }
                }
                else
                    
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", _choice, Arr[_choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                _flag = CheckWin();
            }
            while (_flag != 1 && _flag != -1);
           
            Console.Clear();
            Board();
            if (_flag == 1)
            
            {
                Console.WriteLine("Player {0} has won", (_player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Arr[1], Arr[2], Arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Arr[4], Arr[5], Arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Arr[7], Arr[8], Arr[9]);
            Console.WriteLine("     |     |      ");
        }
        //Checking that any player has won or not
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row
            if (Arr[1] == Arr[2] && Arr[2] == Arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row
            else if (Arr[4] == Arr[5] && Arr[5] == Arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row
            else if (Arr[6] == Arr[7] && Arr[7] == Arr[8])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (Arr[1] == Arr[4] && Arr[4] == Arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column
            else if (Arr[2] == Arr[5] && Arr[5] == Arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column
            else if (Arr[3] == Arr[6] && Arr[6] == Arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (Arr[1] == Arr[5] && Arr[5] == Arr[9])
            {
                return 1;
            }
            else if (Arr[3] == Arr[5] && Arr[5] == Arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match
            else if (Arr[1] != '1' && Arr[2] != '2' && Arr[3] != '3' && Arr[4] != '4' && Arr[5] != '5' && Arr[6] != '6' && Arr[7] != '7' && Arr[8] != '8' && Arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}
