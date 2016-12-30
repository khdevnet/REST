using System.Collections.Generic;

namespace WatchShop.Service.Customers
{
    public interface ICustomerService
    {
        CustomerViewModel GetRegisteredCustomer(int customerId);

        IEnumerable<CustomerViewModel> GetRegisteredCustomers();

        void RegisterCustomer(CustomerViewModel customer);

        void RemoveCustomer(int customerId);
    }
}