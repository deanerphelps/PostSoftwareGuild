using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringMastery.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager manager = OrderManagerFactory.Create();
            Helpers getOrderDate = new Helpers();
            Console.Clear();
            Console.WriteLine("Look up an Order to remove:");
            Console.WriteLine(Helpers.starBar);
            Console.Write("Please enter the order number to remove: ");
            string orderNumber = Console.ReadLine();
            OrderLookupResponse response = manager.LookupOrder(orderNumber);

            if (response.Success)
            {
                if (ConsoleInput.ConsoleInput.GetBoolFromUser("Are you sure you want to delete this order?\n\tThis cannot be undone!\n(Yes) or (No)\n"))
                {
                    var lines = File.ReadAllLines(Helpers.filePath).Where(line => !line.Split(',').FirstOrDefault().Equals(orderNumber));
                    File.WriteAllLines(Helpers.filePath, lines);
                    Console.WriteLine($"Order #{orderNumber}, on {Helpers.dateGet} has been deleted...");
                }
                else
                {
                    return;
                }
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
