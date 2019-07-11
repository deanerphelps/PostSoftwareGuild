using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummativeSums
{
    class Program
    {      
        static void Main(string[] args)
        {
            int[] arr1;
            int[] arr2;
            int[] arr3;

            arr1 = new int[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            arr2 = new int[] { 999, -60, -77, 14, 160, 301 };
            arr3 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130,
                    140, 150, 160, 170, 180, 190, 200, -99 };

            int i = 0;
            int sum = 0;
            for (i = 0; i < arr1.Length; i++)
            {
                sum += arr1[i];
            }
            Console.WriteLine($"The sum of array 1 is: {sum}");

            sum = 0;
            for (i = 0; i < arr2.Length; i++)
            {
                sum += arr2[i];
            }
            Console.WriteLine($"The sum of array 2 is: {sum}");

            sum = 0;
            for (i = 0; i < arr3.Length; i++)
            {
                sum += arr3[i];
            }
            Console.WriteLine($"The sum of array 3 is: {sum}");
            Console.ReadKey();
        }
    }
}
