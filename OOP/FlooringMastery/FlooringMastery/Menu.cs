using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.UI.Workflows;

namespace FlooringMastery.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Helpers.starBar);
                Console.WriteLine("  Flooring Program");
                Console.WriteLine(Helpers.starBar);
                Console.WriteLine("\t1. Display Orders");
                Console.WriteLine("\n\t2. Add an Order");
                Console.WriteLine("\n\t3. Edit an Order");
                Console.WriteLine("\n\t4. Remove an Order");
                Console.WriteLine("\n\t5. Quit");
                Console.WriteLine(Helpers.starBar);
                Console.Write("\nPlease enter your selection: ");

                string userInput = Console.ReadLine().Trim();
                switch (userInput)
                {
                    case "1":
                        DisplayOrderWorkflow displayOrder = new DisplayOrderWorkflow();
                        displayOrder.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addOrder = new AddOrderWorkflow();
                        addOrder.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editOrder = new EditOrderWorkflow();
                        editOrder.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow remOrder = new RemoveOrderWorkflow();
                        remOrder.Execute();
                        break;
                    case "5":
                    case "Q":
                    case "q":
                        return;
                    default:
                        Console.Write("\nError, that's not a valid selection, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
