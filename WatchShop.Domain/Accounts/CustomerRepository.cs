using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Accounts.Extensibility.Entities;
using WatchShop.Domain.Common;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Accounts
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
            return context.Customers.Single(c => c.Email == email);
        }

        public Customer GetCustomerByToken(string token)
        {
            return context.Customers.Single(c => c.Token.Value == token);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers
                .Include(x => x.Cart.Items)
                .Include("Cart.Items.Product")
                .Include(x => x.Orders)
                .ToList();
        }

        public bool IsIdentified(string email, string hashPassword)
        {
            return context.Customers.Any(c => c.Email == email && c.Identity.Password == hashPassword);
        }

        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
        }
    }
}