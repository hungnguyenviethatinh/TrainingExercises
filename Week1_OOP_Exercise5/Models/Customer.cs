using Week1_OOP_Exercise5.Core;

namespace Week1_OOP_Exercise5.Models
{
    public abstract class Customer
    {
        public string Name { get; set; }
        public CustomerType Type { get; protected set; }

        protected Customer(string name = "")
        {
            Name = name;
        }
    }
}
