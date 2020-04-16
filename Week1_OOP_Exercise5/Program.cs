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

            _bankManager.CalculateInterestAmount(1);
            Console.WriteLine("Interest ammount in 1 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }
            Console.WriteLine("-----------------------------------------------------");

            _bankManager.CalculateInterestAmount(2);
            Console.WriteLine("Interest ammount in 2 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }
            Console.WriteLine("-----------------------------------------------------");

            _bankManager.CalculateInterestAmount(3);
            Console.WriteLine("Interest ammount in 3 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }
            Console.WriteLine("-----------------------------------------------------");

            _bankManager.CalculateInterestAmount(4);
            Console.WriteLine("Interest ammount in 4 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }
            Console.WriteLine("-----------------------------------------------------");

            _bankManager.CalculateInterestAmount(6);
            Console.WriteLine("Interest ammount in 6 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }
            Console.WriteLine("-----------------------------------------------------");

            _bankManager.CalculateInterestAmount(7);
            Console.WriteLine("Interest ammount in 7 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }
            Console.WriteLine("-----------------------------------------------------");

            _bankManager.CalculateInterestAmount(12);
            Console.WriteLine("Interest ammount in 12 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }
            Console.WriteLine("-----------------------------------------------------");

            _bankManager.CalculateInterestAmount(13);
            Console.WriteLine("Interest ammount in 13 months:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.Customer.Type} {account.Type} get {account.InterestAmount}");
            }

            Console.ReadLine();
        }
    }
}
