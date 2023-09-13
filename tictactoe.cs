using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            InitializeBoard();

            do
            {
                DisplayBoard();
                Console.Write($"Player {currentPlayer}, enter row and column (ex., 1 2): ");
                string[] input = Console.ReadLine().Split();
                int row = int.Parse(input[0]) - 1; //for array ; if user enter 2 computer gets 1
                int col = int.Parse(input[1]) - 1;

                if (IsValidMove(row, col))
                {
                    board[row, col] = currentPlayer;
                    if (CheckForWin())
                    {
                        DisplayBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                    else if (IsBoardFull())
                    {
                        DisplayBoard();
                        Console.WriteLine("It's a draw!");
                        break;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }

            } while (true);
            Console.ReadKey();
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void DisplayBoard()
        {
            Console.Clear();
            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine($" {board[row, 0]} | {board[row, 1]} | {board[row, 2]} ");
                if (row < 2)
                {
                    Console.WriteLine("---|---|---");
                }
            }
        }

        static bool IsValidMove(int row, int col)
        {
            return (row >= 0 && row < 3) && (col >= 0 && col < 3) && (board[row, col] == ' ');
        }

        static bool CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true;
                }
            }
            //checking diagonals
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        static bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
