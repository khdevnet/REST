using System;
using System.Collections.Generic;

namespace WatchShop.Domain.Customers
{
    public interface ICustomerRepository : IDisposable
    {
        void Add(Customer customer);

        void Remove(int customerId);

        Customer GetCustomer(int customerId);

        IEnumerable<Customer> GetCustomers();
    }
}