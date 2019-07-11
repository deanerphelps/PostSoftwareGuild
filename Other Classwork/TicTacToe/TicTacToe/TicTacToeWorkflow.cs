using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TicTacToe.BLL;

namespace TicTacToe.UI
{
    public class TicTacToeWorkflow
    {
        public const int NUM_PLAYERS = 2;
        private static Board _board;
        static IPlayer[] _players;

        static public void DisplayBoard()
        {
            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {
                    char displayChar;
                    int position = (col + 1) + 3 * row;
                    BoardStatus boardStatus = _board.GetPositionStatus(position);
                    switch (boardStatus)
                    {
                        case BoardStatus.none:
                            displayChar = position.ToString()[0];
                            break;

                        default:
                            displayChar = boardStatus.ToString()[0];
                            break;
                    }
                    Console.Write($"\t |{displayChar}| ");
                }
                Console.WriteLine();
            }
        }
        public void Stats(IPlayer player)
        {
            Console.WriteLine($"{player.Name} has {player.Wins} WINS, \n\tand {player.Losses} LOSSES! {player.Name} has also " +
                $"had {player.Ties} TIES!");
        }
        public void Execute()
        {
            GetFirstPlayerWorkflow gfpw = new GetFirstPlayerWorkflow();

            _board = new Board();
            _players = GetPlayerNamesWorkflow.Execute();
            int currentPlayer = gfpw.Execute();

            bool endOfGame = false;

            do
            {
                _board.Reset();
                DisplayBoard();
                MoveResult result;
                while (!endOfGame)
                { 
                    result = MakeMoveWorkflow.Execute(_board, _players[currentPlayer]);
                    DisplayBoard();
                    switch (result)
                    {
                        case MoveResult.Victory:
                            _players[currentPlayer].Wins++;
                            _players[(currentPlayer + 1) % 2].Losses++;
                            break;
                        case MoveResult.Draw:
                            endOfGame = true;
                            _players[0].Ties++;
                            _players[1].Ties++;
                            break;
                        default:
                            currentPlayer = (currentPlayer + 1) % 2;
                            break;
                    }
                }
               // Console.Clear();
                Stats(_players[0]);
                Stats(_players[1]);
                endOfGame = PlayAgainWorkflow.Execute();
            } while (endOfGame == true);
        }
    }
}
