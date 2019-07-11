using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
    class GetFirstPlayerWorkflow
    {
        Random random = new Random();
        public int Execute()
        {
            return random.Next(0, TicTacToeWorkflow.NUM_PLAYERS);
        }


        //public void PlayerFirst()
        //{
        //    int turn = random.Next(2);
        //    while (turn < 2)
        //    {
        //        if (turn == 0)
        //        {
        //            Console.WriteLine($"It's PLACEHOLDER1 turn!");
        //            Console.ReadKey();
        //            ++turn;
        //        }
        //        else
        //        {
        //            Console.WriteLine($"It's PLACEHOLDER2 turn!");
        //            Console.ReadKey();
        //            --turn;
        //        }
        //    }
        //}
    }
}
