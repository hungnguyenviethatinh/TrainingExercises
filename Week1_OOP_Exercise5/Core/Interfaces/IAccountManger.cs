using System.Collections.Generic;
using Week1_OOP_Exercise5.Models;

namespace Week1_OOP_Exercise5.Core.Interfaces
{
    public interface IAccountManger
    {
        List<Account> GetAll();
        void Add(Account account);
        void AddRange(Account[] accounts);
        bool Remove(Account account);
        int Count();
    }
}
