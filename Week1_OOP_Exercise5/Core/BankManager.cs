using Week1_OOP_Exercise5.Core.Interfaces;
using Week1_OOP_Exercise5.Models;

namespace Week1_OOP_Exercise5.Core
{
    public class BankManager : IBankManager
    {
        readonly Bank _bank;

        IAccountManger _accounts;
        ICustomerManger _customers;

        public BankManager()
        {
            _bank = new Bank();
        }

        public BankManager(Bank bank)
        {
            _bank = bank;
        }
        public IAccountManger Accounts
        {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new AccountManager(_bank);
                }

                return _accounts;
            }
        }

        public ICustomerManger Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new CustomerManager(_bank);
                }

                return _customers;
            }
        }

        public void CalculateInterestAmount(int months)
        {
            foreach(var account in _bank.Accounts)
            {
                account.CalculateInterestAmount(months);
            }
        }

        public void CalculateInterestAmount(Account account, int months)
        {
            account.CalculateInterestAmount(months);
        }
    }
}
