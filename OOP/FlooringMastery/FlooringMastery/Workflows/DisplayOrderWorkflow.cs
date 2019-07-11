using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using FlooringMastery.Data;

namespace FlooringMastery.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Order date:");
            Console.WriteLine(Helpers.starBar);
            OrderManager manager = OrderManagerFactory.Create();
            Helpers helperFunctions = new Helpers();
            Console.Clear();
            Console.WriteLine("Look up an Order:");
            Console.WriteLine(Helpers.starBar);
            Console.Write("Please enter the order number: ");
            string orderNumber = Console.ReadLine();
            OrderLookupResponse response = manager.LookupOrder(orderNumber);

            if(response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
            }
            else
            {
                Console.WriteLine("An error has occurred, please try again.");
                Console.WriteLine(response.Message);
            }
            Console.Write("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
