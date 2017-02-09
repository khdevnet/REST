using System.Collections.Generic;
using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Accounts.Extensibility
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);

        void Remove(Customer customer);

        Customer GetCustomer(string email);

        IEnumerable<Customer> GetCustomers();
    }
}