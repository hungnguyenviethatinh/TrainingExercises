using Week1_OOP_Exercise5.Models;

namespace Week1_OOP_Exercise5.Core.Interfaces
{
    public interface IBankManager
    {
        IAccountManger Accounts { get; }
        ICustomerManger Customers { get; }
        void CalculateInterestAmount(int months);
        void CalculateInterestAmount(Account account, int months);
    }
}
