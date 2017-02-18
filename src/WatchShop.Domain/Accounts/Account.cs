using System.Linq;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Accounts.Extensibility.Entities;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Identities;

namespace WatchShop.Domain.Accounts
{
    internal class Account : IAccount
    {
        private readonly IShopDataContext dataContext;

        public Account(IShopDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool IsRegistered(string email)
        {
            return dataContext.Customers.GetCustomers().Any(c => c.Email == email);
        }

        public void Register(Customer customer, string password)
        {
            if (!IsRegistered(customer.Email))
            {
                dataContext.Identities.Add(new Identity { Id = customer.Id, Password = password });
                dataContext.Customers.Add(customer);
                dataContext.SaveChanges();
            }
        }

        public void UnRegister(string email)
        {
            var customer = dataContext.Customers.GetCustomer(email);
            dataContext.Customers.Remove(customer);
            dataContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            if (IsRegistered(customer.Email))
            {
                Customer customerEntity = dataContext.Customers.GetCustomer(customer.Email);
                customerEntity.Address = customer.Address;
                customerEntity.Email = customer.Email;
                customerEntity.Name = customer.Name;
                customerEntity.Phone = customer.Phone;
                dataContext.SaveChanges();
            }
        }
    }
}