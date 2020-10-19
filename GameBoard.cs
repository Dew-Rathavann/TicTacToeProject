using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameBoard
    {
        Player P = new Player();
        public const int BOARD_SIZE = 4;
        public Cell[,] Board;
        public GameBoard()
        {
            initializeBoard();
        }
        private void initializeBoard()
        {
            Board = new Cell[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Board[i, j] = new Cell();
                }
            }
        }
        public void printBoard()
        {
            const int ASCII_CODE_0 = 48;
            int fieldNumber = 1;
            Console.WriteLine("----------");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                { 
                    if (Board[i, j].isEmpty())
                        Console.Write((char)(ASCII_CODE_0 + fieldNumber));
                    else
                        Console.Write((char)(Board[i, j].getFieldState()));
                    fieldNumber++;

                    if (j < BOARD_SIZE - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("----------");
        }

        public void putMark(Player player, int fieldNumber)
        {

            int verticalY = (fieldNumber - 1) / 4;
            int horizontalX = (fieldNumber - 1) % 4;
            if (Board[verticalY, horizontalX].isEmpty())
            {
                Board[verticalY, horizontalX].markField(player);
            }

            else
            {
                Console.WriteLine("This place is taken. Select the field again: ");
                putMark(player, player.takeTurn());
            }
        }
        public bool checkWin(GameBoard gameBoard)
        {
            return (P.checkRowsForWin(gameBoard) || P.checkColumnsForWin(gameBoard) || P.checkDiagonalsForWin(gameBoard));
        }
        public void clearBoard()
        {
            Console.Clear();
        }
    }
}
