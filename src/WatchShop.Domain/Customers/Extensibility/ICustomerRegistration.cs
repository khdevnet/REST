using WatchShop.Domain.Customers.Extensibility.Entities;

namespace WatchShop.Domain.Customers.Extensibility
{
    public interface ICustomerRegistration
    {
        bool IsCustomerRegistered(string email);

        void RegisterCustomer(Customer customer);

        void UnRegisterCustomer(string email);
    }
}