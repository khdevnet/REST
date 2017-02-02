using System.Collections.Generic;
using WatchShop.Domain.Customers;

namespace WatchShop.Domain.Registration
{
    public interface ICustomerRegistration
    {
        bool IsCustomerRegistered(string email);

        Customer GetRegisteredCustomer(string email);

        IEnumerable<Customer> GetRegisteredCustomers();

        void RegisterCustomer(Customer customer);

        void UnRegisterCustomer(string email);
    }
}