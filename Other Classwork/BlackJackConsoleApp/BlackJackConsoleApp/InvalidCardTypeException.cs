using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    public class InvalidCardTypeException : Exception
    {
        public InvalidCardTypeException(string error) : base(error)
        {
        }
    }
}
