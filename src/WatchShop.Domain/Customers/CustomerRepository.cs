using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WatchShop.Domain.Customers
{
    internal class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public void Add(Customer customer)
        {
            Db.Customers.Add(new Customer());
            Db.SaveChanges();
        }

        public Customer GetCustomer(string email)
        {
            return GetCustomers().Single(c => c.Email == email);
        }

        public Customer GetCustomer(int customerId)
        {
            return GetCustomers().FirstOrDefault(x => x.Id == customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return Db.Customers
                .Include(x => x.Cart.Items)
                .Include("Cart.Items.Product")
                .Include(x => x.Orders)
                .ToList();
        }

        public void Remove(int customerId)
        {
            Customer customer = Db.Customers.Find(customerId);
            Db.Customers.Remove(customer);
        }
    }
}