using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WatchShop.Domain.Customers
{
    internal class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public void Add(Customer customer)
        {
            Db.Customers.Add(customer);
            Db.SaveChanges();
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

        public void Remove(string email)
        {
            Customer customer = Db.Customers.FirstOrDefault(c => c.Email == email);
            Db.Customers.Remove(customer);
            Db.SaveChanges();
        }
    }
}