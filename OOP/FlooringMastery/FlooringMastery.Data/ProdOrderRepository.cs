using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data
{
    public class ProdOrderRepository : IOrderRepository
    {
        private string _path;
        public ProdOrderRepository(string path)
        {
            _path = path;
        }

        public Order LoadOrder(string OrderNumber)
        {
            string[] rows = File.ReadAllLines(_path);
            foreach (string row in rows)
            {
                if (row.Split(',')[0] == OrderNumber)
                {
                    return FileOrder.FromRow(row);
                }
            }
            return null;
        }

        public void SaveOrder(Order order)
        {
            string[] rows = File.ReadAllLines(_path);

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Split(',')[0] == order.OrderNumber.ToString())
                {
                    rows[i] = FileOrder.ToRow(order);
                    break;
                }
            }
            File.WriteAllLines(_path, rows);
        }
    }
}
