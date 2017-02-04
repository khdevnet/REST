using System.Collections.Generic;

namespace WatchShop.Domain.Customers
{
    public interface ICustomerRegistration
    {
        bool IsCustomerRegistered(string email);

        void RegisterCustomer(Customer customer);

        void UnRegisterCustomer(string email);
    }
}