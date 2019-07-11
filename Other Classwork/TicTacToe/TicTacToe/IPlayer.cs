using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
    public interface IPlayer
    {
        string Name { get; set; }
        int Wins { get; set; }
        int Losses { get; set; }
        int Ties { get; set; }

        PlayerLetter Letter { get; }

        int GetPosition();
    }
}
