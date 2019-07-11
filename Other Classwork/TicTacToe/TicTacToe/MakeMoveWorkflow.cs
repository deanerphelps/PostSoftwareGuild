using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
    public class MakeMoveWorkflow
    {
        //The flow for how each player makes their moves. Calls the correct turn/player and calls the valid input method
        public static MoveResult Execute(Board board, IPlayer player)
        {
            MoveResult response;
            Console.WriteLine($"{player.Name}, it's your turn..");
            do
            {
                Console.WriteLine($"{player.Name}, where would you like to move?");

                int position = player.GetPosition();

                MoveRequest request = new MoveRequest()
                {
                    MoveTarget = position,
                    PlayerLetter = player.Letter
                };
                response = board.MakeMove(request);
            } while (response == MoveResult.Invalid || response == MoveResult.Unavailable); 

            return response;
        }
    }
}
