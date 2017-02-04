using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WatchShop.Domain.Common;
using WatchShop.Domain.Customers.Extensibility;
using WatchShop.Domain.Customers.Extensibility.Entities;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Customers
{
    internal class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(IShopDbContext context) : base(context)
        {
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public Customer GetCustomer(string email)
        {
            return GetCustomers().Single(c => c.Email == email);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers
                .Include(x => x.Cart.Items)
                .Include("Cart.Items.Product")
                .Include(x => x.Orders)
                .ToList();
        }

        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
        }
    }
}