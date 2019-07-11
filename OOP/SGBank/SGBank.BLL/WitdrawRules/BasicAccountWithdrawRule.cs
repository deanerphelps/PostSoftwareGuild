using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WitdrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();
            if (account.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = "Error: Non-Basic account hit the Basic withdraw rule. Contact IT";
                return response;
            }
            if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative!";
                return response;
            }
            if (amount < -500) //TODO Magic number, remove.
            {
                response.Success = false;
                response.Message = "Basic accounts cannot withdraw more than $500!";
                return response;
            }
            if (amount + account.Balance < -100) //TODO more magic numbers
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit.";
                return response;
            }
            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;
            if (account.Balance < 0)
            {
                decimal fee = 10;
                account.Balance -= fee;
            }
            return response;
        }
    }
}
