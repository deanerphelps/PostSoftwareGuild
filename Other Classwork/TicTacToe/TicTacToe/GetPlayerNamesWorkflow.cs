using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;
using ConsoleInput;

namespace TicTacToe.UI
{
    public class GetPlayerNamesWorkflow
    {
        public static IPlayer[] Execute()
        {
            IPlayer[] players = new IPlayer[TicTacToeWorkflow.NUM_PLAYERS];

            for (int i = 0; i < players.Length; ++i)
            {
                string name = ConsoleInput.ConsoleInput.GetStringFromUser($"What is the {(PlayerLetter)i} player's name?");

                if (name.Equals("chicken", StringComparison.CurrentCultureIgnoreCase))
                {
                    players[i] = new Chicken((PlayerLetter)i);
                }
                else
                {
                    players[i] = new Player((PlayerLetter)i);
                }
                players[i].Name = name;
            }
            return players;
        }


        //Player[] playerNames = new Player[2];
        //public void PlayerNamesInput()
        //{
        //    Player player1 = new Player();
        //    Player player2 = new Player();

        //    player1.Name = ConsoleInput.ConsoleInput.GetStringFromUser("Player 1, please enter your name...");
        //    player1.Letter = PlayLetter.X;
        //    player2.Name = ConsoleInput.ConsoleInput.GetStringFromUser("Player 2, please enter your name...");
        //    player2.Letter = PlayLetter.O;
        //    playerNames[0] = player1;
        //    playerNames[1] = player2;
        }
    
}
//player = new Player()
//{
//    Name = ConsoleInput.ConsoleInput.GetStringFromUser("Please enter your name...")
//            };
//            return player;
