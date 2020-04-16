using Week1_OOP_Exercise5.Core;

namespace Week1_OOP_Exercise5.Models
{
    public abstract class Account
    {
        public Customer Customer { get; set; }
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }
        public decimal InterestAmount { get; set; }
        public AccountType Type { get; protected set; }

        protected Account(Customer customer, int id = 0, decimal balance = 0.0m, decimal interestRate = 0.0m)
        {
            Customer = customer;
            Id = id;
            Balance = balance;
            InterestRate = interestRate;
            InterestAmount = 0.0m;
        }

        public abstract void CalculateInterestAmount(int months);
    }
}
