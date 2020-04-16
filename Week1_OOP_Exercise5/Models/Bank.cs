using System.Collections.Generic;

namespace Week1_OOP_Exercise5.Models
{
    public class Bank
    {
        public List<Account> Accounts { get; set; }
        public List<Customer> Customers { get; set; }

        public Bank()
        {
            Accounts = new List<Account>();
            Customers = new List<Customer>();
        }
    }
}
