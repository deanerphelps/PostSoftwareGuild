using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
    public class Chicken : IPlayer
    {
        private Random _random;
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        public PlayerLetter Letter { get; private set; }

        public Chicken(PlayerLetter playerLetter)
        {
            Letter = playerLetter;
            _random = new Random();
        }

        public int GetPosition()
        {
            int _position = _random.Next(1, 10);
            Console.WriteLine(_position);
            return _position;
        }
    }
}
