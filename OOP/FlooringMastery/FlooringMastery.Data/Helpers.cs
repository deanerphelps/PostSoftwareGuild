using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FlooringMastery.Data
{
    public class Helpers
    {
        public static string starBar = "******************************";
        public static string dateGet = DateTime.Today.ToString("MMddyyyy");
        public static string filePath = $@".\Orders\Orders_{dateGet}.txt";
        public static string useThis;
        public DateTime orderDate;

        //Gets input from the user and checks if it's a valid date. If it is, displays date as MMddyyyy.
        public DateTime GetOrderDateFromUser()
        {
            Console.Write("Please enter a valid date for the order: ");
            if (DateTime.TryParse(Console.ReadLine(), out orderDate))
            {
                Console.Write($"You entered... { orderDate.ToString("MMddyyyy")}");
            }
            else
            {
                Console.WriteLine("That's not a valid date. Try again.");
            }
            Console.ReadKey();
            useThis = orderDate.ToString("MMddyyyy");
            return orderDate;
        }
    }
}
