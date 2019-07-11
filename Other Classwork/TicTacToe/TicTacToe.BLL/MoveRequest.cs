using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public struct MoveRequest
    {
        public PlayerLetter PlayerLetter { get; set; }
        public int MoveTarget { get; set; }
    }
}
