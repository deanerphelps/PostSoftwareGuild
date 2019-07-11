using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    public class PlayAgainWorkflow
    {
        public static bool Execute()
        {
            return ConsoleInput.ConsoleInput.GetBoolFromUser("Would you like to play again?");
        }
    }
}
