using Week1_OOP_Exercise5.Core;

namespace Week1_OOP_Exercise5.Models
{
    public sealed class CompanyCustomer : Customer
    {
        public CompanyCustomer(string name = "") : base(name)
        {
            Type = CustomerType.Company;
        }
    }
}
