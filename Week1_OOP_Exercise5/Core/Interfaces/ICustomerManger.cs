using System.Collections.Generic;
using Week1_OOP_Exercise5.Models;

namespace Week1_OOP_Exercise5.Core.Interfaces
{
    public interface ICustomerManger
    {
        List<Customer> GetAll();
        void Add(Customer customer);
        void AddRange(Customer[] customers);
        bool Remove(Customer customer);
        int Count();
    }
}
