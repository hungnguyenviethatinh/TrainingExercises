using Week1_OOP_Exercise5.Core;

namespace Week1_OOP_Exercise5.Models
{
    public sealed class IndividualCustomer : Customer
    {
        public IndividualCustomer(string name = "") : base(name)
        {
            Type = CustomerType.Individual;
        }
    }
}
