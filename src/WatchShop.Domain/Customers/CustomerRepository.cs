using System.Collections.Generic;
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

        public Customer GetCustomer(int customerId)
        {
            return Db.Customers.Find(customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return Db.Customers.ToList();
        }

        public void Remove(int customerId)
        {
            Customer customer = GetCustomer(customerId);
            Db.Customers.Remove(customer);
        }
    }
}