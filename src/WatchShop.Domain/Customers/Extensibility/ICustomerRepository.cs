using System.Collections.Generic;
using WatchShop.Domain.Customers.Extensibility.Entities;

namespace WatchShop.Domain.Customers.Extensibility
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);

        void Remove(Customer customer);

        Customer GetCustomer(string email);

        IEnumerable<Customer> GetCustomers();
    }
}