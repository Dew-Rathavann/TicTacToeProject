using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        public TicTacToe()
        {
            play();
        }
        public void play()
        {
            GameBoard gameBoard = new GameBoard();
            /*Player playerX = new Player('X');
            Player playerO = new Player('O');
            Player playerC = new Player('C');*/
            Player[] players = new Player[4];
            players[0] = new Player('X');
            players[1] = new Player('O'); 
            players[2] = new Player('C');
            while (true)
            {
                for (int i = 0; i < players.Length; i++)
                {

                }
 
            }
            Player currentPlayer = players[0];
            int moveCounter = 0;
            bool play = true;
            while (play)
            {
                gameBoard.printBoard();
                Console.WriteLine("Player: {0} Enter the field in which you want to put the character: ", currentPlayer.getSign());
                try
                {
                    gameBoard.putMark(currentPlayer, players[0].takeTurn());
                    //gameBoard.checkWin();
                    gameBoard.clearBoard();
                    moveCounter++;
                    if (currentPlayer.checkWin(gameBoard))
                    {
                        Console.WriteLine("Player: {0} won!", currentPlayer.getSign());
                        gameBoard.printBoard();
                        play = false;
                    }
                    else if (checkDraw(moveCounter))
                    {
                        Console.WriteLine("DRAW");
                        gameBoard.printBoard();
                        play = false;
                    }
                    for (int i = 0; i < players.Length; i++)
                    {
                        currentPlayer = changeCurrentPlayer(currentPlayer, players[i]);
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input. Please enter number between 1-16!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        /*private Player changeCurrentPlayer(Player currentPlayer, Player playerX, Player playerO, Player playerC)
        {
            return currentPlayer == playerX ? playerO : currentPlayer == playerO ? playerC : playerX;
        }*/
        private bool checkDraw(int turnCounter)
        {
            if (turnCounter == 16)
                return true;
            return false;
        }
    }
}

