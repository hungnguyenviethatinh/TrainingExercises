using Week1_OOP_Exercise5.Core;

namespace Week1_OOP_Exercise5.Models
{
    public sealed class DepositAccount : Account
    {
        public DepositAccount(Customer customer, int id = 0, decimal balance = 0.0m, decimal interestRate = 0.0m) : base(customer, id, balance, interestRate)
        {
            Type = AccountType.Deposit;
        }

        public override void CalculateInterestAmount(int months)
        {
            if (Balance >= 0.0m && Balance <= 1000.0m)
            {
                InterestAmount = 0.0m;
            }

            InterestAmount = months * InterestRate;
        }
    }
}
