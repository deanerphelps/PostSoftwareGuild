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
    public class TestOrderRepository : IOrderRepository
    {
        public Order LoadOrder(string OrderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
