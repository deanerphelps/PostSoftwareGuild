using SGBank.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("  SG Bank Application");
                Console.WriteLine("------------------------------");
                Console.WriteLine("\t1. Lookup an Account");
                Console.WriteLine("\t2. Deposit");
                Console.WriteLine("\t3. Withdraw");

                Console.WriteLine("\n Q to to Exit the application.");
                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch(userinput)
                {
                    case "1":
                        AccountLookupWorkflow lookupWorkflow = new AccountLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        DepositWorkflow depositWorkflow = new DepositWorkflow();
                        depositWorkflow.Execute();
                        break;
                    case "3":
                        WithdrawWorkflow withdrawWorkflow = new WithdrawWorkflow();
                        withdrawWorkflow.Execute();
                        break;
                    case "Q":
                    case "q":
                        return;
                }
            }
        }
    }
}
