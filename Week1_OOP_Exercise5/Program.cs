using System;
using Week1_OOP_Exercise5.Core;
using Week1_OOP_Exercise5.Core.Interfaces;
using Week1_OOP_Exercise5.Models;

namespace Week1_OOP_Exercise5
{
    static class Program
    {
        static Bank _bank = new Bank();
        static IBankManager _bankManager = new BankManager(_bank);

        static void Main()
        {
            // Initializw bank's accounts and customers.
            InitializeBank();

            Console.WriteLine("Customer Type | Account Type | Balance | Interest Rate | Month(s) | Interest Amount");

            // Interest in 1 months.
            CalculateInterestAmount(1);

            // Interest in 2 months.
            CalculateInterestAmount(2);

            // Interest in 3 months.
            CalculateInterestAmount(3);

            // Interest in 4 months.
            CalculateInterestAmount(4);

            // Interest in 6 months.
            CalculateInterestAmount(6);

            // Interest in 7 months.
            CalculateInterestAmount(7);

            // Interest in 12 months.
            CalculateInterestAmount(12);

            // Interest in 13 months.
            CalculateInterestAmount(13);

            Console.ReadLine();
        }

        static void InitializeBank()
        {
            Customer[] customers = new Customer[8];

            customers[0] = new CompanyCustomer("Company 0");
            customers[1] = new IndividualCustomer("Person 0");
            customers[2] = new CompanyCustomer("Company 1");
            customers[3] = new IndividualCustomer("Person 1");
            customers[4] = new CompanyCustomer("Company 2");
            customers[5] = new IndividualCustomer("Person 2");
            customers[6] = new CompanyCustomer("Company 3");
            customers[7] = new IndividualCustomer("Person 3");

            _bankManager.Customers.AddRange(customers);

            Account[] accounts = new Account[8];
            accounts[0] = new DepositAccount(customers[0], 0, 0.0m, 0.1m); // Deposit account has balance: 0.
            accounts[1] = new DepositAccount(customers[1], 1, 1000.0m, 0.2m); // Deposit account has balance: 1000.
            accounts[2] = new LoanAccount(customers[2], 2, 2000.0m, 0.3m); // Company customer and loan account.
            accounts[3] = new LoanAccount(customers[3], 3, 3000.0m, 0.4m); // Individual customer and loan account.
            accounts[4] = new MortgageAccount(customers[4], 4, 4000.0m, 0.5m); // Company customer and mortgage account.
            accounts[5] = new MortgageAccount(customers[5], 5, 5000.0m, 0.6m); // Individual customer and mortage account.
            accounts[6] = new DepositAccount(customers[6], 0, 10.0m, 0.1m); // Deposit account has balance: > 0 and < 1000.
            accounts[7] = new DepositAccount(customers[7], 1, 5000.0m, 0.2m); // Deposit account has balance: > 1000.

            _bankManager.Accounts.AddRange(accounts);
        }

        static void CalculateInterestAmount(int months)
        {
            _bankManager.CalculateInterestAmount(months);
            var accounts = _bankManager.Accounts.GetAll();
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type}\t{account.Type}\t{account.Balance}\t{account.InterestRate}\t{months}\t{account.InterestAmount}");
            }
        }
    }
}
