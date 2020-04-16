using System.Collections.Generic;
using Week1_OOP_Exercise5.Core.Interfaces;
using Week1_OOP_Exercise5.Models;

namespace Week1_OOP_Exercise5.Core
{
    public class AccountManager : IAccountManger
    {
        readonly Bank _bank;

        public AccountManager(Bank bank)
        {
            _bank = bank;
        }
        
        public List<Account> GetAll()
        {
            return _bank.Accounts;
        }

        public void Add(Account account)
        {
            _bank.Accounts.Add(account);
        }

        public void AddRange(Account[] accounts)
        {
            _bank.Accounts.AddRange(accounts);
        }

        public bool Remove(Account account)
        {
            return _bank.Accounts.Remove(account);
        }

        public int Count()
        {
            return _bank.Accounts.Count;
        }
    }
}
