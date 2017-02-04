using System.Linq;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Customers.Extensibility;
using WatchShop.Domain.Customers.Extensibility.Entities;

namespace WatchShop.Domain.Customers
{
    internal class CustomerRegistration : ICustomerRegistration
    {
        private readonly IShopDataContext dataContext;

        public CustomerRegistration(IShopDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool IsCustomerRegistered(string email)
        {
            return dataContext.Customers.GetCustomers().Any(c => c.Email == email);
        }

        public void RegisterCustomer(Customer customer)
        {
            if (!IsCustomerRegistered(customer.Email))
            {
                dataContext.Customers.Add(customer);
                dataContext.SaveChanges();
            }
        }

        public void UnRegisterCustomer(string email)
        {
            var customer = dataContext.Customers.GetCustomer(email);
            dataContext.Customers.Remove(customer);
            dataContext.SaveChanges();
        }
    }
}