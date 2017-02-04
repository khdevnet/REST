using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WatchShop.Domain.Customers
{
    internal class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public void Add(Customer customer)
        {
            Db.Customers.Add(customer);
        }

        public Customer GetCustomer(string email)
        {
            return GetCustomers().Single(c => c.Email == email);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return Db.Customers
                .Include(x => x.Cart.Items)
                .Include("Cart.Items.Product")
                .Include(x => x.Orders)
                .ToList();
        }

        public void Remove(Customer customer)
        {
            Db.Customers.Remove(customer);
        }
    }
}