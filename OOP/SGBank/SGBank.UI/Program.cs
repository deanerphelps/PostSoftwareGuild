using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SGBank.Data;

namespace SGBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRepoIO createFile = new FileRepoIO();
            createFile.FileCreation();
            Menu.Start();
        }
    }
}
