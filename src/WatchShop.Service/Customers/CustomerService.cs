using System.Collections.Generic;
using System.Linq;
using WatchShop.Domain.Customers;

namespace WatchShop.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public CustomerViewModel GetRegisteredCustomer(int customerId)
        {
            return customerRepository.GetCustomers()
                .Where(x => x.Id == customerId)
                .Select(CreateCustomerViewModel)
                .First();
        }

        public IEnumerable<CustomerViewModel> GetRegisteredCustomers()
        {
            return customerRepository
                  .GetCustomers()
                  .Select(CreateCustomerViewModel);
        }

        public void RegisterCustomer(CustomerViewModel customer)
        {
            customerRepository.Add(new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            });
        }

        public void RemoveCustomer(int customerId)
        {
            customerRepository.Remove(customerId);
        }

        private CustomerViewModel CreateCustomerViewModel(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                Address = customer.Address,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone
            };
        }
    }
}