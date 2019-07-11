using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public PlayerLetter Letter { get; private set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        public Player(PlayerLetter playLetter)
        {
            Letter = playLetter;
        }

        public int GetPosition()
        {
            return ConsoleInput.ConsoleInput.GetIntFromUser("Enter a number from 1-9", 1, 9);
        }
    }
}
