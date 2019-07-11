using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            Helpers orderDate = new Helpers();
            string _path = orderDate.GetOrderDateFromUser().ToString("MMddyyyy");

            switch(mode)
            {
                case "Test":
                   // return new OrderManager(new TestOrderRepository($@".\Orders\Orders_{_path}.txt"));
                case "Prod":
                    return new OrderManager(new ProdOrderRepository($@".\Orders\Orders_{_path}.txt"));
                default:
                    throw new Exception("Mode value in app config isn't valid!");
            }
        }
    }
}
