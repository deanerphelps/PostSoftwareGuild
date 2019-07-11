using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order)
        {
            Helpers orderDate = new Helpers();

            Console.WriteLine($"[{order.OrderNumber}] [{Helpers.useThis}]");
            Console.WriteLine($"[{order.CustomerName}]");
            Console.WriteLine($"[{order.State}]");
            Console.WriteLine($"Product: [{order.ProductType}]");
            Console.WriteLine($"Materials: [{order.MaterialCost}]");
            Console.WriteLine($"Labor: [{order.LaborCost}]");
            Console.WriteLine($"Tax: [{order.Tax}]");
            Console.WriteLine($"Total: [{order.Total}]");
        }
    }
}
