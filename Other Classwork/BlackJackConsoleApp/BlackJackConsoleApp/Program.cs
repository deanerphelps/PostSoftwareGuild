using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();

            table.Execute();
            Console.ReadLine();
        }
    }
}
