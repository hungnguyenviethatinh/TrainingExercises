using Week1_OOP_Exercise5.Core;

namespace Week1_OOP_Exercise5.Models
{
    public sealed class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, int id = 0, decimal balance = 0.0m, decimal interestRate = 0.0m) : base(customer, id, balance, interestRate)
        {
            Type = AccountType.Mortgage;
        }

        public override void CalculateInterestAmount(int months)
        {
            if (months <= 12 && Customer.Type == CustomerType.Company)
            {
                InterestAmount = months * InterestRate / 2;
            }

            if (months <= 6 && Customer.Type == CustomerType.Individual)
            {
                InterestAmount = 0.0m;
            }

            InterestAmount = months * InterestRate;
        }
    }
}
