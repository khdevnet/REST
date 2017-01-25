using System.Collections.Generic;
using System.Linq;
using CartDomain = WatchShop.Domain.Customers.Cart;
using CartItemDomain = WatchShop.Domain.Customers.CartItem;
using CustomerDomain = WatchShop.Domain.Customers.Customer;
using CustomerEntity = WatchShop.Domain.Database.Customer;

namespace WatchShop.Domain.Customers
{
    internal class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public void Add(CustomerDomain customer)
        {
            Db.Customers.Add(new CustomerEntity());
            Db.SaveChanges();
        }

        public CustomerDomain GetCustomer(string email)
        {
            return GetCustomers().Single(c => c.Contacts.Email == email);
        }

        public CustomerDomain GetCustomer(int customerId)
        {
            return GetCustomers().FirstOrDefault(x => x.Id == customerId);
        }

        public IEnumerable<CustomerDomain> GetCustomers()
        {
            return Db.Customers.Select(x => CreateCustomerDomain(x)).ToList();
        }

        public void Remove(int customerId)
        {
            CustomerEntity customer = Db.Customers.Find(customerId);
            Db.Customers.Remove(customer);
        }

        private static CustomerDomain CreateCustomerDomain(CustomerEntity x)
        {
            return new CustomerDomain(
                            x.Id,
                            x.Name,
                            new Contact(x.Email, x.Phone, x.Address),
                            new CartDomain(
                                x.Cart.Id,
                                x.Id,
                                x.Cart.Items.Select(c => new CartItemDomain(c.ProductId)).ToList()));
        }
    }
}