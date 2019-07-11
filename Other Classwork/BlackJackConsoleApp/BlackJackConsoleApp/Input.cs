using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class Input
    {
        /// <summary>
        /// Get an integer from the console where input >= min and
        /// input <= max
        /// </summary>
        /// <param name="prompt">String to display as a prompt</param>
        /// <param name="min">Minimum inclusive lower-bound</param>
        /// <param name="max">Maximum inclusive upper-bound</param>
        /// <returns>Value within min & max range</returns>
        public static int GetIntFromUser(string prompt, int min, int max)
        {
            int outVar = 0;
            string strInput;

            do
            {
                Console.WriteLine(prompt);
                strInput = Console.ReadLine().Trim();
            } while (!int.TryParse(strInput, out outVar) || outVar < min || outVar > max);

            return outVar;
        }

        /// <summary>
        /// Get a decimal from the console where input >= min and
        /// input <= max
        /// </summary>
        /// <param name="prompt">String to display as a prompt</param>
        /// <param name="min">Minimum inclusive lower-bound</param>
        /// <param name="max">Maximum inclusive upper-bound</param>
        /// <returns>Value within min & max range</returns>
        public static decimal GetDecimalFromUser(string prompt, decimal min, decimal max)
        {
            decimal outVar = 0m;
            string strInput;

            do
            {
                Console.WriteLine(prompt);
                strInput = Console.ReadLine().Trim();
            } while (!decimal.TryParse(strInput, out outVar) || outVar < min || outVar > max);

            return outVar;
        }

        /// <summary>
        /// Given a user input of "Yes"/"Y" or "No"/"N" (case-insensitive)
        /// get a true for yes, false for no.
        /// </summary>
        /// <param name="strInput">Input string to parse</param>
        /// <param name="boolOut">True if "yes" or "y" or false for "no" or "n"</param>
        /// <returns>True if input string was yes/no. False otherwise.</returns>
        private static bool TryParseBool(string strInput, out bool boolOut)
        {
            bool isValid = false;
            boolOut = false;

            if (strInput.Equals("Yes", StringComparison.CurrentCultureIgnoreCase) ||
                strInput.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            {
                isValid = true;
                boolOut = true;
            }
            else if (strInput.Equals("No", StringComparison.CurrentCultureIgnoreCase) ||
                strInput.Equals("N", StringComparison.CurrentCultureIgnoreCase))
            {
                isValid = true;
                // Not necessary, boolOut already false
                // boolOut = false;
            }

            return isValid;
        }

        /// <summary>
        /// Get a yes/no response from the console
        /// </summary>
        /// <param name="prompt">String to display as a prompt</param>
        /// <returns>True if input is "yes" or "y" (case-insensitive) or
        /// false if "no" or "n" (also case-insensitive)</returns>
        public static bool GetBoolFromUser(string prompt)
        {
            bool outVar = false;
            string strInput;

            do
            {
                Console.WriteLine(prompt);
                strInput = Console.ReadLine().Trim();
            } while (!TryParseBool(strInput, out outVar));

            return outVar;
        }

        /// <summary>
        /// Get a non-empty string from the console
        /// </summary>
        /// <param name="prompt">String to display as a prompt</param>
        /// <returns>Input value with leading/trailing spaces removed</returns>
        public static string GetStringFromUser(string prompt)
        {
            string strInput;

            do
            {
                Console.WriteLine(prompt);
                strInput = Console.ReadLine().Trim();
            } while (strInput.Length == 0);

            return strInput;
        }
    }
}
