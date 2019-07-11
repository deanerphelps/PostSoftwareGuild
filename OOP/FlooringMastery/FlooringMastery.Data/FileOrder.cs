using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    static class FileOrder
    {
        public static string ToRow(Order order)
        {
            string output = order.OrderNumber + ",";
            output += order.CustomerName + ",";
            output += order.State + ",";
            output += order.TaxRate + ",";
            output += order.ProductType + ",";
            output += order.Area + ",";
            output += order.CostPerSquareFoot + ",";
            output += order.LaborCostPerSquareFoot + ",";
            output += order.MaterialCost + ",";
            output += order.Tax + ",";
            output += order.Total;
            return output;
        }

        public static Order FromRow(string row)
        {
            string[] fields = row.Split(',');
            if (fields.Length != 12)
            {
                Console.WriteLine("Order is not correctly formatted! Order not saved.\nPlease try again...");
                
            }
            Order output = new Order()
            {
                OrderNumber = int.Parse(fields[0]),
                CustomerName = fields[1],
                State = fields[2],
                TaxRate = decimal.Parse(fields[3]),
                ProductType = ProductType.Wood, //TODO Make this a real check.
                Area = decimal.Parse(fields[5]),
                CostPerSquareFoot = decimal.Parse(fields[6]),
                LaborCostPerSquareFoot = decimal.Parse(fields[7]),
                MaterialCost = decimal.Parse(fields[8]), //TODO make the last 4 into correct calculations! 
                LaborCost = decimal.Parse(fields[9]),
                Tax = decimal.Parse(fields[10]),
                Total = decimal.Parse(fields[11]),
            };
            return output;
        }
    }
}
