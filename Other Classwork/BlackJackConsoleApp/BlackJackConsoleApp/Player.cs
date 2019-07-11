using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Player
    {
        public string Name { get; set; }
        public decimal Bankroll { get; set; }
        public int Wager { get; set; }
        public Hand Hand { get; private set; }

        public Player()
        {
            Hand = new Hand();
        }
    }
}
