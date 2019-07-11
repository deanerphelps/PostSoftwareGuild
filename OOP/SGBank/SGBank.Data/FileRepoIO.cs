using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGBank.Data
{
    public class FileRepoIO
    {
        public string filePath = @".\FileAccountRepository.txt";
        public void FileCreation()
        { 
            if(!File.Exists(filePath))
            {
                File.Create(filePath);
                Console.Write("Missing files being created...please relaunch program...");
                Console.Read();
                string[] accountInfo = new string[]
                {
                    "AccountNumber,Name,Balance,Type",
                    "11111,Free Customer,100,F",
                    "22222,Basic Customer,500,B",
                    "33333,Premium Customer,1000,P"
                };
                File.WriteAllLines(filePath, accountInfo);
            }
        }
    }
}
