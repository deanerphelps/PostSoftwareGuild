using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Dealer
    {
        public string Name { get; set; }
        public Hand Hand { get; private set; }

        public Dealer()
        {
            Hand = new Hand();
        }
    }
}
