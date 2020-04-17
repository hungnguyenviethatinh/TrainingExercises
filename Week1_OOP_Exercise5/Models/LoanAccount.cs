using Week1_OOP_Exercise5.Core;

namespace Week1_OOP_Exercise5.Models
{
    public sealed class LoanAccount : Account
    {
        public LoanAccount(Customer customer, int id = 0, decimal balance = 0.0m, decimal interestRate = 0.0m) : base(customer, id, balance, interestRate)
        {
            Type = AccountType.Loan;
        }

        public override void CalculateInterestAmount(int months)
        {
            if ((months < 2 && Customer.Type == CustomerType.Company) || (months <= 3 && Customer.Type == CustomerType.Individual))
            {
                InterestAmount = 0.0m;
            }
            else
            {
                InterestAmount = months * InterestRate;
            }
        }
    }
}
