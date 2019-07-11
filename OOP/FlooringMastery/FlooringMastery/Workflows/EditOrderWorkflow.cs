using FlooringMastery.BLL;
using FlooringMastery.Data;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager manager = OrderManagerFactory.Create();
            Helpers getOrderDate = new Helpers();
            Console.Clear();
            Console.WriteLine("Look up an Order to Edit:");
            Console.WriteLine(Helpers.starBar);
            Console.Write("Please enter the order number to Edit: ");
            string orderNumber = Console.ReadLine();
            OrderLookupResponse response = manager.LookupOrder(orderNumber);

            if (response.Success)
            {
                string[] lines = File.ReadAllLines(Helpers.filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split(',').FirstOrDefault().Equals(orderNumber))
                        lines[i] = ConsoleInput.ConsoleInput.GetStringFromUser("Enter your new input EXACTLY!\n");
                }
                File.WriteAllLines(Helpers.filePath, lines);
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
