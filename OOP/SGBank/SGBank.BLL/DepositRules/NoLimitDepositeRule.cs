using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositRules
{
    public class NoLimitDepositeRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();
            if (account.Type == AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: Only basic and premium accoutns can deposit with no limit. Contact IT";
                return response;
            }
            if (amount <= 0)
            {
                response.Success = false;
                response.Message = "Deposit amounts must be positive!";
                return response;
            }
            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;
            return response; //TODO this is repeated in FreeAccountDepositRule, can we DRY?
        }
    }
}
