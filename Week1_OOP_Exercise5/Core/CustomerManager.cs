using System.Collections.Generic;
using Week1_OOP_Exercise5.Core.Interfaces;
using Week1_OOP_Exercise5.Models;

namespace Week1_OOP_Exercise5.Core
{
    public class CustomerManager : ICustomerManger
    {
        readonly Bank _bank;

        public CustomerManager(Bank bank)
        {
            _bank = bank;
        }

        public List<Customer> GetAll()
        {
            return _bank.Customers;
        }

        public void Add(Customer customer)
        {
            _bank.Customers.Add(customer);
        }

        public void AddRange(Customer[] customers)
        {
            _bank.Customers.AddRange(customers);
        }

        public bool Remove(Customer customer)
        {
            return _bank.Customers.Remove(customer);
        }

        public int Count()
        {
            return _bank.Customers.Count;
        }
    }
}
