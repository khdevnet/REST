using System;
using System.Collections.Generic;

namespace WatchShop.Domain.Customers
{
    public interface ICustomerRepository : IDisposable
    {
        void Add(Customer customer);

        void Remove(string email);

        Customer GetCustomer(string email);

        IEnumerable<Customer> GetCustomers();
    }
}