using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeWorkflow execute = new TicTacToeWorkflow();
            execute.Execute();
            Console.ReadKey();
        }
    }
}
