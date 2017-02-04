using System;
using System.Collections.Generic;
using WatchShop.Domain.Common;

namespace WatchShop.Domain.Customers
{
    public interface ICustomerRepository : IRepositoryBase, IDisposable
    {
        void Add(Customer customer);

        void Remove(Customer customer);

        Customer GetCustomer(string email);

        IEnumerable<Customer> GetCustomers();
    }
}