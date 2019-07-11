using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using FlooringMastery.Data;
using ConsoleInput;
using FlooringMastery.Models;

namespace FlooringMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Order date:");
            Console.WriteLine(Helpers.starBar);
            Helpers orderDate = new Helpers();
            string _path = orderDate.GetOrderDateFromUser().ToString("MMddyyyy");
            string orderNum = ConsoleInput.ConsoleInput.GetStringFromUser("Please enter the Order Number: ");
            string cusName = ConsoleInput.ConsoleInput.GetStringFromUser("Please enter the customer name: ");
            string state = ConsoleInput.ConsoleInput.GetStringFromUser("Please enter the state.\n\tUse the XX format.\n\tEx: KY\n");
            string prodType = ConsoleInput.ConsoleInput.GetStringFromUser("Please enter the product type from the choices below:" +
                "\n\t1. Wood\n\t2. Tile\n\t3. Laminate\n\t4. Carpet\n");
            decimal prodArea = ConsoleInput.ConsoleInput.GetDecimalFromUser("What is the total area?\n", 100m, 100000000m);

            Order order = new Order();
            order.OrderNumber = int.Parse(orderNum);
            order.Area = prodArea;
            order.State = state;
            order.ProductType = ProductType.Wood;
            order.CustomerName = cusName;
            order.MaterialCost = order.Area * (order.CostPerSquareFoot=5.15m);
            order.LaborCost = order.Area * order.LaborCostPerSquareFoot;
            order.Tax = (order.MaterialCost + order.LaborCost) * (order.TaxRate / 100);
            order.Total = order.MaterialCost + order.LaborCost + order.Tax;
            ConsoleIO.DisplayOrderDetails(order);
            
            string bigTest = ($"{orderNum},{order.CustomerName},{order.State},{order.TaxRate},{order.ProductType},{order.Area},{order.CostPerSquareFoot}" +
                $"{order.LaborCostPerSquareFoot},{order.MaterialCost},{order.LaborCost},{order.Tax},{order.Total}"); 
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter($@".\Orders\Orders_{_path}.txt", true))
            {
                file.WriteLine(bigTest);
            }
            Console.Write("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
